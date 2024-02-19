namespace Localization.Domain;

public class Question
{
    private Question()
    {
    }

    public Question(I18nValue? title, string description)
    {
        Title = title;
        Description = description;
    }

    public Guid Id { get; } = Guid.NewGuid();

    public I18nValue Title { get; }

    public string Description { get; }
}