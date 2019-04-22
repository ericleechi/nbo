using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NBOTask.Models.ValuedObjects
{
    public abstract class Entity<T>
    {
        protected Entity()
        {

        }
        protected Entity(T id)
        {
            this.Id = id;
        }
        [JsonProperty]
        public virtual T Id { protected set; get; }

    }
}
