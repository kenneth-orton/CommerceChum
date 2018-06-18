using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskJockey
{
    // TODO: implement a list for convenience
    class Customer
    {
        public int customerID;
        public string companyName;
        public string payTerms;
        public bool addressSame;
        public bool active;
        public BillAddress billAddress;
        public ShipAddress shipAddress;
        public Customer() {}

        public Customer(int customerID, string companyName, string payTerms, bool addressSame, bool active,
                        BillAddress billAddress, ShipAddress shipAddress)
        {
            this.customerID = customerID;
            this.companyName = companyName;
            this.payTerms = payTerms;
            this.addressSame = addressSame;
            this.billAddress = billAddress;
            this.shipAddress = shipAddress;
        }
    }
}
