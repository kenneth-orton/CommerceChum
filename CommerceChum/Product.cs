using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommerceChum
{
    [Table("product")]
    class Product
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
        [Column("hasSN")]
        public bool hasSN { get; set; }

        public Product()
        {
            this.productID = 0;
            this.name = "";
            this.description = "";
            this.price = 0.0;
            this.active = false;
            this.hasSN = false;
        }

        public Product(int id, string prodName, string desc, double prodPrice, bool dbStatus = true, bool hasSerial = true)
        {
            this.productID = id;
            this.name = prodName;
            this.description = desc;
            this.price = prodPrice;
            this.active = dbStatus;
            this.hasSN = hasSerial;
        }

        public override bool Equals(object obj)
        {
            if (GetType() != obj.GetType())
                return false;

            Product prod = obj as Product;
            return (this.productID == prod.productID && this.name == prod.name && this.description == prod.description 
                    && this.price == prod.price && this.active == prod.active && this.hasSN == prod.hasSN);
        }

        public override int GetHashCode()
        {
            return (productID.GetHashCode() + name.GetHashCode() + description.GetHashCode() + price.GetHashCode() + active.GetHashCode() + hasSN.GetHashCode());
        }
    }
}
