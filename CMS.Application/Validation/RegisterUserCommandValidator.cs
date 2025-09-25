using CMS.Application.Features.Authentication.Registration;
using FluentValidation;

namespace CMS.Application.Validation
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            // Rule for the Username
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is required.") 
                .Length(5, 50).WithMessage("Username must be between 5 and 50 characters.")
                .Matches("^[a-zA-Z0-9]*$").WithMessage("Username can only contain letters and numbers.");

            // Rule for the Password
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                .Matches("[0-9]").WithMessage("Password must contain at least one number.")
                .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First Name is required.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last Name is required.");
        }
    }
}