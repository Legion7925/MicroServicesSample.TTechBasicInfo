using FluentValidation;
using TTechBasicInfo.Core.Contracts.Keywords.Commands.ChangeTitle;
using Zamin.Extensions.Translations.Abstractions;

namespace TTechBasicInfo.Core.ApplicationService.Keywords.Commands.ChangeTitle;

public class ChangeTitleCommandValidator : AbstractValidator<ChangeTitleCommand>
{
    public ChangeTitleCommandValidator(ITranslator translator)
    {
        RuleFor(k => k.Title)
            .NotNull().WithMessage(translator["Required", "Title"])
            .MinimumLength(10).WithMessage(translator["MinLength", "Title", "10"])
            .MaximumLength(50).WithMessage(translator["MaxLength", "Title", "50"]);

    }

}
