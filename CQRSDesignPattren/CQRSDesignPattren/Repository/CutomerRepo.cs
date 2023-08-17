using Microsoft.EntityFrameworkCore;
using RepositoryDesignPattren.Models;

namespace RepositoryDesignPattren.Repository
{
    public class CutomerRepo : IRepoCustomer
    {
        private readonly SampdbContext _context;
        public CutomerRepo(SampdbContext sampdbContext)
        {
            _context = sampdbContext;
        }

        public async Task<int> AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            var i = await _context.SaveChangesAsync();
            return i;
        }

        public Task UpdateCustomer(Customer customer)
        {
            _context.Update(customer);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public async Task<int> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return 0; // Return 0 to indicate that no customer was found and deleted.
            }

            _context.Customers.Remove(customer);
            var result = await _context.SaveChangesAsync();
            return result;
           // _context.Remove(id);
            //var c = await _context.SaveChangesAsync();
            //return 1;
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            var cust = await _context.Customers.FindAsync(id);
            if (cust == null)
            {
                return null;
            }
            else
            {
                return cust;
            }

        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            var model = await _context.Customers.ToListAsync();
            return model;
        }


    }
}

