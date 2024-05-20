using TTechBasicInfo.Core.Contracts.Keywords.Commands.CreateKeywords;
using TTechBasicInfo.Core.Contracts.Keywords.DAL;
using TTechBasicInfo.Core.Domain.Keywords.Entities;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Utilities;

namespace TTechBasicInfo.Core.ApplicationService.Keywords.Commands.CreateKeywords;

internal class CreateKeywordCommandHandler : CommandHandler<CreateKeywordCommand, long>
{
    private readonly IKeywordCommandRepository _repository;

    public CreateKeywordCommandHandler(ZaminServices zaminServices , IKeywordCommandRepository repository) : base(zaminServices)
    {
        _repository = repository;
    }

    public override async Task<CommandResult<long>> Handle(CreateKeywordCommand command)
    {
        Keyword keyword = new(command.Title);
        await _repository.InsertAsync(keyword);
        await _repository.CommitAsync();
        return Ok(keyword.Id);
    }
}
