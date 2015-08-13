using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Fluent.ViewModels;
using System.Net.Mail;
namespace Fluent.API.Controllers
{

    public class ContactUsEmbeddedController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Post(ContactUsViewModel viewModel)
        {
            var errors = new List<dynamic>();

            if (viewModel.FirstName != null && !viewModel.FirstName.ToLower().Contains("z"))
            {
                errors.Add(new { ErrorMessage = "If First Name is provided it must contain the letter z. (From Embedded)"});
            }

            if (viewModel.EmailAddress != null)
            {
                try
                {
                    MailAddress m = new MailAddress(viewModel.EmailAddress);
                }
                catch (FormatException ex)
                {
                    errors.Add(new { ErrorMessage = "The email format is not valid. (From Embedded)" });
                }
            }
            else
            {
                errors.Add(new { ErrorMessage = "The email cannot be left empty. (From Embedded)" });
            }

            if (viewModel.Subject == null)
            {
                errors.Add(new { ErrorMessage = "Subject cannot be left empty. (From Embedded)" });
            }
            else if (viewModel.Subject == "Ravents")
            {
                errors.Add(new { ErrorMessage = "Please provide a subject different than Ravens. (From Embedded)" });
            }

            if (viewModel.Body == null)
            {
                errors.Add(new { ErrorMessage = "Body cannot be left empty. (From Embedded)" });
            }
            else if (viewModel.Body.Length > 2000 || viewModel.Body.Length < 1)
            {
                errors.Add(new { ErrorMessage = "The length of the body must be between 0 and 2000. (From Embedded)" });
            }

            if (
                (((viewModel.FirstName != null && viewModel.FirstName.Trim().Length > 0) //has first name
                  && (viewModel.LastName == null || viewModel.LastName.Trim().Length == 0))) //but not last name
                ||
                (((viewModel.FirstName == null || viewModel.FirstName.Trim().Length == 0)//doesn't have first name
                  && (viewModel.LastName != null && viewModel.LastName.Trim().Length > 0)))//but has last name
                )
            {
                errors.Add(new { ErrorMessage = "If providing First or Last Name, please provide both. (From Embedded)" });
            }

            if (errors.Count > 0)
            {
               return this.Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }

            return this.Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}