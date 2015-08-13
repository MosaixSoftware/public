using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Fluent.ViewModels
{
    public class ContactUsViewModelDataAnno
    {
        //create a custom ModelState validator to check for the Either Both Or None functionality
        [RegularExpression("[z]", ErrorMessage = "If First Name is provided it must contain the letter z. (From DataAnnotations)")]
        public string FirstName { get; set; }

        //create a custom ModelState validation attribute to check for the Either Both Or None functionality
        public string LastName { get; set; }

        [Required(ErrorMessage = "Subject cannot be left empty. (From DataAnnotations)")]
        //create a custom ModelState validation attribute to check for NotEqualTo
        public string Subject { get; set; }

        [Required(ErrorMessage = "Body cannot be left empty. (From DataAnnotations)")]
        [StringLength(2000, ErrorMessage = "The length of the body must be between 0 and 2000.")]
        public string Body { get; set; }

        [Required(ErrorMessage = "The email cannot be left empty. (From DataAnnotations)")]
        [EmailAddress(ErrorMessage = "The email format is not valid. (From DataAnnotations)")]
        public string EmailAddress { get; set; }
    }
}
