using Domain.Users;
using MediatR;

namespace Application.UseCase.Users.GetAllUser;

public sealed record GetAllUserQuery() : IRequest<List<User>>;
