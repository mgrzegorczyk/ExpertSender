using ExpertSender.MVC.Repositories;
using MediatR;

namespace ExpertSender.MVC.Commands;

public class DeleteEmailCommand : IRequest
{
    public int Id { get; set; }
}

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