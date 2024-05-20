using TTechBasicInfo.Core.Contracts.Keywords.Commands.ChangeTitle;
using TTechBasicInfo.Core.Contracts.Keywords.DAL;
using TTechBasicInfo.Core.Domain.Keywords.Entities;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Core.RequestResponse.Common;
using Zamin.Utilities;

namespace TTechBasicInfo.Core.ApplicationService.Keywords.Commands.ChangeTitle;

public class ChangeTitleCommandHandler : CommandHandler<ChangeTitleCommand>
{
    private readonly IKeywordCommandRepository _repository;
    public ChangeTitleCommandHandler(ZaminServices zaminServices , IKeywordCommandRepository repository) : base(zaminServices)
    {
        _repository = repository;
    }

    public override async Task<CommandResult> Handle(ChangeTitleCommand command)
    {
        Keyword keyword = await _repository.GetGraphAsync(command.Id);

        if(keyword == null)
        {
            AddMessage("Object Not Found" , nameof(keyword));
            return Result(ApplicationServiceStatus.NotFound);
        }

        keyword.ChangeTitle(command.Title);
        await _repository.CommitAsync();
        return Ok();
    }
}
