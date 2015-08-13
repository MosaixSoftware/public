using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fluent.ViewModels;
using FluentValidation;
using FluentValidation.Results;

namespace Fluent.Validators
{
    public class ContactUsValidator : FluentValidatorBase<ContactUsViewModel>
    {
        public ContactUsValidator(EmailValidator emailValidator)
        {
            RuleFor(vm => vm.FirstName)
                .Must(ContainTheLetterZ)
                .When(vm => HaveValue(vm.FirstName))
                .WithMessage("If First Name is provided it must contain the letter z. (From Fluent)");


            /* This is commented out so that we can show how the extension method for chaining can be used ... see ContactUsInjectionController.cs lines 31-33
             * As part of the chain, we'll call the EmailValidator and the ContactUsSubjectValidator
             */
            
            //RuleFor(vm => vm.EmailAddress).Cascade(CascadeMode.StopOnFirstFailure)
            //    .NotNull().WithMessage("The email cannot be left empty. (From Fluent)")
            //    .SetValidator(emailValidator);

            //RuleFor(vm => vm.Subject).Cascade(CascadeMode.StopOnFirstFailure)
            //    .NotNull().WithMessage("Subject cannot be left empty. (From Fluent)");
            //    .NotEqual("Ravens").WithMessage("Please provide a subject different than Ravens. (From Fluent)");


            RuleFor(vm => vm.Body).Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Body cannot be left empty. (From Fluent)")
                .Length(0, 2000).WithMessage("The length of the body must be between 0 and 2000. (From Fluent)");

            //TODO: Convert into a custom validator accepting two values and validating that either both or none are provided
            Custom(vm =>
                   {
                       //First Name is provided, but not the Last Name
                       if ((HaveValue(vm.FirstName) && !HaveValue(vm.LastName)) ||
                           //First Name is not provided, but the Last Name is
                           (!HaveValue(vm.FirstName) && HaveValue(vm.LastName)))
                       {
                           return new ValidationFailure("", "If providing First or Last Name, please provide both. (From Fluent)");
                       }
                       return null;
                   });
        }
    }








    //Changed the validation for the first name and body, and show only default error messages created by the framework, other than the custom validators.
    //Changed how email validator is called to show extensibility of the framework via Extensions, Custom, etc.
    //To use, update the dependency injection section in the Global.asax for the IValidator<ContactUsViewModel>
    //We use subjectValidator
    public class ContactUsValidatorDefaultMessages : FluentValidatorBase<ContactUsViewModel>
    {
        public ContactUsValidatorDefaultMessages(ContactUsSubjectValidator subjectValidator)
        {
            RuleFor(vm => vm.FirstName)
                .Must(ContainTheLetterY).WithMessage("First Name must inlcude the letter y.  (From FluentDefaultMessages)")
                .When(vm => HaveValue(vm.FirstName));


            //--- chaining of extension methods ---//
            RuleFor(vm => vm.EmailAddress).Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .MustBeValidEmail()
                .Length(0, 20);  
            //notice how we call the MustBeValidEmail extension here, the extension itself calls the EmailValidator
            //this allows us to chain extension calls... as you can see with the Length(0, 20) call
            //rather than using SetValidator (which doesn't allow chaining), as is in the following line
            

            
            //using the SetValidator option
            RuleFor(vm => vm.Subject).SetValidator(subjectValidator);

            RuleFor(vm => vm.Body).Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .Length(0, 1000);

            //TODO: Convert into a custom validator accepting two values and validating that either both or none are provided
            Custom(vm =>
            {
                //First Name is provided, but not the Last Name
                if ((HaveValue(vm.FirstName) && !HaveValue(vm.LastName)) ||
                    //First Name is not provided, but the Last Name is
                    (!HaveValue(vm.FirstName) && HaveValue(vm.LastName)))
                {
                    return new ValidationFailure("", "If providing First or Last Name, please provide both. (From FluentDefaultMessages)");
                }
                return null;
            });
        }
    }
}