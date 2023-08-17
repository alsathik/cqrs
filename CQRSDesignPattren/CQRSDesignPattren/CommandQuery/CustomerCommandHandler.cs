using RepositoryDesignPattren.Repository;

namespace RepositoryDesignPattren.CommandQuery
{
    public class CustomerCommandHandler
    {
        private readonly IRepoCustomer _repoCustomer;
        public CustomerCommandHandler(IRepoCustomer repoCustomer)
        {
            _repoCustomer = repoCustomer;
        }

        public async Task Handle(AddCustomerCommand command)
        {
            var customer = new Models.Customer
            {
                FirstName = command.First_Name,
                LastName = command.Last_Name,
                Email = command.Email

            };
            await _repoCustomer.AddCustomer(customer);
        }
    }
}
