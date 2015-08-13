using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Fluent.Validators
{
    //Developed to show the ChainValidate extension method... I needed something to chain together within the context of the example
    public class ContactUsSubjectValidator : FluentValidatorBase<string>
    {
        public ContactUsSubjectValidator()
        {
            RuleFor(vm => vm).Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Subject cannot be left empty. (From Fluent - ContactUsSubjectValidator)")
                .Must(HaveValue).WithMessage("Subject cannot be left empty. (From Fluent - ContactUsSubjectValidator)")
                .NotEqual("Ravens").WithMessage("Please provide a subject different than Ravens. (From Fluent - ContactUsSubjectValidator)");
        }
    }
}
