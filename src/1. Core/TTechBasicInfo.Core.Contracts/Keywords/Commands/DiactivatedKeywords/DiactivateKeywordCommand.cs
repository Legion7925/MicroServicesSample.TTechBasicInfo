using Zamin.Core.RequestResponse.Commands;

namespace TTechBasicInfo.Core.Contracts.Keywords.Commands.DiactivatedKeywords;

internal class DiactivateKeywordCommand : ICommand
{
    public int Id { get; set; }
}