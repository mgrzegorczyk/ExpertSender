using ExpertSender.MVC.Repositories;
using MediatR;

namespace ExpertSender.MVC.Commands;

public class UpdatePersonDetailsCommand : IRequest
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Description { get; set; }
}

public class UpdatePersonDetailsCommandHandler : IRequestHandler<UpdatePersonDetailsCommand>
{
    private readonly IPersonRepository _personRepository;

    public UpdatePersonDetailsCommandHandler(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task<Unit> Handle(UpdatePersonDetailsCommand request, CancellationToken cancellationToken)
    {
        var person = await _personRepository.GetByIdAsync(request.Id);

        if (person == null)
        {
            throw new KeyNotFoundException("Person not found.");
        }

        person.FirstName = request.FirstName;
        person.LastName = request.LastName;
        person.Description = request.Description;

        await _personRepository.UpdateAsync(person);

        return Unit.Value;
    }
}