using FluentValidation;
using TTechBasicInfo.Core.Contracts.Categories.Commands.CreateCategories;
using Zamin.Extensions.Translations.Abstractions;

namespace TTechBasicInfo.Core.ApplicationService.Categories.Commands.CreateCategories;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator(ITranslator translator)
    {
        RuleFor(k => k.Title)
          .NotNull().WithMessage(translator["Required", "Title"])
          .MinimumLength(2).WithMessage(translator["MinLength", "Title", "2"])
          .MaximumLength(50).WithMessage(translator["MaxLength", "Title", "50"]);

        RuleFor(k => k.Name)
          .NotNull().WithMessage(translator["Required", "Name"])
          .MinimumLength(2).WithMessage(translator["MinLength", "Name", "2"])
          .MaximumLength(50).WithMessage(translator["MaxLength", "Name", "50"]);
    }
}
