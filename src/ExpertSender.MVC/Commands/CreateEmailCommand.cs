using ExpertSender.MVC.Models;
using ExpertSender.MVC.Repositories;
using MediatR;

namespace ExpertSender.MVC.Commands;

public class CreateEmailCommand : IRequest<int>
{
    public string EmailAddress { get; set; }
    public int PersonId { get; set; }
}

public class CreateEmailCommandHandler : IRequestHandler<CreateEmailCommand, int>
{
    private readonly IEmailRepository _emailRepository;

    public CreateEmailCommandHandler(IEmailRepository emailRepository)
    {
        _emailRepository = emailRepository;
    }

    public async Task<int> Handle(CreateEmailCommand request, CancellationToken cancellationToken)
    {
        var email = new Email
        {
            EmailAddress = request.EmailAddress,
            PersonId = request.PersonId
        };

        await _emailRepository.AddAsync(email);

        return email.Id;
    }
}