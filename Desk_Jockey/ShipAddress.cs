using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeskJockey
{
    [Table("shipAddress")]
    class ShipAddress
    {
        [Key]
        [Column("customerID")]
        public int customerID { get; set; }
        [Column("shipContactName")]
        public string contactName { get; set; }
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
            this.contactName = "";
            this.addr1 = "";
            this.addr2 = "";
            this.city = "";
            this.state = "";
            this.zip = "";
            this.country = "";
            this.phoneNo = "";
        }
    }
}