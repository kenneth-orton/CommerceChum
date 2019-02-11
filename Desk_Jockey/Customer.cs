using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeskJockey
{
    [Table("customers")]
    class Customer
    {
        [Key]
        [Column("customerID")]
        public int customerID { get; set; }
        [Column("companyName")]
        public string companyName { get; set; }
        [Column("payTerms")]
        public string payTerms { get; set; }
        [Column("addressSame")]
        public bool addressSame { get; set; }
        [Column("active")]
        public bool active { get; set; }
        public virtual BillAddress billAddress { get; set; }
        public virtual ShipAddress shipAddress { get; set; }

        public Customer()
        {
            this.customerID = 0;
            this.companyName = "";
            this.payTerms = "";
            this.addressSame = true;
            this.active = true;
        }

        public Customer(int id, string name, string terms, bool sameAddr = true, bool status = true)
        {
            this.customerID = id;
            this.companyName = name;
            this.payTerms = terms;
            this.addressSame = sameAddr;
            this.active = status;
        }

        public override bool Equals(object obj)
        {
            if (GetType() != obj.GetType()) 
                return false;

            Customer cust = obj as Customer;
            return (this.customerID == cust.customerID && this.companyName == cust.companyName && this.payTerms == cust.payTerms
                    && this.addressSame == cust.addressSame && this.active == cust.active && this.billAddress.Equals(cust.billAddress)
                    && this.shipAddress.Equals(cust.shipAddress));
        }

        public override int GetHashCode()
        {
            return (customerID.GetHashCode() + companyName.GetHashCode() + payTerms.GetHashCode() + addressSame.GetHashCode() + active.GetHashCode()
                    + billAddress.GetHashCode() + shipAddress.GetHashCode());
        }
    }
}
