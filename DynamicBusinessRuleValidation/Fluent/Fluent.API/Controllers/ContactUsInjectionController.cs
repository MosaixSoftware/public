using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.UI.WebControls;
using Fluent.ViewModels;
using Fluent.Validators;
using FluentValidation;
using Newtonsoft.Json;

namespace Fluent.API.Controllers
{
    public class ContactUsInjectionController : ApiController
    {
        private readonly IValidator<ContactUsViewModel> _viewModelValidator = null;
        private readonly EmailValidator _emailValidator = null;
        private readonly ContactUsSubjectValidator _subjectValidator = null;

        public ContactUsInjectionController(IValidator<ContactUsViewModel> viewModelVal, EmailValidator emailValidator, ContactUsSubjectValidator subjectValidator)
        {
            _viewModelValidator = viewModelVal;
            _emailValidator = emailValidator;
            _subjectValidator = subjectValidator;
        }

        [HttpPost]
        public HttpResponseMessage Post(ContactUsViewModel viewModel)
        {
            //wrapping in try/catch because the chaining extenssion method throws a validation exception 
            try
            {
                //Using the ChainValidate extension allows us chain the execution of multiple validators regardless if they are related or not
                //Don't forget to call this in Try/Catch block and to interrogate the last result!!
                //NOTE: THE CURRENT SETUP DOES NOT ALLOW FOR ACCUMULATION OF ERRORS!! It is, however, easily achievable
                _viewModelValidator.Validate(viewModel)
                    .ChainValidate(_emailValidator, viewModel.EmailAddress)
                    .ChainValidate(_subjectValidator, viewModel.Subject);
            }
            catch (ValidationException ex)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, ex.Errors.ToValidationFailureList());
            }


            return this.Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}