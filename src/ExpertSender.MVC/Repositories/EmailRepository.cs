using ExpertSender.MVC.Data;
using ExpertSender.MVC.Entities;
using ExpertSender.MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpertSender.MVC.Repositories;

public interface IEmailRepository
{
    Task<List<Email>> GetAllByPersonIdAsync(int personId);
    Task<Email> GetByIdAsync(int id);
    Task AddAsync(Email email);
    Task UpdateAsync(Email email);
    Task DeleteAsync(int id);
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
}