using ExpertSender.Domain.Entities;
using ExpertSender.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExpertSender.Infrastructure.Repositories;

public interface IEmailRepository
{
    Task<List<Email>> GetAllByPersonIdAsync(int personId);
    Task<Email> GetByIdAsync(int id);
    Task AddAsync(Email email);
    Task UpdateAsync(Email email);
    Task DeleteAsync(int id);
    public IQueryable<Email> GetAllQuery();
}

public class EmailRepository : IEmailRepository
{
    private readonly ApplicationDbContext _context;

    public EmailRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Email>> GetAllByPersonIdAsync(int personId)
    {
        return await _context.Emails.Where(e => e.PersonId == personId).ToListAsync();
    }

    public async Task<Email> GetByIdAsync(int id)
    {
        return await _context.Emails.FindAsync(id);
    }

    public async Task AddAsync(Email email)
    {
        _context.Emails.Add(email);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Email email)
    {
        _context.Emails.Update(email);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var email = await _context.Emails.FindAsync(id);
        if (email != null)
        {
            _context.Emails.Remove(email);
            await _context.SaveChangesAsync();
        }
    }

    public IQueryable<Email> GetAllQuery()
    {
        return _context.Emails;
    }
}