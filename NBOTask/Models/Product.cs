using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NBOTask.Models.ValuedObjects;
using Newtonsoft.Json;

namespace NBOTask.Models
{
    public interface IProduct
    {

        Guid Id { get; }
        string Name { get; }
        string Description { get; }
        CodeValue Type { get; }

    }
    public class Product : Entity<Guid>, IProduct
    {
        public Product() : base()
        {

        }
        public Product(Guid id, string name, string description) : base(id)
        {
            this.Name = name;
            this.Description = description;
        }

        public CodeValue Type { set; get; }
        public string Name {  set; get; }
        public string Description { set; get; }


    }
}
