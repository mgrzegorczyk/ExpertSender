using ExpertSender.Domain.Entities;
using ExpertSender.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ExpertSender.Application.Queries;

public record GetExistingEmailsByAddressesQuery(List<string> EmailAddress) : IRequest<List<string>>;

public class GetExistingEmailsByAddressesHandler : IRequestHandler<GetExistingEmailsByAddressesQuery, List<string>>
{
    private readonly IEmailRepository _emailRepository;

    public GetExistingEmailsByAddressesHandler(IEmailRepository emailRepository)
    {
        _emailRepository = emailRepository;
    }

    public async Task<List<string>> Handle(GetExistingEmailsByAddressesQuery request, CancellationToken cancellationToken)
    {
        return await _emailRepository.GetAllQuery()
            .Where(e => request.EmailAddress.Contains(e.EmailAddress))
            .Select(e => e.EmailAddress)
            .ToListAsync();
    }
}