using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Aplication.Commands;

public class AddUserCommand : IRequest<IdentityResult>
{
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
}