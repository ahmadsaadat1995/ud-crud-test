using CRM.Domain.Customers;

namespace CRM.Domain.Abstractions
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Customer>> GetAll(CancellationToken cancellationToken = default);
        Task AddAsync(Customer customer, CancellationToken cancellationToken = default);
        void Update(Customer customer);
        //void Delete(Customer customer);
        Task DeleteAsync(Guid id);
        Task<bool> ExistsAsync(NationalCode nationalCode, CancellationToken cancellationToken = default);
    }


}
