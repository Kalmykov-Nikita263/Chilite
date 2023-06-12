using Chilite.Domain.Entities;

namespace Chilite.Domain.Repository.Abstractions;

public interface IInterviewsRepository
{
    IAsyncEnumerable<Interview> GetAllInterviewsAsync();

    Task<Interview> GetInterviewByIdAsync(Guid interviewId);

    Task SaveInterviewAsync(Interview interview);

    Task DeleteInterviewAsync(Guid interviewId);
}
