using Chilite.Domain.Entities;
using Chilite.Domain.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Chilite.Domain.Repository.EntityFramework;

public class EFAnswersRepository : IAnswersRepository
{
    private readonly ApplicationDbContext _context;

    public EFAnswersRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task DeleteAnswerAsync(Guid answerId)
    {
        var answer = await GetAnswerByIdAsync(answerId);

        if (answer != null)
        {
            _context.Answers.Remove(answer);
            await _context.SaveChangesAsync();
        }
    }

    public async IAsyncEnumerable<Answer> GetAllAnswersAsync()
    {
        await foreach(var answer in _context.Answers) 
            yield return answer;
    }

    public async Task<Answer> GetAnswerByIdAsync(Guid answerId)
    {
        return await _context.Answers.FirstOrDefaultAsync(a => a.AnswerId == answerId);
    }

    public async Task SaveAnswerAsync(Answer answer)
    {
        if (answer.AnswerId == default)
            _context.Entry(answer).State = EntityState.Added;
        else
            _context.Entry(answer).State = EntityState.Modified;

        await _context.SaveChangesAsync();  
    }
}
