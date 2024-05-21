using TTechBasicInfo.Core.Domain.Common.ValueObjects;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.Domain.ValueObjects;

namespace TTechBasicInfo.Core.Domain.Categories.ValueObjects;

public class CategoryTitle : TinyString
{
    public CategoryTitle(string value)
        : base(value)
    {
        
    }
}
