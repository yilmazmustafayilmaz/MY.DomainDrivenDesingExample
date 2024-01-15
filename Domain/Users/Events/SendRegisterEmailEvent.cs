﻿using MediatR;

namespace Domain.Users.Events;

public sealed class SendRegisterEmailEvent : INotificationHandler<UserDomainEvent>
{
    public Task Handle(UserDomainEvent notification, CancellationToken cancellationToken)
    {
        //Mail gönder
        return Task.CompletedTask;
    }
}
