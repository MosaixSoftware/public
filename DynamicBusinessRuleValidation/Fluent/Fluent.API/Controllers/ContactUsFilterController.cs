using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Fluent.ViewModels;

namespace Fluent.API.Controllers
{
    public class ContactUsFilterController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Post(ContactUsViewModel viewModel)
        {
            return new OkResult(this);
        }
    }
}
