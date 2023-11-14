using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Aplication.Commands;

public class LoginCommand : IRequest<(SignInResult, string)>
{
    public string Email { get; set; }
    public string Password { get; set; }
    public bool Remember { get; set; }
}