using ProjektHaushaltsbuch.Models;

namespace ProjektHaushaltsbuch.Domain.Interfaces;

public interface IUserRepository
{
    Task<List<UserModel>> GetAllAsync();
    Task<UserModel?> GetByIdAsync(Guid id);
    Task<UserModel?> GetByEmailAsync(string email);
    Task<UserModel> AddAsync(UserModel user);
    Task<UserModel> UpdateAsync(UserModel user);
    Task DeleteAsync(Guid id);
    Task<bool> ExistsAsync(Guid id);
    Task<bool> EmailExistsAsync(string email);
}