using FluentValidation;
using TTechBasicInfo.Core.Contracts.Keywords.Commands.CreateKeywords;
using TTechBasicInfo.Core.Domain.Keywords.ValueObjects;
using Zamin.Extensions.Translations.Abstractions;

namespace TTechBasicInfo.Core.ApplicationService.Keywords.Commands.CreateKeywords;

public class CreateKeywordCommandValidator : AbstractValidator<CreateKeywordCommand>
{
    public CreateKeywordCommandValidator(ITranslator translator)
    {
        RuleFor(k => k.Title)
            .NotNull().WithMessage(translator["Required", "Title"])
            .MinimumLength(10).WithMessage(translator["MinLength", "Title", "10"])
            .MaximumLength(50).WithMessage(translator["MaxLength", "Title", "50"]);

    }
}
