using TTechBasicInfo.Core.Domain.Keywords.ValueObjects;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.Domain.ValueObjects;

namespace TTechBasicInfo.Core.Domain.Common.ValueObjects;

public class TinyString : BaseValueObject<TinyString>
{
    public string Value { get; private set; }

    public static TinyString FromString(string value) => new TinyString(value);

    public TinyString(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidValueObjectStateException("ValidationErrorIsRequire", nameof(TinyString));
        }
        if (value.Length < 2 || value.Length > 50)
        {
            throw new InvalidValueObjectStateException("ValidationErrorStringLength", nameof(TinyString), "2", "50");
        }
        Value = value;
    }

    private TinyString() { }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static explicit operator string(TinyString title) => title.Value;
    public static implicit operator TinyString(string value) => new TinyString(value);

    public override string ToString() => Value;
}
