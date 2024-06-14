using ExpertSender.Domain.Entities;
using ExpertSender.Infrastructure.Repositories;
using MediatR;

namespace ExpertSender.Application.Queries;

public class GetEmailByIdQuery : IRequest<Email>
{
    public int Id { get; set; }
}

public class GetEmailByIdQueryHandler : IRequestHandler<GetEmailByIdQuery, Email>
{
    private readonly IEmailRepository _emailRepository;

    public GetEmailByIdQueryHandler(IEmailRepository emailRepository)
    {
        _emailRepository = emailRepository;
    }

    public async Task<Email> Handle(GetEmailByIdQuery request, CancellationToken cancellationToken)
    {
        return await _emailRepository.GetByIdAsync(request.Id);
    }
}