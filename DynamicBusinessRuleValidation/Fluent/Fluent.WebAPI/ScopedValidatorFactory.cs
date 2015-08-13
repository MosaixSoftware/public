using System;
using System.Web.Http.Dependencies;
using FluentValidation;

namespace Fluent.WebAPI
{
    /// <summary>
    /// Resolves Validators from a Scope
    /// </summary>
    public class ScopedValidatorFactory : IScopedValidatorFactory
    {
        public IValidator<T> GetValidator<T>(IDependencyScope scope)
        {
            return GetValidator(typeof(T), scope) as IValidator<T>;
        }

        public IValidator GetValidator(Type type, IDependencyScope scope)
        {
            return scope.GetService(type) as IValidator;
        }
    }
}
