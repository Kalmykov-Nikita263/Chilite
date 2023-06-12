using Chilite.Domain.Entities;

namespace Chilite.Domain.Repository.Abstractions;

public interface IQuestionsRepository
{
    IAsyncEnumerable<Question> GetAllQuestionsAsync();

    Task<Question> GetQuestionByIdAsync(Guid questionId);

    Task SaveQuestionAsync(Question question);

    Task DeleteQuestionAsync(Guid questionId);
}
