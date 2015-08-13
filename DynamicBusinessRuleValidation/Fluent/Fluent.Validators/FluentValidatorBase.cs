using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;

namespace Fluent.Validators
{
    public abstract class FluentValidatorBase<T>: AbstractValidator<T>
    {
        protected bool ContainTheLetterZ(string data)
        {
            return data.ToLower().Contains("z");
        }

        protected bool ContainTheLetterY(string data)
        {
            return data.ToLower().Contains("y");
        }

        protected bool HaveValue(string data)
        {
            return data != null && data.Trim().Length>0;
        }
    }
}