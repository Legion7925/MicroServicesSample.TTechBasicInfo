using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTechBasicInfo.Core.Contracts.Keywords.Commands.ActivateKeywords;
using TTechBasicInfo.Core.Contracts.Keywords.Commands.DiactivatedKeywords;
using TTechBasicInfo.Core.Contracts.Keywords.DAL;
using TTechBasicInfo.Core.Domain.Keywords.Entities;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Core.RequestResponse.Common;
using Zamin.Utilities;

namespace TTechBasicInfo.Core.ApplicationService.Keywords.Commands.ActivateKeywords;

public class ActivateKeywordCommandHandler : CommandHandler<ActivateKeywordCommand>
{
    private readonly IKeywordCommandRepository _repository;
    public ActivateKeywordCommandHandler(ZaminServices zaminServices, IKeywordCommandRepository repository) : base(zaminServices)
    {
        _repository = repository;
    }

    public override async Task<CommandResult> Handle(ActivateKeywordCommand command)
    {
        Keyword keyword = await _repository.GetGraphAsync(command.Id);

        if (keyword == null)
        {
            AddMessage("ObjectNotFound", nameof(keyword));
            return Result(ApplicationServiceStatus.NotFound);
        }

        keyword.Active();
        await _repository.CommitAsync();
        return Ok();
    }
}