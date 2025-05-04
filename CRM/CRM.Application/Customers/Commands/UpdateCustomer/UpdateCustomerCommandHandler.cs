using CRM.Domain.Abstractions;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CRM.Application.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Unit>
    {
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var validationResult = new UpdateCustomerCommandValidator().Validate(request);
            if (!validationResult.IsValid)
            {
                throw new ValidationException("");
            }

            var customer = await _customerRepository.GetByIdAsync(request.Id);
            if (customer == null)
            {
                throw new KeyNotFoundException("مشتری یافت نشد");
            }

            customer.Update(
                request.FirstName,
                request.LastName,
                request.NationalCode,
                request.PhoneNumber,
                request.Email
            );

            _customerRepository.Update(customer);

            return Unit.Value;
        }


    }
}
