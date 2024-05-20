
using Zamin.Core.RequestResponse.Commands;

namespace TTechBasicInfo.Core.Contracts.Keywords.Commands.ChangeTitle;

public class ChangeTitleCommand : ICommand
{
    public int Id { get; set; }
    public string Title { get; set; }
}
