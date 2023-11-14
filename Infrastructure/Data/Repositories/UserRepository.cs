using Infrastructure.Data.Repositories.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _singInManager;
    public UserRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _singInManager = signInManager;
    }
    
    public async Task<ApplicationUser> GetUserByIdAsync(string userId)
    {
        return (await _userManager.FindByIdAsync(userId))!;
    }

    public async Task<ApplicationUser> GetUserByEmailAsync(string email)
    {
        return (await _userManager.FindByEmailAsync(email))!;
    }

    public async Task<IEnumerable<ApplicationUser>> GetAllUsersAsync()
    {
        return (await _userManager.Users.ToListAsync());
    }

    public async Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password)
    {
        var result =  await _userManager.CreateAsync(user, password);
        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, "USUARIO".Trim());
        }
        return result;
    }

    public async Task<IEnumerable<string>> GetRolesUser(ApplicationUser user)
    {
        return await _userManager.GetRolesAsync(user);
    }

    public async Task<SignInResult> Login(ApplicationUser user, string password, bool remember, bool lockoutOnFailure)
    {
        return await _singInManager.PasswordSignInAsync(user, password, remember, lockoutOnFailure);
    }
}