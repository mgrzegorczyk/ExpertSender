namespace ExpertSender.Application.Models;

public class PersonDetails
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Description { get; set; }
    public List<EmailDetails> Emails { get; set; } = new List<EmailDetails>();
}