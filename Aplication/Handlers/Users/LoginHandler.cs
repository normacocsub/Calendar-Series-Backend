using Aplication.Commands;
using Infrastructure.Data.Repositories.Interfaces;
using Infrastructure.Jwt.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Aplication.Handlers;

public class LoginHandler : IRequestHandler<LoginCommand, (SignInResult, string)>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtService _jwtService;

    public LoginHandler(IUserRepository userRepository, IJwtService jwtService)
    {
        _userRepository = userRepository;
        _jwtService = jwtService;
    }
    public async Task<(SignInResult, string)> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByEmailAsync(request.Email);
        if (user is null) return (SignInResult.Failed, "");
        var result = await _userRepository.Login(user, request.Password, request.Remember, true);
        if (!result.Succeeded) return (result, "");
        var roles =  await _userRepository.GetRolesUser(user);
        var token = _jwtService.GenerateToken(user.Id, user.Email!, roles.ToArray());
        return (result, token);
    }
}