namespace Localization.Domain;

public class Service(IRepository repository) : IService
{
    public async Task CreateQuestion()
    {
        var title = new LocalizedString
        {
            new("fr-FR", "Mon titre"),
            new("en-US", "My title")
        };
        
        var question = new Question(title, "Ma description");
        
        await repository.CreateQuestion(question);
    }

    public async Task<Question?> GetQuestion()
    {
        var question = await repository.GetQuestion(Guid.Parse("3bcf497a-4e28-41bb-85f2-6896d66d78ca"), "en-US");

        string test = question!.Title;

        return question;
    }
}