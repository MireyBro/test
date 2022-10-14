using bART_Solutions_test.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bArt_test.Validators
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().Length(1, 50).WithMessage("Please specify a valid First Name.");
            RuleFor(x => x.LastName).NotEmpty().Length(1, 50).WithMessage("Please specify a valid Last Name.");
            RuleFor(x => x.Email).NotNull().WithMessage("Please specify a valid Email.");
        }
    }
}
