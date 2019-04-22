using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NBOTask.Models;
using NBOTask.Services;

namespace NBOTask
{
    public static class Statics
    {
        public static CodeValue PrivatePersonCustomerType = new CodeValue("customer", "privatePerson", "Privat person");
        public static CodeValue OrgCustomerType = new CodeValue( "customer", "organization", "Virksomhet");
    

        public static string NORWEGIAN_BIRTHDAY_NUMBER = "identifiers.norwegianBirthDayNumber";
        public static string NORWEGIAN_ORG_NUMBER = "identifiers.norwgianOrgNumber";







    }
}
