using Zamin.Core.Domain.Events;

namespace TTechBasicInfo.Core.Domain.Categories.Events;

public class CategoryCreatedEvent : IDomainEvent
{
    public Guid BusinessId { get; set; }

    public string Title { get; set; }

    public string Name { get; set; }

    public CategoryCreatedEvent(Guid businessId, string title , string name)
    {
        BusinessId = businessId;
        Title = title;
        Name = name;
    }
}
