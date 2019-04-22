using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;
using Nager.Country;
using Newtonsoft.Json;

namespace NBOTask.Models
{
    public struct PostalCode { 
        public string Code;
        public string Place;

    }
    public class Country{
        public Country(ICountryInfo info)
        {
            this.CallingCode = info.CallingCodes.First();
            this.CountryCode = info.Alpha2Code.ToString();
            this.Name = info.OfficialName;
        }

        public string CountryCode { set; get; }
        public string Name { set; get; }

        public string CallingCode { set; get; }
    }
    public class Address : IDisplayAble
    {
        public string StreetAddress { set; get; }
        public string StreetNumber { set; get; }
        public Country Country { set; get; }

        public PostalCode? PostalCode { set; get; }
        public string Display
        {
            set { this.Display = value; }
            get
            {
                if (this.PostalCode.HasValue)
                {
                    return String.Format("{0} {1}, {2} {3}", this.StreetAddress, this.StreetNumber,this.PostalCode.Value.Code,this.PostalCode.Value.Place);
                }
                else
                {
                    return String.Format("{0} {1}", this.StreetAddress, this.StreetNumber);
                }
               
            }
        }
    }

    public class PhoneNumber
    {
        public Country Country { set; get; }
        public string Number { set; get; }
        public CodeValue Type { set; get; }
        public string Display => string.Format("{0} {1}", this.Country.CallingCode, this.Number);
    }

}
