using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using Newtonsoft.Json;

namespace Fluent.WebAPI
{
    public class ValidationActionFilter : BaseActionFilterAttribute
    {
        // This must run AFTER the FluentValidation filter, which runs as 0
        // It will allow for aggregation of regular Model based validation and it will format the Fluent errors into ones that match ModelState error
        public ValidationActionFilter() : base(1000) { }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var modelState = actionContext.ModelState;

            if (modelState.IsValid) return;

            var errors = actionContext.ModelState.SelectMany(v => v.Value.Errors.Select(e => JsonConvert.DeserializeObject<ValidationFailure>(e.ErrorMessage))).ToArray();

            actionContext.Response = actionContext.Request
                .CreateResponse(HttpStatusCode.BadRequest, errors);
        }
    }


    // The original class from FluentValidation has private setters so we'll create our own to allow us ease of use
    public class ValidationFailure
    {
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorCode { get; set; }
        public object AttemptedValue { get; set; }
        public object CustomState { get; set; }
    }
}
