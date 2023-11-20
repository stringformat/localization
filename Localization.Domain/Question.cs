namespace Localization.Domain;

public class Question
{
    public Question(LocalizedString title, string description)
    {
        Title = title;
        Description = description;
    }
    
    //ORM
    private Question()
    {
    }

    public Guid Id { get; } = Guid.NewGuid();

    public LocalizedString Title { get; }

    public string Description { get; }
}