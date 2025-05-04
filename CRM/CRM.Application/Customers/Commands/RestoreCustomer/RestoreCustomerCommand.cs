using MediatR;

namespace CRM.Application.Customers.Commands.RestoreCustomer
{
    public class RestoreCustomerCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public RestoreCustomerCommand(Guid id)
        {
            Id = id;
        }
    }
}
