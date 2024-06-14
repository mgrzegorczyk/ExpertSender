using Bogus;
using ExpertSender.Domain.Entities;
using ExpertSender.Infrastructure.Data;
using Person = ExpertSender.Domain.Entities.Person;

namespace ExpertSender.Infrastructure
{
    public class DataSeeder
    {
        private readonly ApplicationDbContext _context;

        public DataSeeder(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.People.Any())
            {
                return;
            }

            var people = GeneratePeopleWithEmails(30);

            _context.People.AddRange(people);
            _context.SaveChanges();
        }

        private List<Person> GeneratePeopleWithEmails(int numberOfPeople)
        {
            var peopleFaker = new Faker<Person>()
                .RuleFor(p => p.FirstName, f => f.Name.FirstName())
                .RuleFor(p => p.LastName, f => f.Name.LastName())
                .RuleFor(p => p.Description, f => f.Lorem.Sentence());

            var emailFaker = new Faker<Email>()
                .RuleFor(e => e.EmailAddress, f => f.Internet.Email());

            var people = new List<Person>();

            for (int i = 0; i < numberOfPeople; i++)
            {
                var person = peopleFaker.Generate();
                person.Emails = new List<Email>();

                for (int j = 0; j < 3; j++)
                {
                    var email = emailFaker.Generate();
                    person.Emails.Add(email);
                }

                people.Add(person);
            }

            return people;
        }
    }
}