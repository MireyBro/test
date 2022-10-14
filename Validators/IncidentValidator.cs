using bART_Solutions_test.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bArt_test.Validators
{
    public class IncidentValidator : AbstractValidator<Incident>
    {
        public IncidentValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty().Length(0, 255).WithMessage("Please specify a valid First Name.");
            RuleFor(x => x.Accounts).NotEmpty().WithMessage("Please specify a valid Accounts.");            
        }
    }
}
