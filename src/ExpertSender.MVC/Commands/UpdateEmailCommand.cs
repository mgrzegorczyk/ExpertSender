using ExpertSender.MVC.Entities;
using ExpertSender.MVC.Models;
using ExpertSender.MVC.Repositories;
using MediatR;

namespace ExpertSender.MVC.Commands;

public record UpdateEmailCommand(int Id, string EmailAddress) : IRequest;
public class UpdateEmailCommandHandler : IRequestHandler<UpdateEmailCommand>
{
    private readonly IEmailRepository _emailRepository;

    public UpdateEmailCommandHandler(IEmailRepository emailRepository)
    {
        _emailRepository = emailRepository;
    }

    public async Task<Unit> Handle(UpdateEmailCommand request, CancellationToken cancellationToken)
    {
        var email = new Email
        {
            Id = request.Id,
            EmailAddress = request.EmailAddress
        };

        await _emailRepository.UpdateAsync(email);

        return Unit.Value;
    }
}