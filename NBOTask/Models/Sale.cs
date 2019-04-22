using System;
using System.Collections.Generic;

namespace NBOTask.Models
{
    public interface ISale
    {
        Guid CustomerId { set; get; }
        DateTime SaleDate { set; get; }
        DateTime CreatedDate { set; get; }
        List<IProduct> Products { set; get; }
    }

    public class Sale : ISale
    {
        public Sale(ICustomer customer)
        {
            this.CustomerId = customer.Id;

        }

        public Sale(Guid customerId)
        {
            this.CustomerId = customerId;
        }

        public Guid CustomerId { set; get; }
        public DateTime SaleDate { set; get; }
        public DateTime CreatedDate { set; get; }
        public List<IProduct> Products { set; get; }
    }
}
