namespace Localization.Domain;

public interface IService
{
    Task<Question> CreateQuestion();
    Task<Question?> GetQuestion(Guid id);
}