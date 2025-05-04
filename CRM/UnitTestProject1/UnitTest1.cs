using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CRM.UnitTest
{
    [TestClass]
    public class CreateCustomerCommandHandlerTests
    {
        private Mock<ICustomerRepository> _repositoryMock;
        private CreateCustomerCommandHandler _handler;

        //[TestInitialize]
        //public void Setup()
        //{
        //    _repositoryMock = new Mock<ICustomerRepository>();
        //    _handler = new CreateCustomerCommandHandler(_repositoryMock.Object);
        //}

        public CreateCustomerCommandHandlerTests()
        {
            
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
            Assert.IsInstanceOfType(result, typeof(Guid));
        }
    }
}
