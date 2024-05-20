using Zamin.Core.Domain.Events;

namespace TTechBasicInfo.Core.Domain.Keywords.Events;

public class KeywordCreated : IDomainEvent
{
    public Guid BusinessId { get; set; }

    public string Title { get; set; }

    public KeywordCreated(Guid businessId , string title)
    {
        BusinessId = businessId;
        Title = title;
    }
}
