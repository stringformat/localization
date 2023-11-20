namespace Localization.Domain;

public interface IService
{
    Task CreateQuestion();
    Task<Question?> GetQuestion();
}