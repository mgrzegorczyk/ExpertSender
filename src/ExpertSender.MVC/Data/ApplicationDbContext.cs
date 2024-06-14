using ExpertSender.MVC.Entities;
using ExpertSender.MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpertSender.MVC.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<Person> People { get; set; }
    public DbSet<Email> Emails { get; set; }
}