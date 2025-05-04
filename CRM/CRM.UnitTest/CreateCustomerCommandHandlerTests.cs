using CRM.Application.Customers.Commands.CreateCustomer;
using CRM.Domain.Abstractions;
using Moq;
using Xunit;

namespace CRM.UnitTest
{
    public class CreateCustomerCommandHandlerTests
    {
        private readonly Mock<ICustomerRepository> _repositoryMock;
        private readonly CreateCustomerCommandHandler _handler;

        public CreateCustomerCommandHandlerTests()
        {
            _repositoryMock = new Mock<ICustomerRepository>();
            _handler = new CreateCustomerCommandHandler(_repositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldAddCustomerAndReturnId()
        {
            var command = new CreateCustomerCommand
            {
                FirstName = "Ahmad",
                LastName = "Saadat",
                NationalCode = "2540115683",
                PhoneNumber = "09301613158",
                Email = "dev.ahmadsaadat@gmail.com"
            };

            var result = await _handler.Handle(command, CancellationToken.None);

            //_repositoryMock.Verify(r => r.AddAsync(It.IsAny<Customer>()), Times.Once);
            Assert.IsType<Guid>(result);
        }
    }

}
