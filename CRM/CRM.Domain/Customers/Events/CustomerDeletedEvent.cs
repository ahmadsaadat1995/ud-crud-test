namespace CRM.Domain.Customers.Events
{
    public class CustomerDeletedEvent : BaseDomainEvent
    {
        public Customer Customer { get; }

        public CustomerDeletedEvent(Customer customer)
        {
            Customer = customer;
        }
    }
}
