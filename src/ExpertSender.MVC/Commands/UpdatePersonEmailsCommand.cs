using ExpertSender.MVC.Entities;
using ExpertSender.MVC.Models;
using ExpertSender.MVC.Repositories;
using MediatR;

namespace ExpertSender.MVC.Commands;

public class UpdatePersonEmailsCommand : IRequest
{
    public int Id { get; set; }
    public List<EmailDetails> Emails { get; set; }
}

public class UpdatePersonEmailsCommandHandler : IRequestHandler<UpdatePersonEmailsCommand>
{
    private readonly IPersonRepository _personRepository;
    private readonly IMediator _mediator;

    public UpdatePersonEmailsCommandHandler(IPersonRepository personRepository,
        IMediator mediator)
    {
        _personRepository = personRepository;
        _mediator = mediator;
    }

    public async Task<Unit> Handle(UpdatePersonEmailsCommand request, CancellationToken cancellationToken)
    {
        var person = await _personRepository.GetByIdAsync(request.Id);

        if (person == null)
        {
            throw new KeyNotFoundException("Person not found.");
        }
        
        var existingEmails = person.Emails.ToList();
        foreach (var email in existingEmails)
        {
            if (!request.Emails.Any(e => e.Id == email.Id))
            {
                person.Emails.Remove(email);
            }
        }
        
        foreach (var email in request.Emails)
        {
            var existingEmail = existingEmails.FirstOrDefault(e => e.Id == email.Id);
            if (existingEmail == null)
            {
                email.PersonId = person.Id;
                person.Emails.Add(new Email(){Id = email.Id, Person = person, EmailAddress = email.EmailAddress, PersonId = person.Id});
            }
            else
            {
                existingEmail.EmailAddress = email.EmailAddress;
            }
        }

        await _personRepository.UpdateAsync(person);

        var emailsToRemove = existingEmails.Except(person.Emails);

        foreach (var emailToRemove in emailsToRemove)
        {
            await _mediator.Send(new DeleteEmailCommand(emailToRemove.Id));
        }
        
        return Unit.Value;
    }
}