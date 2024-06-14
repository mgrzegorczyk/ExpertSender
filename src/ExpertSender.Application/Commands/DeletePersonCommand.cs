using ExpertSender.Infrastructure.Repositories;
using MediatR;

namespace ExpertSender.Application.Commands;

public class DeletePersonCommand : IRequest
{
    public int Id { get; set; }
}

public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand>
{
    private readonly IPersonRepository _personRepository;

    public DeletePersonCommandHandler(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task Handle(DeletePersonCommand request, CancellationToken cancellationToken)
    {
        await _personRepository.DeleteAsync(request.Id);
    }
}