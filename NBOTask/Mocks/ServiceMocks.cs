using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Moq;
using NBOTask.Models;
using NBOTask.Services.NBO;
using Newtonsoft.Json.Linq;
using  Bogus;
using Nager.Country;

namespace NBOTask.Mocks
{
    public static class ServiceMocks
    {
        private static ICountryProvider CountryProvider = new CountryProvider();
        public static IProduct[] GetProducts(int? number = 3)
        {
           var faker= new Faker<Product>();
           faker.RuleFor(u => u.Id, f => Guid.NewGuid());
           faker.RuleFor(u => u.Name, f => f.Commerce.ProductName());
           faker.RuleFor(u => u.Description, f => f.Lorem.Text());
           Random rnd = new Random();

            return faker.Generate(rnd.Next(1,number.GetValueOrDefault(3))).Cast<IProduct>().ToArray();
        }
        public static ICustomer[] GetCompanyies(int? number = 3)
        {
            var faker = new Faker<Organization>();

            faker.RuleFor(u => u.Id, f => Guid.NewGuid());
            faker.RuleFor(u => u.Name, f => f.Company.CompanyName());

            faker.RuleFor(u => u.Type, Statics.OrgCustomerType);
            faker.RuleFor(x => x.Addresses, ServiceMocks.GetAddresses());
            faker.RuleFor(x => x.PhoneNumbers, ServiceMocks.GetPhoneNumbers());

            faker.RuleFor(u => u.Identifier,
                (f) => new CodeValue(Statics.NORWEGIAN_ORG_NUMBER, f.Random.String2(9,"0123456789")));
            return faker.Generate(number.GetValueOrDefault(3)).Cast<ICustomer>().ToArray();
        }
        public static List<ICustomer> GetPersons(int? number = 3)
        {
            var faker = new Faker<PrivatePerson>();
            faker.RuleFor(u => u.Id, f => Guid.NewGuid());
            faker.RuleFor(u => u.FirstName, f => f.Person.FirstName);
            faker.RuleFor(u => u.LastName, f => f.Person.LastName);
            faker.RuleFor(u => u.Type, f => Statics.PrivatePersonCustomerType);
            faker.RuleFor(x => x.Addresses, ServiceMocks.GetAddresses());
            faker.RuleFor(x => x.PhoneNumbers, ServiceMocks.GetPhoneNumbers());
            faker.RuleFor(u => u.PersonId, f => Guid.NewGuid());
            faker.RuleFor(u => u.Identifier, f =>
            {
                return new CodeValue(Statics.NORWEGIAN_BIRTHDAY_NUMBER,string.Format("{0}{1}",f.Date.Past().ToString("ddmmdd"),f.Random.String2(5, "0123456789")));
            });





            return faker.Generate(number.GetValueOrDefault(3)).Cast<ICustomer>().ToList();
        }

        public static List<Address> GetAddresses()
        {
            var faker = new Faker<Address>();
            faker.RuleFor(x => x.Country, x => new Country(ServiceMocks.CountryProvider.GetCountry(Alpha2Code.NO)));
            faker.RuleFor(x => x.StreetAddress, (f) => f.Address.StreetAddress());

            return faker.Generate(2);
        }

        public static List<PhoneNumber> GetPhoneNumbers()
        {
            var faker = new Faker<PhoneNumber>();
            faker.RuleFor(x => x.Country, x => new Country(ServiceMocks.CountryProvider.GetCountry(Alpha2Code.NO)));
            faker.RuleFor(x => x.Number, x => x.Phone.PhoneNumberFormat(8));
            return faker.Generate(2);
        }
        public static ICustomer GetCustomer(string customerId)
        {
            Random rnd = new Random();
            if (rnd.Next(0, 1) == 0)
            {
                return ServiceMocks.GetCompanyies(1).First();
            }
            else
            {
                return ServiceMocks.GetPersons(1).First();
            }



        }

        public static List<ISale> GetSales(string customerId,int?number=3)
        {
            var faker = new Faker<Sale>();
            faker.RuleFor(x => x.Products, ServiceMocks.GetProducts(3).ToList());
            faker.RuleFor(x => x.CreatedDate,x=>x.Date.Past());
            faker.RuleFor(x => x.SaleDate, x => x.Date.Past());
            faker.RuleFor(x => x.CustomerId, x => Guid.Parse(customerId));

            return faker.Generate(number.GetValueOrDefault(3)).Cast<ISale>().ToList();
        }
    }
}
