using Zamin.Core.RequestResponse.Commands;

namespace TTechBasicInfo.Core.Contracts.Keywords.Commands.CreateKeywords;

public class CreateKeywordCommand: ICommand<long>
{
    public string Title { get; set; }
}
