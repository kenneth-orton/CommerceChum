using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommerceApp
{
    [Table("serialNumbers")]
    class SerialNumber
    {
        [Key, Column(Order = 0)]
        public int orderID { get; set; }
        [Key, Column(Order = 1)]
        public int productID { get; set; }
        [Column("serialNum")]
        public string serialNum { get; set; }
        [Column("closedLoop")]
        public bool closedLoop { get; set; }
        [Column("extIO")]
        public bool extIO { get; set; }
        [Column("analogInputs")]
        public bool anaInputs { get; set; }
        [Column("rigidTap")]
        public bool rigidTap { get; set; }
        [Column("thc")]
        public bool thc { get; set; }
        [Column("macroProg")]
        public bool macroProg { get; set; }
        [Column("threading")]
        public bool threading { get; set; }
        [ForeignKey("orderID")]
        public virtual OrderHistory orderHistory { get; set; }
        [ForeignKey("productID")]
        public virtual Product product { get; set; }

    public SerialNumber()
        {
            this.serialNum = "";
            this.orderID = 0;
            this.productID = 0;
            this.closedLoop = false;
            this.extIO = false;
            this.anaInputs = false;
            this.rigidTap = false;
            this.thc = false;
            this.macroProg = false;
            this.threading = false;
        }

        public SerialNumber(string sn, int ordID, int prodID, bool cl = false, bool exIO = false, bool anInps = false, 
                            bool rTap = false, bool thc = false, bool macro = false, bool thrd = false)
        {
            this.serialNum = sn;
            this.orderID = ordID;
            this.productID = prodID;
            this.closedLoop = cl;
            this.extIO = exIO;
            this.anaInputs = anInps;
            this.rigidTap = rTap;
            this.thc = thc;
            this.macroProg = macro;
            this.threading = thrd;
        }

        public override bool Equals(object obj)
        {
            if (GetType() != obj.GetType())
                return false;

            SerialNumber sn = obj as SerialNumber;
            return (this.orderID == sn.orderID && this.productID == sn.productID && this.closedLoop == sn.closedLoop && this.extIO == sn.extIO
                    && this.rigidTap == sn.rigidTap && this.thc == sn.thc && this.macroProg == sn.macroProg && this.threading == sn.threading
                    && this.anaInputs == sn.anaInputs && this.serialNum == sn.serialNum);
        }

        public override int GetHashCode()
        {
            return (orderID.GetHashCode() + productID.GetHashCode() + closedLoop.GetHashCode() + extIO.GetHashCode() + rigidTap.GetHashCode() +
                    thc.GetHashCode() + macroProg.GetHashCode() + threading.GetHashCode() + anaInputs.GetHashCode() + serialNum.GetHashCode());
        }
    }
}
