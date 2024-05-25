using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TTechBasicInfo.Core.Domain.Categories.ValueObjects;
using TTechBasicInfo.Core.Domain.Common.ValueObjects;

namespace TTechBasicInfo.Infrastructure.Data.Sql.Commands.Categories;

public class CategoryNameValueConversion: ValueConverter<CategoryName, string>
{
    public CategoryNameValueConversion() : base(c => c.Value, c => new CategoryName(c))
    {

    }
}
