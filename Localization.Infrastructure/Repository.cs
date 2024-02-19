using Localization.Domain;
using Microsoft.EntityFrameworkCore;

namespace Localization.Infrastructure;

public class Repository : IRepository
{
    private readonly LocalizationContext _context;

    public Repository(LocalizationContext context)
    {
        _context = context;
    }

    public async Task CreateQuestion(Question question)
    {
        await _context.Set<Question>().AddAsync(question);

        await _context.SaveChangesAsync();
    }

    public async Task<Question?> GetQuestion(Guid id)
    {
        return await _context
            .Set<Question>()
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id == id);
    }
}