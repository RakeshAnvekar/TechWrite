using FluentValidation;
using TechWriteServer.Models.Blog;

namespace TechWriteServer.Validators.FluentApiModelValidators;

public class BlogValidator: AbstractValidator<Blog>
{
    public BlogValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .NotNull()
            .WithMessage("Blog title required")
            .Length(5, 500).WithMessage("Blog title must be between 6 and 500 characters long.");

        RuleFor(x => x.Description)
            .NotEmpty()
            .NotNull()
            .WithMessage("Blog description required")
            .Length(20, 100000).WithMessage("Blog description must be between 20 and 100000 characters long.");

        RuleFor(x => x.TagId).NotEmpty().WithMessage("Tag is required");
        RuleFor(x => x.UserId).NotEmpty().WithMessage("User is required");

    }
}
