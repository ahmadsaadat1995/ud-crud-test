using CRM.Domain.Customers;
using Xunit;

namespace CRM.UnitTest
{
    public class CustomerTests
    {
        [Fact]
        public void CreateCustomer_ShouldSetAllPropertiesCorrectly()
        {
            var customer = Customer.Create("Ahmad", "saadat", "2540115683", "09301613158", "dev.ahmadsaadat@gmail.com,");

            Assert.Equal("Ahmad", customer.FirstName);
            Assert.Equal("Saadat", customer.LastName);
            Assert.Equal("2540115683", customer.NationalCode.Value);
            Assert.Equal("09301613158", customer.PhoneNumber.Value);
            Assert.Equal("dev.ahmadsaadat@gmail.com", customer.Email.Value);
        }
    }


}
