using Aplication.Commands;
using Infrastructure.Data.Repositories.Interfaces;
using Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Aplication.Handlers;

public class AddUserHandler : IRequestHandler<AddUserCommand, IdentityResult>
{
    private readonly IUserRepository _userRepository;

    public AddUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<IdentityResult> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        var user = new ApplicationUser
        {
            UserName = request.Email,
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName
        };
        return await _userRepository.CreateUserAsync(user, request.Password);
    }
}