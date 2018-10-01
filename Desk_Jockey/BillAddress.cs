using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeskJockey
{
    [Table("billAddress")]
    class BillAddress
    {
        [Key]
        [Column("customerID")]
        public int customerID { get; set; }
        [Column("billContactName")]
        public string contactName { get; set; }
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
    }
}
