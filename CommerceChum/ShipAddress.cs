using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommerceChum
{
    [Table("shipAddress")]
    class ShipAddress
    {
        [Key]
        [Column("customerID")]
        public int customerID { get; set; }
        [Column("shipCoName")]
        public string coName { get; set; }
        [Column("shipAddr1")]
        public string addr1 { get; set; }
        [Column("shipAddr2")]
        public string addr2 { get; set; }
        [Column("shipCity")]
        public string city { get; set; }
        [Column("shipState")]
        public string state { get; set; }
        [Column("shipZip")]
        public string zip { get; set; }
        [Column("shipCountry")]
        public string country { get; set; }
        [Column("shipPhoneNo")]
        public string phoneNo { get; set; }
        [Required]
        public virtual Customer customer { get; set; }

        public ShipAddress()
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

        public ShipAddress(int id, string name, string addr1, string addr2, string city, string state, string zip, string country, string phone)
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

        public ShipAddress(BillAddress billAddr)
        {
            this.customerID = billAddr.customerID;
            this.coName = billAddr.coName;
            this.addr1 = billAddr.addr1;
            this.addr2 = billAddr.addr2;
            this.city = billAddr.city;
            this.state = billAddr.state;
            this.zip = billAddr.zip;
            this.country = billAddr.country;
            this.phoneNo = billAddr.phoneNo;
        }

        public override bool Equals(object obj)
        {
            if (GetType() != obj.GetType())
                return false;

            ShipAddress shipAddr = obj as ShipAddress;
            return (this.customerID == shipAddr.customerID && this.coName == shipAddr.coName && this.addr1 == shipAddr.addr1
                    && this.addr2 == shipAddr.addr2 && this.city == shipAddr.city && this.state == shipAddr.state && this.zip == shipAddr.zip
                    && this.country == shipAddr.country && this.phoneNo == shipAddr.phoneNo);
        }

        public override int GetHashCode()
        {
            return (customerID.GetHashCode() + coName.GetHashCode() + addr1.GetHashCode() + addr2.GetHashCode() + city.GetHashCode()
                    + state.GetHashCode() + zip.GetHashCode() + country.GetHashCode() + phoneNo.GetHashCode());
        }
    }
}