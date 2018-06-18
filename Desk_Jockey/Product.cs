using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskJockey
{
    // TODO: implement a list for convenience
    class Product
    {
        public int productID;
        public string productName;
        public string productDescription;
        public double price;
        public bool active;

        public Product() {}

        public Product(int productID, string productName, string productDescription, double price, bool active)
        {
            this.productID = productID;
            this.productName = productName;
            this.productDescription = productDescription;
            this.price = price;
            this.active = active;
        }
        
    }
}
