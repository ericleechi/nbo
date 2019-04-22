using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NBOTask.Services;

namespace NBOTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerService service;
        public CustomerController(ICustomerService service)
        {
            this.service = service;
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await this.service.FetchCustomers();
            return Ok(customers);
        }
        [HttpGet("lookup")]
        public async Task<IActionResult> Lookup([FromBody] string customerId)
        {
            var customers = await this.service.FetchCustomer(customerId);
            return Ok(customers);
        }

    }
}