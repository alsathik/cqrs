using RepositoryDesignPattren.Models;

namespace RepositoryDesignPattren.Repository
{
    public interface IRepoCustomer
    {
        Task<List<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerById(int id);
        Task<int> AddCustomer(Customer customer);
        Task UpdateCustomer(Customer customer);
        Task<int> DeleteCustomer(int id);
    }
}
