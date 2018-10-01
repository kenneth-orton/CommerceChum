using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeskJockey
{
    [Table("product")]
    public class Product
    {
        [Key]
        [Column("productID")]
        public int productID { get; set; }
        [Column("name")]
        public string name { get; set; }
        [Column("description")]
        public string description { get; set; }
        [Column("price")]
        public double price { get; set; }
        [Column("active")]
        public bool active { get; set; }
    }
}
