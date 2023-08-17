using RepositoryDesignPattren.Repository;
namespace RepositoryDesignPattren.CommandQuery
{
    public class CommandQueryHandler
    {
        private readonly IRepoCustomer _repoCustomer;
        public CommandQueryHandler(IRepoCustomer repoCustomer)
        {
            _repoCustomer = repoCustomer;
        }

        public async Task<IEnumerable<CustomerQueryResult>> Handle(GetAllCustomersQuery query)
        {
            var customers = await _repoCustomer.GetCustomersAsync();
            return customers.Select(c => new CustomerQueryResult
            {
                Id = c.Id,
                First_Name = c.FirstName,
                Last_Name = c.LastName,
                Email = c.Email
            });
        }
        public async Task<CustomerQueryResult> Handle(GetCustomerByIdQuery query)
        {
            var customer = await _repoCustomer.GetCustomerById(query.Id);
            if (customer == null)
            {
                return null;
            }
            return new CustomerQueryResult
            {
                Id = customer.Id,
                First_Name = customer.FirstName,
                Last_Name = customer.LastName,
                Email = customer.Email
            };
        }
    }
}
