using NUnit.Framework;
using Fluent.ViewModels;
using Fluent.Validators;

namespace FluentTests
{
    [TestFixture]
    public class FluentViewModelTests
    {
        [TestFixtureSetUp]
        public void Init()
        {}

        [TestCase]
        public void ContactUs_FirstNameOnly()
        {
            var contactUsVM = new ContactUsViewModel { 
                FirstName = "Test",
                LastName = "",
                EmailAddress = "test@test.com",
                Subject = "Subject",
                Body = "Body"
            };

            var contactUsVal = new ContactUsValidator(new EmailValidator());
            var valResult = contactUsVal.Validate(contactUsVM);

            Assert.IsTrue(!valResult.IsValid);
        }

        [TestCase]
        public void Email_Valid()
        {
            string email = "test@test.com";
            var emailVal = new EmailValidator();
            var valResult = emailVal.Validate(email);

            Assert.IsTrue(valResult.IsValid);
        }

        [TestCase]
        public void Email_Invalid()
        {
            string email = "test_test.com";
            var emailVal = new EmailValidator();
            var valResult = emailVal.Validate(email);

            Assert.IsTrue(!valResult.IsValid);
        }


        [TestFixtureTearDown]
        public void Cleanup()
        { /* ... */ }
    }
}
