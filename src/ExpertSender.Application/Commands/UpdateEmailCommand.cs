using ExpertSender.Domain.Entities;
using ExpertSender.Infrastructure.Repositories;
using MediatR;

namespace ExpertSender.Application.Commands;

public record UpdateEmailCommand(int Id, string EmailAddress) : IRequest;
public class UpdateEmailCommandHandler : IRequestHandler<UpdateEmailCommand>
{
    private readonly IEmailRepository _emailRepository;

    public UpdateEmailCommandHandler(IEmailRepository emailRepository)
    {
        _emailRepository = emailRepository;
    }

    public async Task Handle(UpdateEmailCommand request, CancellationToken cancellationToken)
    {
        var email = new Email
        {
            Id = request.Id,
            EmailAddress = request.EmailAddress
        };

        await _emailRepository.UpdateAsync(email);
    }
}