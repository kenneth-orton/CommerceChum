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
    }
}
