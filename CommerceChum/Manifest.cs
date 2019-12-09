using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommerceApp
{
    [Table("manifest")]
    class Manifest
    {
        [Key]
        [Column("orderID")]
        public int orderID { get; set; }
        [Column("productID")]
        public int productID { get; set; }
        [Column("qty")]
        public int qty { get; set; }
        public virtual Product product { get; set; }
        //public virtual OrderHistory order { get; set; }

        public Manifest()
        {
            this.orderID = 0;
            this.productID = 0;
            this.qty = 0;
        }

        public Manifest(int orderID, int productID, int qty)
        {
            this.orderID = orderID;
            this.productID = productID;
            this.qty = qty;
        }

        public override bool Equals(object obj)
        {
            if (GetType() != obj.GetType())
                return false;

            Manifest manifest = obj as Manifest;
            return (this.orderID == manifest.orderID && this.productID == manifest.productID && this.qty == manifest.qty);
        }

        public override int GetHashCode()
        {
            return (orderID.GetHashCode() + productID.GetHashCode() + qty.GetHashCode());
        }
    }
}
