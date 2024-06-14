using ExpertSender.MVC.Models;
using ExpertSender.MVC.Repositories;
using MediatR;

namespace ExpertSender.MVC.Queries;

public class GetPeopleQuery : IRequest<List<Person>>
{
}

public class GetPeopleQueryHandler : IRequestHandler<GetPeopleQuery, List<Person>>
{
    private readonly IPersonRepository _personRepository;

    public GetPeopleQueryHandler(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task<List<Person>> Handle(GetPeopleQuery request, CancellationToken cancellationToken)
    {
        return await _personRepository.GetAllAsync();
    }
}