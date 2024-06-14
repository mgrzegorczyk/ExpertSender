using ExpertSender.Application.Lists;
using ExpertSender.Application.Models;
using ExpertSender.Infrastructure.Repositories;
using MediatR;

namespace ExpertSender.Application.Queries;

public class GetPeopleQuery : IRequest<PaginatedList<PersonDetails>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}

public class GetPeopleQueryHandler : IRequestHandler<GetPeopleQuery, PaginatedList<PersonDetails>>
{
    private readonly IPersonRepository _personRepository;

    public GetPeopleQueryHandler(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task<PaginatedList<PersonDetails>> Handle(GetPeopleQuery request, CancellationToken cancellationToken)
    {
        var people = await _personRepository.GetAllAsync();
        
        var personDetailsList = people.Select(x => new PersonDetails()
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
        });

        var count = personDetailsList.Count();
        var items = personDetailsList.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToList();

        return new PaginatedList<PersonDetails>(items, count, request.PageNumber, request.PageSize);
    }
}