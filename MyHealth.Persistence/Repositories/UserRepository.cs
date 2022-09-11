using AutoMapper;

using Microsoft.EntityFrameworkCore;

using MyHealth.Application.Contracts;
using MyHealth.Domain.DTOs;
using MyHealth.Persistence.Identity;

namespace MyHealth.Persistence.Repositories;

public class UserRepository : IAsyncUserRepository
{
    protected readonly ApplicationDbContext _dbContext;
    private readonly IMapper mapper;
    public UserRepository(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        this.mapper = mapper;   
    }


    public async Task<ApplicationUserDTO> AddAsync(ApplicationUserDTO appUserDTO)
    {
        ApplicationUser user = mapper.Map<ApplicationUser>(appUserDTO);
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();

        var dto = mapper.Map<ApplicationUserDTO>(user);
        return dto;
    }

    public async Task DeleteAsync(Guid id)
    {
        var user = await _dbContext.Users.FindAsync(id);
        _dbContext.Users.Remove(user!);

        await _dbContext.SaveChangesAsync();
    }

    public async Task<ApplicationUserDTO> GetByIdAsync(string id)
    {
        var user = await _dbContext.Users.FindAsync(id);
        if (user is not null) return mapper.Map<ApplicationUserDTO>(user);
        else throw new NullReferenceException();
    }

    public async Task UpdateAsync(ApplicationUserDTO userDTO)
    {
        var user = mapper.Map<ApplicationUser>(userDTO);
        _dbContext.Entry(user).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<ApplicationUserDTO>> GetAllApplicationUsersDTOs()
    {
        var users = await _dbContext.Users.ToListAsync();
        var UserDTOs = mapper.Map<List<ApplicationUserDTO>>(users);
        return UserDTOs;
    }
}


class UsersMapper : Profile
{
    public UsersMapper()
    {
        CreateMap<ApplicationUserDTO, ApplicationUser>()
            .ForMember(dest => dest.Id , opt => opt.Ignore())
            .ForMember(dest => dest.PhoneNumberConfirmed, src => src.MapFrom(val => true))
            .ForMember(dest => dest.EmailConfirmed, src => src.MapFrom(val => true))
            .ReverseMap()
            .ForMember(dest => dest.Id , opt => opt.MapFrom(src =>  new Guid(src.Id)));
    }
}
