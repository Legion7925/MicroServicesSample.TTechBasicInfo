using Zamin.Core.Domain.Events;

namespace TTechBasicInfo.Core.Domain.Keywords.Events;

public class KeywordInActivated : IDomainEvent
{
    public Guid BusinessId { get; set; }

    public KeywordInActivated(Guid businessId)
    {
        BusinessId = businessId;
    }
}
