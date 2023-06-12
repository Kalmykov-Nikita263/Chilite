using Chilite.Domain.Repository.Abstractions;

namespace Chilite.Domain;

public class DataManager
{
    public IAnswersRepository AnswersRepository { get; set; }

    public IQuestionsRepository QuestionsRepository { get; set; }

    public IInterviewsRepository InterviewsRepository { get; set; }

    public DataManager(IAnswersRepository answersRepository, IQuestionsRepository questionsRepository, IInterviewsRepository interviewsRepository)
    {
        AnswersRepository = answersRepository;
        QuestionsRepository = questionsRepository;
        InterviewsRepository = interviewsRepository;
    }
}
