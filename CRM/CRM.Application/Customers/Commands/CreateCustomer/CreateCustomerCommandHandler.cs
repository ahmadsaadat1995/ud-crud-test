using CRM.Domain.Abstractions;
using CRM.Domain.Customers;
using MediatR;

namespace CRM.Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Guid>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private ICustomerRepository @object;

        public CreateCustomerCommandHandler(ICustomerRepository @object)
        {
            this.@object = @object;
        }

        public CreateCustomerCommandHandler(
            ICustomerRepository customerRepository,
            IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = Customer.Create(
                request.FirstName,
                request.LastName,
                request.NationalCode,
                request.PhoneNumber,
                request.Email);

            await _customerRepository.AddAsync(customer);
            await _unitOfWork.SaveChangesAsync();

            return customer.Id;
        }
    }
}
