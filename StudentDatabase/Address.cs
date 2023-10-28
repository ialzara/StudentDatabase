using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDatabase
{
    internal class Address
    {

        private string addressGu;
        private string studentGu;
        private string street1;
        private string street2;
        private string city;
        private string state;
        private string zip;
        private string country;

        public Address(string addressGu, string studentGu, string street1, string street2, string city, string state, string zip, string country)
        {
            this.addressGu = addressGu;
            this.studentGu = studentGu;
            this.street1 = street1;
            this.street2 = street2;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.country = country;
        }



        public string AddressGu { get {  return addressGu; } }
        public string StudentGu { get { return studentGu; } }
        public string Street1 { get {  return street1; } }
        public string Street2 { get {  return street2; } }
        public string City { get { return city; } }
        public string State { get { return state; } }
        public string Zip { get { return zip; } }
        public string Country { get { return country; } }
    }
}
    
    

