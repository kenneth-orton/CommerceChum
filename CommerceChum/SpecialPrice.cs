using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommerceChum
{
    [Table("specialPrices")]
    class SpecialPrice
    {
        [Key]
        [Column("customerID")]
        public int customerID { get; set; }
        [Column("productID")]
        public int productID { get; set; }
        [Column("price")]
        public double price { get; set; }
        [ForeignKey("customerID")]
        public virtual Customer customer { get; set; }
        [ForeignKey("productID")]
        public virtual Product product { get; set; }

        public SpecialPrice()
        {
            this.customerID = 0;
            this.productID = 0;
            this.price = 0.0;
        }

        public SpecialPrice(int orderID, int productID, double price)
        {
            this.customerID = orderID;
            this.productID = productID;
            this.price = price;
        }

        public override bool Equals(object obj)
        {
            if (GetType() != obj.GetType())
                return false;

            SpecialPrice pricing = obj as SpecialPrice;
            return (this.customerID == pricing.customerID && this.productID == pricing.productID && this.price == pricing.price);
        }

        public override int GetHashCode()
        {
            return (customerID.GetHashCode() + productID.GetHashCode() + price.GetHashCode());
        }
    }
}