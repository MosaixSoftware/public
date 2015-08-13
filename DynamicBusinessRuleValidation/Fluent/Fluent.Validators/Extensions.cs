using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using FluentValidation;
using System.Web.Http.ModelBinding;
using FluentValidation.Results;
using FluentValidation.Validators;

namespace Fluent.Validators
{
    public static class Extensions
    {
        public static IRuleBuilderOptions<T, string> MustBeValidEmail<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new EmailValidator()); //EmailValidator is custom
        }

        public static IList<Fluent.WebAPI.ValidationFailure> ToValidationFailureList(this IEnumerable<FluentValidation.Results.ValidationFailure> list)
        {
            return list.Select(vf => new Fluent.WebAPI.ValidationFailure
            {
                AttemptedValue = vf.AttemptedValue,
                ErrorCode = vf.ErrorCode,
                ErrorMessage = vf.ErrorMessage,
                CustomState = vf.CustomState,
                PropertyName = vf.PropertyName
            }).ToList();
        }

        
        //Make sure you call this inside try block. 
        public static ValidationResult ChainValidate<T>(this ValidationResult previousReusult, IValidator<T> nextValidator, T objectToValidate)
        {
            if (!previousReusult.IsValid)
            {
                throw new ValidationException(previousReusult.Errors);
            }

            var nextValidatorResult = nextValidator.Validate(objectToValidate);
            if (!nextValidatorResult.IsValid)
            {
                throw new ValidationException(nextValidatorResult.Errors);
            }

            return nextValidatorResult;
        }

    }
}
