using ExpertSender.MVC.Commands;
using ExpertSender.MVC.Models;
using ExpertSender.MVC.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExpertSender.MVC.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IMediator _mediator;

        public PeopleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var people = await _mediator.Send(new GetPeopleQuery());
            return View(people);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePerson person)
        {
            if (ModelState.IsValid)
            {
                var command = new CreatePersonCommand
                {
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Description = person.Description,
                    EmailAddress = person.EmailAddress
                };

                await _mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }

            return View(person);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var person = await _mediator.Send(new GetPersonByIdQuery(id));

            if (person == null)
            {
                return NotFound();
            }
            var personEmails = person.Emails
                .Select(x => new EmailDetails() { Id = x.Id, EmailAddress = x.EmailAddress, PersonId = x.PersonId })
                .ToList();

            var personToEdit = new PersonDetails()
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Description = person.Description,
                Emails = personEmails
            };

            return View(personToEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PersonDetails person)
        {
            if (ModelState.IsValid)
            {
                var updatePersonCommand = new UpdatePersonDetailsCommand
                {
                    Id = person.Id,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Description = person.Description
                };

                await _mediator.Send(updatePersonCommand);
                
                var personEmails = person.Emails
                    .Select(x => new EmailDetails() { Id = x.Id, EmailAddress = x.EmailAddress, PersonId = x.PersonId })
                    .ToList();

                var updatePersonEmailsCommand = new UpdatePersonEmailsCommand
                {
                    Id = person.Id,
                    Emails = personEmails
                };

                await _mediator.Send(updatePersonEmailsCommand);

                return RedirectToAction(nameof(Index));
            }

            return View(person);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var person = await _mediator.Send(new GetPersonByIdQuery(id));

            if (person == null)
            {
                return NotFound();
            }

            var personEmails = person.Emails
                .Select(x => new EmailDetails() { Id = x.Id, EmailAddress = x.EmailAddress, PersonId = x.PersonId })
                .ToList();

            var personDetails = new PersonDetails()
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Description = person.Description,
                Emails = personEmails
            };

            return View(personDetails);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _mediator.Send(new DeletePersonCommand { Id = id });
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _mediator.Send(new GetPersonByIdQuery(id.Value));
            if (person == null)
            {
                return NotFound();
            }
            
            var personEmails = person.Emails
                .Select(x => new EmailDetails() { Id = x.Id, EmailAddress = x.EmailAddress, PersonId = x.PersonId })
                .ToList();

            var personDetails = new PersonDetails()
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Description = person.Description,
                Emails = personEmails
            };

            return View(personDetails);
        }
    }
}