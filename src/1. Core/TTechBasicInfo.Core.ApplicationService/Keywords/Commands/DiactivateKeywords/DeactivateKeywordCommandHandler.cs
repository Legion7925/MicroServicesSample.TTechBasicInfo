using TTechBasicInfo.Core.Contracts.Keywords.Commands.DiactivatedKeywords;
using TTechBasicInfo.Core.Contracts.Keywords.DAL;
using TTechBasicInfo.Core.Domain.Keywords.Entities;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Core.RequestResponse.Common;
using Zamin.Utilities;

namespace TTechBasicInfo.Core.ApplicationService.Keywords.Commands.DiactivateKeywords
{
    public class DeactivateKeywordCommandHandler: CommandHandler<DeactivateKeywordCommand>
    {
        private readonly IKeywordCommandRepository _repository;
        public DeactivateKeywordCommandHandler(ZaminServices zaminServices, IKeywordCommandRepository repository) : base(zaminServices)
        {
            _repository = repository;
        }

        public override async Task<CommandResult> Handle(DeactivateKeywordCommand command)
        {
            Keyword keyword = await _repository.GetGraphAsync(command.Id);

            if (keyword == null)
            {
                AddMessage("ObjectNotFound", nameof(keyword));
                return Result(ApplicationServiceStatus.NotFound);
            }

            keyword.InActive();
            await _repository.CommitAsync();
            return Ok();
        }
    }
}
