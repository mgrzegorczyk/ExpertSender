namespace ExpertSender.MVC.Entities;

public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Description { get; set; }
    public ICollection<Email> Emails { get; set; }
}