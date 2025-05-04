namespace CRM.Domain.Customers.Events
{
    public abstract class BaseDomainEvent
    {
        public DateTime OccurredOn { get; } = DateTime.UtcNow;
    }
}
