using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Fluent.ViewModels;
using System.Net.Mail;

namespace Fluent.API.Controllers
{
    public class ContactUsDataAnnotationsController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Post(ContactUsViewModelDataAnno viewModel)
        {
            if (!ModelState.IsValid)
            {
                var errors = this.ModelState.SelectMany(v => v.Value.Errors.Select(e => new { ErrorMessage = e.ErrorMessage })).ToArray();
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, errors);       
            }

            return this.Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}