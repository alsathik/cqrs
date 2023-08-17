
using Microsoft.AspNetCore.Mvc;
using RepositoryDesignPattren.CommandQuery;
using RepositoryDesignPattren.Repository;

namespace RepositoryDesignPattren.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly CommandQueryHandler _queryHanler;
        private readonly CustomerCommandHandler _handler;
        public CustomerController(CommandQueryHandler queryHandler,CustomerCommandHandler commandHandler )
        {
            _queryHanler = queryHandler;
            _handler = commandHandler;
        }

        // Query Actions
        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _queryHanler.Handle(new GetAllCustomersQuery());
            return Ok(customers);
        }

        // Command Actions
        [HttpPost]
        public async Task<IActionResult> AddCustomer(AddCustomerCommand command)
        {
            await _handler.Handle(command);
            return Ok();
        }


    }


}