using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TTechBasicInfo.Core.Domain.Keywords.ValueObjects;

namespace TTechBasicInfo.Infrastructure.Data.Sql.Commands.Keywords;

public class KeywordTitleValueConversion : ValueConverter<KeywordTitle, string>
{
    public KeywordTitleValueConversion() : base(c => c.Value, c => KeywordTitle.FromString(c))
    {

    }
}