using bART_Solutions_test.Domain.Entities;
using FluentValidation;

namespace bArt_test.Validators
{
    public class AccountValidator : AbstractValidator<Account>
    {
        public AccountValidator()
        {            
            RuleFor(x => x.Name).NotEmpty().Length(1, 50).WithMessage("Please specify a valid Name.");
            RuleFor(x => x.Contacts).NotEmpty().WithMessage("Please specify a valid Contacts.");
        }
    }
}
