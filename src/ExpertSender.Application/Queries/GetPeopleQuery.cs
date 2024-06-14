using ExpertSender.Application.Models;
using ExpertSender.Domain.Entities;
using ExpertSender.Infrastructure.Repositories;
using MediatR;

namespace ExpertSender.Application.Queries;

public class GetPeopleQuery : IRequest<List<PersonDetails>>
{
}

public class GetPeopleQueryHandler : IRequestHandler<GetPeopleQuery, List<PersonDetails>>
{
    private readonly IPersonRepository _personRepository;

    public GetPeopleQueryHandler(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task<List<PersonDetails>> Handle(GetPeopleQuery request, CancellationToken cancellationToken)
    {
        var people = await _personRepository.GetAllAsync();

        return people.Select(x => new PersonDetails()
        {
            Id = x.Id,
            FirstName = x.FirstName,
            LastName = x.LastName,
            Description = x.Description,
            Emails = x.Emails.Select(y => new EmailDetails()
            {
                Id = y.Id,
                EmailAddress = y.EmailAddress,
                PersonId = y.PersonId
            }).ToList(),
        }).ToList();
    }
}