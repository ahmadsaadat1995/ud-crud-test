using CRM.Application.Customers.Commands.CreateCustomer;
using Xunit;

namespace CRM.UnitTest
{
    public class CreateCustomerCommandValidatorTests
    {
        [Fact]
        public void Validate_ShouldHaveError_WhenFirstNameIsEmpty()
        {
            var validator = new CreateCustomerCommandValidator();
            var command = new CreateCustomerCommand { FirstName = "" };

            var result = validator.Validate(command);

            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == "FirstName");
        }
    }

}
