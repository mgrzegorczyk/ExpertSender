using ExpertSender.MVC.Models;
using ExpertSender.MVC.Repositories;
using MediatR;

namespace ExpertSender.MVC.Queries;

public record GetPersonByIdQuery(int Id) : IRequest<Person>;

public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, Person>
{
    private readonly IPersonRepository _personRepository;

    public GetPersonByIdQueryHandler(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task<Person> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
    {
        return await _personRepository.GetByIdAsync(request.Id);
    }
}