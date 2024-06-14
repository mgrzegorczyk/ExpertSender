using ExpertSender.MVC.Models;
using ExpertSender.MVC.Repositories;
using MediatR;

namespace ExpertSender.MVC.Queries;

public class GetEmailsByPersonIdQuery : IRequest<List<Email>>
{
    public int PersonId { get; set; }
}

public class GetEmailsByPersonIdQueryHandler : IRequestHandler<GetEmailsByPersonIdQuery, List<Email>>
{
    private readonly IEmailRepository _emailRepository;

    public GetEmailsByPersonIdQueryHandler(IEmailRepository emailRepository)
    {
        _emailRepository = emailRepository;
    }

    public async Task<List<Email>> Handle(GetEmailsByPersonIdQuery request, CancellationToken cancellationToken)
    {
        return await _emailRepository.GetAllByPersonIdAsync(request.PersonId);
    }
}