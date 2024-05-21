using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TTechBasicInfo.Core.Domain.Common.ValueObjects;

namespace TTechBasicInfo.Infrastructure.Data.Sql.Commands.Common;

internal class TinyStringValueConversion : ValueConverter<TinyString, string>
{
    public TinyStringValueConversion() : base(c => c.Value, c => TinyString.FromString(c))
    {

    }
}