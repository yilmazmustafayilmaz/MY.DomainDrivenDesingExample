using MediatR;

namespace Application.UseCase.Users.CreateUser;

public sealed record CreateUserCommand(
    string Name,
    string Email,
    string Password,
    string Coutry,
    string City,
    string Street,
    string FullAddress,
    string PostalCode) : IRequest;

