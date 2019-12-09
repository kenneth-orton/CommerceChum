using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommerceApp
{
    [Table("billAddress")]
    class BillAddress
    {
        [Key]
        [Column("customerID")]
        public int customerID { get; set; }
        [Column("billCoName")]
        public string coName { get; set; }
        [Column("billAddr1")]
        public string addr1 { get; set; }
        [Column("billAddr2")]
        public string addr2 { get; set; }
        [Column("billCity")]
        public string city { get; set; }
        [Column("billState")]
        public string state { get; set; }
        [Column("billZip")]
        public string zip { get; set; }
        [Column("billCountry")]
        public string country { get; set; }
        [Column("billPhoneNo")]
        public string phoneNo { get; set; }
        [Required]
        public virtual Customer customer { get; set; }

        public BillAddress()
        {
            this.customerID = 0;
            this.coName = "";
            this.addr1 = "";
            this.addr2 = "";
            this.city = "";
            this.state = "";
            this.zip = "";
            this.country = "";
            this.phoneNo = "";
        }
        
        public BillAddress(int id, string name, string addr1, string addr2, string city, string state, string zip, string country, string phone)
        {
            this.customerID = id;
            this.coName = name;
            this.addr1 = addr1;
            this.addr2 = addr2;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.country = country;
            this.phoneNo = phone;
        }

        public override bool Equals(object obj)
        {
            if (GetType() != obj.GetType())
                return false;

            BillAddress billAddr = obj as BillAddress;
            return (this.customerID == billAddr.customerID && this.coName == billAddr.coName && this.addr1 == billAddr.addr1
                    && this.addr2 == billAddr.addr2 && this.city == billAddr.city && this.state == billAddr.state && this.zip == billAddr.zip
                    && this.country == billAddr.country && this.phoneNo == billAddr.phoneNo);
        }

        public override int GetHashCode()
        {
            return (customerID.GetHashCode() + coName.GetHashCode() + addr1.GetHashCode() + addr2.GetHashCode() + city.GetHashCode()
                    + state.GetHashCode() + zip.GetHashCode() + country.GetHashCode() + phoneNo.GetHashCode());
        }
    }
}
