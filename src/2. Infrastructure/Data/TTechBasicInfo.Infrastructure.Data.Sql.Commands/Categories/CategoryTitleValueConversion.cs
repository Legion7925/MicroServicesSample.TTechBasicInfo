using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TTechBasicInfo.Core.Domain.Categories.ValueObjects;

namespace TTechBasicInfo.Infrastructure.Data.Sql.Commands.Categories;

public class CategoryTitleValueConversion : ValueConverter<CategoryTitle, string>
{
    public CategoryTitleValueConversion() : base(c => c.Value, c => new CategoryTitle(c))
    {

    }
}
