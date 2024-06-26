﻿using ExpertSender.Domain.Entities;
using ExpertSender.Infrastructure.Repositories;
using MediatR;

namespace ExpertSender.Application.Commands;

public record CreateEmailCommand(string EmailAddress, int PersonId) : IRequest<int>;

public class CreateEmailCommandHandler : IRequestHandler<CreateEmailCommand, int>
{
    private readonly IEmailRepository _emailRepository;

    public CreateEmailCommandHandler(IEmailRepository emailRepository)
    {
        _emailRepository = emailRepository;
    }

    public async Task<int> Handle(CreateEmailCommand request, CancellationToken cancellationToken)
    {
        var email = new Email
        {
            EmailAddress = request.EmailAddress,
            PersonId = request.PersonId
        };

        await _emailRepository.AddAsync(email);

        return email.Id;
    }
}