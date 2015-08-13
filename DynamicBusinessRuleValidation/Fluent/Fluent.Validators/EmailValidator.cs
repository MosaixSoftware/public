using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using FluentValidation.Results;
using System.Net.Mail;
namespace Fluent.Validators
{
    /*
     * Instead of using a regular expression to validate an email address, you can use the System.Net.Mail.MailAddress class. 
     * To determine whether an email address is valid, pass the email address to the MailAddress.MailAddress(String) class constructor.  (Microsoft)
    */
    public class EmailValidator : FluentValidatorBase<string>
    {
        public EmailValidator()
        {
            RuleFor(vm => vm).Cascade(CascadeMode.StopOnFirstFailure)
                .Must(HaveValue).WithMessage("Email cannot be empty. (From Fluent - EmailValidator")
                .Must(BeValidEmailFormat).WithMessage("The email format is not valid. (From Fluent - EmailValidator)");
        }

        private bool BeValidEmailFormat (string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
            }
            catch (FormatException ex)
            {
                return false;
            }
            return true;
        }
    }
}
