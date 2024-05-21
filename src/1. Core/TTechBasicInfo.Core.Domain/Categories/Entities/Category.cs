using TTechBasicInfo.Core.Domain.Categories.Events;
using TTechBasicInfo.Core.Domain.Categories.ValueObjects;
using Zamin.Core.Domain.Entities;
using Zamin.Core.Domain.Exceptions;

namespace TTechBasicInfo.Core.Domain.Categories.Entities;

public class Category : AggregateRoot
{
    public Category(CategoryName name, CategoryTitle title)
    {
        Title = title;
        Name = name;
        AddEvent(new CategoryCreatedEvent(BusinessId.Value, Title.Value, Name.Value));
    }

    public CategoryTitle Title { get; private set; }

    public CategoryName Name { get; private set; }
}
