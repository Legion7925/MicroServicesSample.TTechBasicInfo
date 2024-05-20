using TTechBasicInfo.Core.Domain.Keywords.Events;
using TTechBasicInfo.Core.Domain.Keywords.ValueObjects;
using Zamin.Core.Domain.Entities;
using Zamin.Core.Domain.Exceptions;

namespace TTechBasicInfo.Core.Domain.Keywords.Entities;

public class Keyword : AggregateRoot
{
    #region Properties
    public KeywordStatus Status { get; set; }

    public KeywordTitle Title { get; set; }

    #endregion

    #region Constructors

    public Keyword(KeywordTitle keywordTitle)
    {
        Title = keywordTitle;
        Status = KeywordStatus.Preview;
        AddEvent(new KeywordCreated(BusinessId.Value, Title.Value));
    }

    public Keyword()
    {
    }

    #endregion

    #region Methods 
    public void ChangeTitle(KeywordTitle keywordTitle)
    {
        if(Status == KeywordStatus.Inactive)
        {
            throw new InvalidEntityStateException("InvalidActionInSpecificStatus", nameof(KeywordTitle), nameof(KeywordStatus.Inactive));


        }

        Title = keywordTitle;
        Status = KeywordStatus.Preview;
        AddEvent(new KeywordTitleChanged(BusinessId.Value, keywordTitle.Value));
    }
    
    public void Active()
    {
        if(Status == KeywordStatus.Active)
        {
            throw new InvalidEntityStateException("InvalidActionInSpecificStatus", nameof(KeywordTitle), nameof(KeywordStatus.Active));
        }
        Status = KeywordStatus.Active;
        AddEvent(new KeywordActivated(BusinessId.Value));
    }   

    public void InActive()
    {
        if(Status == KeywordStatus.Inactive)
        {
            throw new InvalidEntityStateException("InvalidActionInSpecificStatus", nameof(Active), nameof(KeywordStatus.Inactive));
        }
        Status = KeywordStatus.Inactive;
        AddEvent(new KeywordActivated(BusinessId.Value));
    }


    #endregion
}
