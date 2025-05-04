using CRM.Domain.Abstractions;
using MediatR;

namespace CRM.Application.Customers.Commands.RestoreCustomer
{
    public class RestoreCustomerCommandHandler : IRequestHandler<RestoreCustomerCommand, Unit>
    {
        private readonly ICustomerRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public RestoreCustomerCommandHandler(ICustomerRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(RestoreCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _repository.GetByIdAsync(request.Id);
            if (customer == null)
                throw new KeyNotFoundException("مشتری یافت نشد");

            customer.Restore();
            _repository.Update(customer);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
