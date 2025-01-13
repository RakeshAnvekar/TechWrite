namespace TechWriteServer.Validators.FluentApiModelValidators;
using FluentValidation;
using TechWriteServer.Models.User;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {     

        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("User name is required")
            .NotNull().WithMessage("User name is required")
            .Length(5, 20).WithMessage("User name must be between 6 and 20 characters long.");


        RuleFor(x => x.UserEmailId)
            .EmailAddress()
            .NotNull().WithMessage("Email Address is required")
            .NotEmpty().WithMessage("Email Address is required");


        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required")
            .NotNull().WithMessage("Password is required")
            .Matches("^[a-zA-Z0-9]*$").WithMessage("Password can only contain letters and digits, no spaces allowed.")
            .Length(6, 20).WithMessage("Password must be between 6 and 20 characters long.");


        RuleFor(x => x.ConfirmPassword)
            .NotEmpty().WithMessage("Confirm Password is required")
            .NotNull().WithMessage("Confirm Password is required")
            .Matches("^[a-zA-Z0-9]*$").WithMessage("Confirm Password can only contain letters and digits, no spaces allowed.")
            .Length(6, 20).WithMessage("Confirm Password must be between 6 and 20 characters long.")
            .Equal(x => x.Password).WithMessage("Password and Confirm Password should match.");
    }

  
}
