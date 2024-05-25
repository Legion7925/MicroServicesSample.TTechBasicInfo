using TTechBasicInfo.Core.Contracts.Categories.Commands.CreateCategories;
using TTechBasicInfo.Core.Contracts.Categories.DAL;
using TTechBasicInfo.Core.Domain.Categories.Entities;
using TTechBasicInfo.Core.Domain.Categories.ValueObjects;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Utilities;

namespace TTechBasicInfo.Core.ApplicationService.Categories.Commands.CreateCategories;

public class CreateCategoryCommandHanlder : CommandHandler<CreateCategoryCommand, long>
{
    private readonly ICategoryCommandRepository _repository;

    public CreateCategoryCommandHanlder(ZaminServices zaminServices , ICategoryCommandRepository repository) : base(zaminServices)
    {
        _repository = repository;
    }

    public override async Task<CommandResult<long>> Handle(CreateCategoryCommand command)
    {
        Category category = new(new(command.Name), new(command.Title));
        await _repository.InsertAsync(category);
        await _repository.CommitAsync();
        return Ok(category.Id);
    }
}
