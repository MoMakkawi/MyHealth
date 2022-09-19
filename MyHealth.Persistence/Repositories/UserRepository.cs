using System.Net.Mail;

using AutoMapper;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using MyHealth.Application.Contracts;
using MyHealth.Domain.DTOs;
using MyHealth.Domain.Helpers;
using MyHealth.Persistence.Identity;

namespace MyHealth.Persistence.Repositories;

public class UserRepository : IAsyncUserRepository
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IMapper _mapper;
    public UserRepository(IMapper mapper, UserManager<ApplicationUser> userManager , RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _mapper = mapper;
        _roleManager = roleManager;
    }


    public async Task<dynamic> AddAsync(ApplicationUserDTO userDTO)
    {
        ApplicationUser user = _mapper.Map<ApplicationUser>(userDTO);
        user.UserName = new MailAddress(userDTO.Email!).User.ToString();

        if (await _userManager.FindByEmailAsync(userDTO.Email) is not null)
            return new AuthModel { Message = "Email is already registered!" };

        if (await _userManager.FindByNameAsync(user.UserName) is not null)
            return new AuthModel { Message = "UserName is already registered!" };

        var result = await _userManager.CreateAsync(user,userDTO.Password);
        if (result.Succeeded is not true)
        {
            var errors = string.Join(",", result.Errors.Select(e => e.Code + " " + e.Description));
            return new AuthModel { Message = errors };
        }

        var assignUserToRoleResult = await AssignUserToRole(user, userDTO.Role!);
        if (!assignUserToRoleResult.IsAuthenticated)
            return new AuthModel { Message = assignUserToRoleResult.Message };
        
        user = await _userManager.Users.FirstAsync(u => u.Email == userDTO.Email);
        return new AuthModel
        {
            UserId = new Guid(user.Id),
            Email = user.Email,
            IsAuthenticated = true,
            Role = userDTO.Role,
            UserName = user.UserName
        };

    }

    private async Task<AuthModel> AssignUserToRole(ApplicationUser user, string role)
    {
        if (!await _roleManager.RoleExistsAsync(role))
            return new AuthModel { Message = "Invalid Role" };
        if (!await _userManager.IsInRoleAsync(user, role))
            return new AuthModel { Message = "User already assigned to this role" };

        var result = await _userManager.AddToRoleAsync(user, role);

        if (! result.Succeeded)
        {
            var errors = string.Join(",", result.Errors.Select(e => e.Code + " " + e.Description));
            return new AuthModel { Message = errors };
        }
        return new AuthModel { IsAuthenticated = true };
    }

    public async Task DeleteAsync(Guid id)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());
        if (user is null)
            throw new Exception($"User by Id = {id} not found");

        await _userManager.DeleteAsync(user!);
    }

    public async Task<ApplicationUserDTO> GetByIdAsync(dynamic id)
    {
        string Id = Convert.ToString(id);

        var user = await _userManager.FindByIdAsync(Id);

        if (user is not null) return _mapper.Map<ApplicationUserDTO>(user);
        else throw new NullReferenceException();
    }

    public async Task UpdateAsync(ApplicationUserDTO userDTO)
    {
        var user = await _userManager.FindByIdAsync(userDTO.Id.ToString());

        if (user is null)
            throw new Exception($"User by Id = {userDTO.Id} not found");
        
        user.PhoneNumber = userDTO.PhoneNumber;
        user.FirstName = userDTO.FirstName;
        user.LastName = userDTO.LastName;
        user.ProfilePicture = userDTO.ProfilePicture;
        user.Gender = user.Gender;
        await _userManager.RemovePasswordAsync(user);
        await _userManager.AddPasswordAsync(user, userDTO.Password);


        if (user.Email != userDTO.Email &&
            await _userManager.FindByEmailAsync(userDTO.Email) is not null)
            throw new Exception("Email is already registered!");

        user.Email = userDTO.Email;

        if (user.UserName != userDTO.UserName &&
            await _userManager.FindByNameAsync(userDTO.UserName) is not null)
            throw new Exception("UserName is already registered!");

        user.UserName = userDTO.UserName;

        var result = await _userManager.UpdateAsync(user);
        if (!result.Succeeded)
        {
            var errors = string.Join(",", result.Errors.Select(e => e.Code + " " + e.Description));
            throw new Exception(errors);
        }

    }

    public async Task<List<ApplicationUserDTO>> GetAllApplicationUsersDTOs()
    {
        var users = await _userManager.Users.ToListAsync();
        var UserDTOs = _mapper.Map<List<ApplicationUserDTO>>(users);
        return UserDTOs;
    }

}


class UsersMapper : Profile
{
    public UsersMapper()
    {
        CreateMap<ApplicationUserDTO, ApplicationUser>()
            .ForMember(dest => dest.Id , opt => opt.Ignore())
            .ReverseMap()
            .ForMember(dest => dest.Id , opt => opt.MapFrom(src =>  new Guid(src.Id)));
    }
}
