using MyHealth.Domain.DTOs;

namespace MyHealth.Application.Contracts;

public interface IAsyncUserRepository : IAsyncRepository<ApplicationUserDTO>
{
    Task<List<ApplicationUserDTO>> GetAllApplicationUsersDTOs();
}
