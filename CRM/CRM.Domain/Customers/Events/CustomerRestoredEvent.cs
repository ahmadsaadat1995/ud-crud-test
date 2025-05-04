namespace CRM.Domain.Customers.Events
{
    public class CustomerRestoredEvent : BaseDomainEvent
    {
        public Customer Customer { get; }

        public CustomerRestoredEvent(Customer customer)
        {
            Customer = customer;
        }
    }

}
