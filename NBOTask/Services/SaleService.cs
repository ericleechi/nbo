using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NBOTask.Mocks;
using NBOTask.Models;

namespace NBOTask.Services
{
    public interface ISaleService
    {
            Task<List<ISale>> FetchSales(string customerId);

    }
    public class SaleService : ISaleService
    {
    
    
        public Task<List<ISale>> FetchSales(string customerId)
        {
            return Task.FromResult(ServiceMocks.GetSales(customerId));
        }
    }
}
