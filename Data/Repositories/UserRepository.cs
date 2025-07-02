using ProjektHaushaltsbuch.Domain.Interfaces;
using ProjektHaushaltsbuch.Models;

namespace ProjektHaushaltsbuch.Data.Repositories;

public class UserRepository(ProjektHaushaltsbuchContext context): IUserRepository
{
    //TODO Implement Repository Pattern
    public async Task<List<UserModel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<UserModel?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<UserModel?> GetByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public async Task<UserModel> AddAsync(UserModel user)
    {
        throw new NotImplementedException();
    }

    public async Task<UserModel> UpdateAsync(UserModel user)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> EmailExistsAsync(string email)
    {
        throw new NotImplementedException();
    }
}