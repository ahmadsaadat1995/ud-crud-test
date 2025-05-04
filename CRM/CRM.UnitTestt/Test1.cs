using CRM.Application.Customers.Commands.CreateCustomer;
using System.Reflection.Metadata;

namespace CRM.UnitTestt
{
    [TestClass]
    public sealed class Test1
    {
        private CreateCustomerCommandHandler _handler;

        public Test1(/*CreateCustomerCommandHandler handler*/)
        {
            //_handler = handler;
        }

        [TestMethod]
        public async Task Handle_ShouldAddCustomerAndReturnId()
        {
            // Arrange
            var command = new CreateCustomerCommand
            {
                FirstName = "Ahmad",
                LastName = "Saadat",
                NationalCode = "2540115683",
                PhoneNumber = "09301613158",
                Email = "dev.ahmadsaadat@gmail.com"
            };

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            // _repositoryMock.Verify(r => r.AddAsync(It.IsAny<Customer>()), Times.Once); // Uncomment if you want strict behavior
            Assert.IsInstanceOfType(result, typeof(Guid));
        }
    }
}
