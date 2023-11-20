namespace Localization.Domain;

public class LocalizedString : List<LocalizedString.CultureAndValue>
{
    public string CurrentValue => this.Single().Value;

    public static implicit operator string(LocalizedString localizedString) => localizedString.CurrentValue;

    public class CultureAndValue
    {
        public CultureAndValue(string culture, string value)
        {
            Culture = culture;
            Value = value;
        }

        public string Culture { get; }
        public string Value { get; }
    }
}