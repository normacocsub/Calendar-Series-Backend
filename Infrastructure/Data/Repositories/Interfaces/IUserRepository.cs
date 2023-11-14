using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Data.Repositories.Interfaces;

public interface IUserRepository
{
    Task<ApplicationUser> GetUserByIdAsync(string userId);
    Task<ApplicationUser> GetUserByEmailAsync(string email);
    Task<IEnumerable<ApplicationUser>> GetAllUsersAsync();
    Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password);
    Task<SignInResult> Login(ApplicationUser user, string password, bool remember, bool lockoutOnFailure);
    Task<IEnumerable<string>> GetRolesUser(ApplicationUser user);
}