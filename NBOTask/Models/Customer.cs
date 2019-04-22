using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NBOTask.Models.ValuedObjects;
using Newtonsoft.Json;

namespace NBOTask.Models
{
    public interface ICustomer
    {
        Guid Id { get; }
        string DisplayName { get; }
        CodeValue Type { set; get; }
        CodeValue Identifier { set; get; }
        List<Address> Addresses { set; get; }

        List<PhoneNumber> PhoneNumbers { set; get; }

    }
    public abstract class  Customer :  Entity<Guid>,ICustomer
    {

        public Customer() : base()
        {

        }
        public Customer(Guid id) :base(id)
        {
            this.Id = id;
        }


        public Guid Id { protected set;get; }
        public CodeValue Identifier {  set; get; }
        public CodeValue Type { set; get; }
        public abstract string DisplayName { get; }
        public List<Address> Addresses { set; get; }
        public List<PhoneNumber> PhoneNumbers { set; get; }
    }

    public class Organization : Customer
    {
        public Organization() :base()
        {

        }
        public Organization(Guid id,string name,string org) : base(id)
        {
            this.Name = name;
            this.Identifier = new CodeValue(Statics.NORWEGIAN_ORG_NUMBER,org);
        }
        public string Name { set; get; }
        public override string DisplayName => string.Format("{0}",this.Name) ;
    }

    public class PrivatePerson : Customer
    {

        public PrivatePerson() : base()
        {

        }

        public PrivatePerson(Guid id,string fnr, string firstName, string lastName, string middleName) : base(id)
        {   
            this.Identifier = new CodeValue(Statics.NORWEGIAN_BIRTHDAY_NUMBER,fnr);
            this.FirstName = firstName;
            this.LastName = lastName;
            this.MiddleName = middleName;

        }
     
    
        public string FirstName;
        public string LastName;
        public string MiddleName;
        public Guid PersonId;

        public override string DisplayName => string.Format("{0} {1} {2}", this.FirstName, this.MiddleName, this.LastName);
    }
}
