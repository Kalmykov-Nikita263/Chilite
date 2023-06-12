using Chilite.Domain.Entities;

namespace Chilite.Domain.Repository.Abstractions;

public interface IAnswersRepository
{
    IAsyncEnumerable<Answer> GetAllAnswersAsync();

    Task<Answer> GetAnswerByIdAsync(Guid answerId);

    Task SaveAnswerAsync(Answer answer);

    Task DeleteAnswerAsync(Guid answerId);
}
