using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskJockey
{
    class BillAddress
    {
        public string contactName;
        public string addr1;
        public string addr2;
        public string city;
        public string state;
        public string zip;
        public string country;
        public string phoneNo;

        public BillAddress(){}
        public BillAddress(string contactName, string addr1, string addr2, string city,
                    string state, string zip, string country, string phoneNo)
        {
            this.contactName = contactName;
            this.addr1 = addr1;
            this.addr2 = addr2;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.country = country;
            this.phoneNo = phoneNo;
        }
    }
}
