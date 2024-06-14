using ExpertSender.MVC.Repositories;
using MediatR;

namespace ExpertSender.MVC.Commands;

public record DeleteEmailCommand(int Id) : IRequest;

public class DeleteEmailCommandHandler : IRequestHandler<DeleteEmailCommand>
{
    private readonly IEmailRepository _emailRepository;

    public DeleteEmailCommandHandler(IEmailRepository emailRepository)
    {
        _emailRepository = emailRepository;
    }

    public async Task<Unit> Handle(DeleteEmailCommand request, CancellationToken cancellationToken)
    {
        await _emailRepository.DeleteAsync(request.Id);
        return Unit.Value;
    }
}