using TTechBasicInfo.Core.Domain.Common.ValueObjects;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.Domain.ValueObjects;

namespace TTechBasicInfo.Core.Domain.Categories.ValueObjects;

public class CategoryName : TinyString
{
    public CategoryName(string value)
        : base(value)
    {

    }
}