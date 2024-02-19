
namespace Localization.Domain;

public class I18nValue : HashSet<I18nValue.CultureAndValue>
{
    private const string DefaultCulture = "fr-FR";

    public I18nValue(string defaultValue)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(defaultValue);
        
        Add(new CultureAndValue(DefaultCulture, defaultValue));
    }

    public string GetValue(string culture)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(culture);
        
        return this.SingleOrDefault(x => x.Culture == culture)?.Value 
               ?? this.Single(x => x.Culture == DefaultCulture).Value;
    }
    
    public void Remove(string culture)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(culture);

        if (culture == DefaultCulture)
            throw new InvalidOperationException();
        
        RemoveWhere(x => x.Culture == culture);
    }

    public void Update(string culture, string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(culture);
        
        RemoveWhere(x => x.Culture == culture);
        Add(new CultureAndValue(culture, value));
    }

    public static implicit operator string(I18nValue localizedString) => localizedString.GetValue(DefaultCulture);
    
    public static implicit operator I18nValue(string localizedString) => new(localizedString);
    
    //ORM
    public I18nValue()
    {
    }
    
    public sealed class CultureAndValue : IEqualityComparer<CultureAndValue>, IEquatable<CultureAndValue>
    {
        public string Culture { get; }
        public string Value { get; }
        

        public CultureAndValue(string culture, string value)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(culture);
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            
            Culture = culture;
            Value = value;
        }

        public bool Equals(CultureAndValue? x, CultureAndValue? y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            return x.GetType() == y.GetType() && string.Equals(x.Culture, y.Culture, StringComparison.OrdinalIgnoreCase);
        }

        public int GetHashCode(CultureAndValue obj)
        {
            return StringComparer.OrdinalIgnoreCase.GetHashCode(obj.Culture);
        }

        public bool Equals(CultureAndValue? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Culture, other.Culture, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object? obj)
        {
            return ReferenceEquals(this, obj) || obj is CultureAndValue other && Equals(other);
        }

        public override int GetHashCode()
        {
            return StringComparer.OrdinalIgnoreCase.GetHashCode(Culture);
        }
    }
}