using Zamin.Core.RequestResponse.Commands;

namespace TTechBasicInfo.Core.Contracts.Keywords.Commands.DiactivatedKeywords;

public class DeactivateKeywordCommand : ICommand
{
    public int Id { get; set; }
}