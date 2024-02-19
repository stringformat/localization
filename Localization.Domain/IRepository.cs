using System.Globalization;

namespace Localization.Domain;

public interface IRepository
{
    Task CreateQuestion(Question question);
    Task<Question?> GetQuestion(Guid question);
}