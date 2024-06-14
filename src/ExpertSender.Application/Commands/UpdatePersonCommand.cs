using ExpertSender.Domain.Entities;
using ExpertSender.Infrastructure.Repositories;
using MediatR;

namespace ExpertSender.Application.Commands;

public class UpdatePersonCommand : IRequest
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Description { get; set; }
    public List<Email> Emails { get; set; }
}

public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand>
{
    private readonly IPersonRepository _personRepository;

    public UpdatePersonCommandHandler(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
    {
        var person = new Person
        {
            Id = request.Id,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Description = request.Description,
            Emails = request.Emails
        };

        await _personRepository.UpdateAsync(person);
    }
}