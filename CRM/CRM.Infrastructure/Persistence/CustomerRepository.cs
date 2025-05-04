using CRM.Domain.Abstractions;
using CRM.Domain.Customers;
using Microsoft.EntityFrameworkCore;

namespace CRM.Infrastructure.Persistence
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Customer?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Customers.FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task AddAsync(Customer customer, CancellationToken cancellationToken = default)
        {
            await _context.Customers.AddAsync(customer, cancellationToken);
        }

        public void Update(Customer customer)
        {
            _context.Customers.Update(customer);
        }

        public void Delete(Customer customer)
        {
            _context.Customers.Remove(customer);
        }
        public async Task DeleteAsync(Guid id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                throw new KeyNotFoundException("مشتری پیدا نشد");
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }


        public async Task<bool> ExistsAsync(NationalCode nationalCode, CancellationToken cancellationToken = default)
        {
            return await _context.Customers
                .AnyAsync(c => c.NationalCode.Value == nationalCode.Value, cancellationToken);
        }

        public async Task<IEnumerable<Customer>> GetAll(CancellationToken cancellationToken = default)
        {
            return await _context.Customers.AsNoTracking().ToListAsync(cancellationToken);
        }

    }


}
