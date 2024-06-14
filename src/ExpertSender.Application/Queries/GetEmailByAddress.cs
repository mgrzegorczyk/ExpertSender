using ExpertSender.Domain.Entities;
using ExpertSender.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ExpertSender.Application.Queries;

public record GetEmailByAddressQuery(string EmailAddress) : IRequest<Email>;

public class GetEmailAddressQueryHandler : IRequestHandler<GetEmailByAddressQuery, Email?>
{
    private readonly IEmailRepository _emailRepository;

    public GetEmailAddressQueryHandler(IEmailRepository emailRepository)
    {
        _emailRepository = emailRepository;
    }

    public async Task<Email?> Handle(GetEmailByAddressQuery request, CancellationToken cancellationToken)
    {
        return await _emailRepository.GetAllQuery()
            .FirstOrDefaultAsync(x => x.EmailAddress == request.EmailAddress);
    }
}