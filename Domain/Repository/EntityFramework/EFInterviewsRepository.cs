using Chilite.Domain.Entities;
using Chilite.Domain.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Chilite.Domain.Repository.EntityFramework;

public class EFInterviewsRepository : IInterviewsRepository
{
    private readonly ApplicationDbContext _context;

    public EFInterviewsRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task DeleteInterviewAsync(Guid interviewId)
    {
        var interview = await GetInterviewByIdAsync(interviewId);

        if (interview != null)
        {
            _context.Interviews.Remove(interview);
            await _context.SaveChangesAsync();
        }
    }

    public async IAsyncEnumerable<Interview> GetAllInterviewsAsync()
    {
        await foreach(var interview in _context.Interviews)
            yield return interview;
    }

    public async Task<Interview> GetInterviewByIdAsync(Guid interviewId)
    {
        return await _context.Interviews.FirstOrDefaultAsync(i => i.InterviewId == interviewId);
    }

    public async Task SaveInterviewAsync(Interview interview)
    {
        if (interview.InterviewId == default)
            _context.Entry(interview).State = EntityState.Added;

        else
            _context.Entry(interview).State = EntityState.Modified;

        await _context.SaveChangesAsync();
    }
}
