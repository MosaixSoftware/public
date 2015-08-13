using System;
using System.Web.Http.Dependencies;
using FluentValidation;

namespace Fluent.WebAPI
{
    public interface IScopedValidatorFactory
    {
        /// <summary>
        /// Gets the validator for the specified type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IValidator<T> GetValidator<T>(IDependencyScope scope);

        /// <summary>
        /// Gets the validator for the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        IValidator GetValidator(Type type, IDependencyScope scope);
    }
}
