using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommerceChum
{
    [Table("customers")]
    class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("customerID")]
        public int customerID { get; set; }
        [Column("contactName")]
        public string contactName { get; set; }
        [Column("coName")]
        public string companyName { get; set; }
        [Column("payTerms")]
        public string payTerms { get; set; }
        [Column("addressSame")]
        public bool addressSame { get; set; }
        [Column("active")]
        public bool active { get; set; }
        [Column("specialPricing")]
        public bool specialPricing { get; set; }
        public virtual BillAddress billAddress { get; set; }
        public virtual ShipAddress shipAddress { get; set; }
        //public virtual SpecialPrice specialPrice { get; set; }

        public Customer()
        {
            this.customerID = 0;
            this.contactName = "";
            this.companyName = "";
            this.payTerms = "";
            this.addressSame = true;
            this.active = true;
            specialPricing = true;
        }

        public Customer(int id, string contactName, string coName, string terms, bool sameAddr = true, bool specialPricing = false, bool status = true)
        {
            this.customerID = id;
            this.contactName = contactName;
            this.companyName = coName;
            this.payTerms = terms;
            this.addressSame = sameAddr;
            this.active = status;
            this.specialPricing = specialPricing;
        }

        public override bool Equals(object obj)
        {
            if (GetType() != obj.GetType()) 
                return false;

            Customer cust = obj as Customer;
            return (this.customerID == cust.customerID && this.companyName == cust.companyName && this.payTerms == cust.payTerms
                    && this.addressSame == cust.addressSame && this.active == cust.active && this.billAddress.Equals(cust.billAddress)
                    && this.shipAddress.Equals(cust.shipAddress) && this.contactName == cust.contactName && this.specialPricing == cust.specialPricing);
        }

        public override int GetHashCode()
        {
            return (customerID.GetHashCode() + companyName.GetHashCode() + payTerms.GetHashCode() + addressSame.GetHashCode() + active.GetHashCode()
                    + billAddress.GetHashCode() + shipAddress.GetHashCode() + contactName.GetHashCode() + specialPricing.GetHashCode());
        }
    }
}
