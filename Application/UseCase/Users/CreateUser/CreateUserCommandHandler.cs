using Domain.Abstraction;
using Domain.Users;
using Domain.Users.Events;
using MediatR;

namespace Application.UseCase.Users.CreateUser;

internal sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMediator _mediator;

    public CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, IMediator mediator)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _mediator = mediator;
    }

    public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.CreateAsync(request.Name,
                                          request.Email,
                                          request.Password,
                                          request.Coutry,
                                          request.City,
                                          request.Street,
                                          request.FullAddress,
                                          request.PostalCode);

        await _unitOfWork.SaveChangesAsync();

        await _mediator.Publish(new UserDomainEvent(user));
    }
}

