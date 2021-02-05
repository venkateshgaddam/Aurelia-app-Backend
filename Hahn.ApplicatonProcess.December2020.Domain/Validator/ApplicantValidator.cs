using FluentValidation;
using Hahn.ApplicatonProcess.December2020.Domain.Model;

namespace Hahn.ApplicatonProcess.December2020.Domain.Validator
{
    public class AddApplicantValidator : AbstractValidator<AddApplicant>
    {
        public AddApplicantValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .Must(a => a.Length >= 5)
                .WithMessage("Name should be a minimum of 5 charecters . Please Check again!!");

            RuleFor(a => a.FamilyName)
                .NotEmpty()
                .WithMessage("Family Name is required")
                .Must(a => a.Length >= 5)
                .WithMessage("FamilyName should be a minimum of 5 charecters. Please Check again!!");

            RuleFor(a => a.Address)
                .NotEmpty()
                .WithMessage("Address is required")
                .Must(a => a.Length >= 10)
                .WithMessage("Address should be a minimum of 10 charecters. Please Check again!!");

            RuleFor(a => a.Age)
                .InclusiveBetween(20, 60)
                .WithMessage("InValid Age. Age Should be in between 20 and 60");

            RuleFor(a => a.EmailAddress)
                .NotEmpty()
                .WithMessage("Email address is required")
                .EmailAddress()
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
                .WithMessage("A valid email is required");

            RuleFor(a => a.Hired)
                .NotNull()
                .WithMessage("Valid response needed for Hired Property.");
        }
    }

    public class UpdateApplicantValidator : AbstractValidator<UpdateApplicant>
    {
        public UpdateApplicantValidator()
        {
            RuleFor(a => a.ID)
                .NotEmpty()
                .WithMessage("ID is required")
                .Must(a => a > 0)
                .WithMessage("Id Should be an Integer")
                .NotNull();
            RuleFor(a => a.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .Must(a => a.Length >= 5)
                .WithMessage("Name should be a minimum of 5 charecters . Please Check again!!");

            RuleFor(a => a.FamilyName)
                .NotEmpty()
                .WithMessage("Family Name is required")
                .Must(a => a.Length >= 5)
                .WithMessage("FamilyName should be a minimum of 5 charecters. Please Check again!!");

            RuleFor(a => a.Address)
                .NotEmpty()
                .WithMessage("Address is required")
                .Must(a => a.Length >= 10)
                .WithMessage("Address should be a minimum of 10 charecters. Please Check again!!");

            RuleFor(a => a.Age)
                .InclusiveBetween(20, 60)
                .WithMessage("InValid Age. Age Should be in between 20 and 60");

            RuleFor(a => a.EmailAddress)
                .NotEmpty()
                .WithMessage("Email address is required")
                .EmailAddress()
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
                .WithMessage("A valid email is required");

            RuleFor(a => a.Hired)
                .NotNull()
                .WithMessage("Valid response needed for Hired Property.");
        }
    }
}
