using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fluent.ViewModels
{
    public class ContactUsViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string EmailAddress { get; set; }
    }
}