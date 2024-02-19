namespace Localization.Domain;

public class Service(IRepository repository) : IService
{
    public async Task<Question> CreateQuestion()
    {
        var title = new I18nValue("Mon titre par default")
        {
            new("en-US", "My title")
        };
        
        var question = new Question(title, "Ma description");
        
        await repository.CreateQuestion(question);
        return question;
    }

    public async Task<Question?> GetQuestion(Guid id)
    {
        var question = await repository.GetQuestion(id);

        var test = question!.Title.GetValue("en-US");

        string test2 = question.Title;

        return question;
    }
}