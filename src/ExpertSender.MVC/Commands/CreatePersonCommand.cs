using ExpertSender.MVC.Models;
using ExpertSender.MVC.Repositories;
using MediatR;

namespace ExpertSender.MVC.Commands;

public class CreatePersonCommand : IRequest<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Description { get; set; }
    public string EmailAddress { get; set; }
}

public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, int>
{
    private readonly IPersonRepository _personRepository;

    public CreatePersonCommandHandler(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task<int> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
        var person = new Person
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Description = request.Description,
        };

        person.Emails = new List<Email>() { new Email() { EmailAddress = request.EmailAddress, Person = person } };

        await _personRepository.AddAsync(person);

        return person.Id;
    }
}