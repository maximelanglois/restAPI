using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using restapi.Models;

namespace restapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly customerContext _context;

        public CustomersController(customerContext context) => _context = context;

        //Get:              api/customers
        [HttpGet]
        public ActionResult<IEnumerable<customer>> GetCustomers()
        {
            return _context.customers;
        }

        // [HttpGet]
        // public ActionResult<IEnumerable<string>> GetString()
        // {
            // return new string[] {"this", "is", "hard", "coded"};
        // }
    }

}