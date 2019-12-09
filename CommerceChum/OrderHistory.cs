using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommerceApp
{
    [Table("orderHistory")]
    class OrderHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("orderID")]
        public int orderID { get; set; }
        [Column("customerID")]
        public int customerID { get; set; }
        [Column("poNum")]
        public string poNum { get; set; }
        [Column("trackNum")]
        public string trackNum { get; set; }
        [Column("shipType")]
        public string shipType { get; set; }
        [Column("shipDate")]
        public DateTime shipDate { get; set; }
        [ForeignKey("customerID")]
        public virtual Customer customer { get; set; }

        public OrderHistory()
        {
            this.orderID = 0;
            this.customerID = 0;
            this.poNum = "";
            this.trackNum = "";
            this.shipType = "";
            shipDate = DateTime.Now; 
        }

        public OrderHistory(int orderID, int customerID, string poNum, string trackNum, string shipType, DateTime shipDate)
        {
            this.orderID = orderID;
            this.customerID = customerID;
            this.poNum = poNum;
            this.trackNum = trackNum;
            this.shipType = shipType;
            this.shipDate = shipDate;
        }

        public override bool Equals(object obj)
        {
            if (GetType() != obj.GetType())
                return false;

            OrderHistory orderHistory = obj as OrderHistory;
            return (this.orderID == orderHistory.orderID && this.customerID == orderHistory.customerID && this.poNum == orderHistory.poNum
                    && this.trackNum == orderHistory.trackNum && this.shipType == orderHistory.shipType && this.shipDate == orderHistory.shipDate);
        }

        public override int GetHashCode()
        {
            return (orderID.GetHashCode() + customerID.GetHashCode() + poNum.GetHashCode() + trackNum.GetHashCode() + shipType.GetHashCode() + shipDate.GetHashCode());
        }
    }
}
