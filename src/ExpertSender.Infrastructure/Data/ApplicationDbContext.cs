using ExpertSender.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpertSender.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<Person> People { get; set; }
    public DbSet<Email> Emails { get; set; }
}