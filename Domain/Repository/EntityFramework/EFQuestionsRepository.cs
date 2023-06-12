using Chilite.Domain.Entities;
using Chilite.Domain.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Chilite.Domain.Repository.EntityFramework;

public class EFQuestionsRepository : IQuestionsRepository
{
    private readonly ApplicationDbContext _context;

    public EFQuestionsRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task DeleteQuestionAsync(Guid questionId)
    {
        var question = await GetQuestionByIdAsync(questionId);

        if(question != null)
        {
            _context.Questions.Remove(question);   
            await _context.SaveChangesAsync();
        }
    }

    public async IAsyncEnumerable<Question> GetAllQuestionsAsync()
    {
        await foreach (var question in _context.Questions)
            yield return question;
    }

    public async Task<Question> GetQuestionByIdAsync(Guid questionId)
    {
        return await _context.Questions.FirstOrDefaultAsync(q => q.QuestionId == questionId);
    }

    public async Task SaveQuestionAsync(Question question)
    {
        if (question.QuestionId == default)
            _context.Entry(question).State = EntityState.Added;

        else
            _context.Entry(question).State = EntityState.Modified;

        await _context.SaveChangesAsync();
    }
}
