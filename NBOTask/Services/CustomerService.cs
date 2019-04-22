using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NBOTask.Mocks;
using NBOTask.Models;

namespace NBOTask.Services
{
    public interface ICustomerService
    {
        Task<List<ICustomer>> FetchCustomers();

        Task<ICustomer> FetchCustomer(string customerId);
    }
    public class CustomerService : ICustomerService
    {
       
        public Task<List<ICustomer>> FetchCustomers()
        {
            return Task.FromResult( ServiceMocks.GetCompanyies().Concat(ServiceMocks.GetPersons()).ToList());
        }
        public Task<ICustomer> FetchCustomer(string customerId)
        {
            return Task.FromResult(ServiceMocks.GetCustomer(customerId));
        }


    }
}
