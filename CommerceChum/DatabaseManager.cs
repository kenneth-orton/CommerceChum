using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Windows.Forms;

namespace CommerceChum
{
    class dbContext : DbContext
    {
        private static string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private static string pathToDB = System.IO.Path.Combine(folder, "sales_manager.db");
        public dbContext() : base(new SQLiteConnection()
            {
                ConnectionString = new SQLiteConnectionStringBuilder() {
                    DataSource = pathToDB, ForeignKeys = true
                }.ConnectionString
            }, true)
        {
            Database.SetInitializer<dbContext>(null);
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<BillAddress> BillAddresses { get; set; }
        public virtual DbSet<ShipAddress> ShipAddresses { get; set; }
        public virtual DbSet<OrderHistory> OrderHistory { get; set; }
        public virtual DbSet<Manifest> Manifest { get; set; }
        public virtual DbSet<SpecialPrice> SpecialPrices { get; set; } 
        public virtual DbSet<SerialNumber> SerialNumbers { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

    class DatabaseManager
    {
        public int nextInvoiceNumber { get; set; }
        public Customer selectedCustomer { get; set; }

        public List<Product> products
        {
            get
            {
                using (var context = new dbContext())
                    return context.Products.Select(row => row).Where(p => p.active == true).ToList();
            }
        }

        public List<Customer> customers
        {
            get
            {
                using (var context = new dbContext())
                    return context.Customers.Include("BillAddress").Include("ShipAddress").Select(row => row).ToList();
            }
        }

        public List<Product> specialPriceProducts
        {
            get
            {
                List<Product> products = new List<Product>();
                using (var context = new dbContext())
                {
                    var result = (from p in context.Products
                                  join sp in context.SpecialPrices on p.productID equals sp.productID
                                  where p.active == true && sp.customerID == selectedCustomer.customerID
                                  select new { p.productID, p.name, p.description, sp.price, p.active }).ToList();

                    foreach (var item in result)
                        products.Add(new Product(item.productID, item.name, item.description, item.price));

                    return products;
                }
            }
        }

        public List<Product> productsWithSN
        {
            get
            {
                List<Product> products = new List<Product>();
                using (var context = new dbContext())
                {
                    return context.Products.Select(row => row).Where(p => p.active == true && p.hasSN == true).ToList();
                }
            }
        }

        public List<OrderHistory> orders
        {
            get
            {
                using (var context = new dbContext())
                {
                    return context.OrderHistory.Select(row => row).Distinct().OrderByDescending(x => x.shipDate).ToList();
                }
            }
        }

        public void removePart(Product selectedProduct)
        {
            using (var context = new dbContext())
            {
                var prod = context.Products.FirstOrDefault(p => p.name == selectedProduct.name);
                prod.active = false;
                context.SaveChanges();
            }
        }

        public void insertPart(Product newProduct)
        {
            using (var context = new dbContext())
            {
                if (partExists(newProduct.name))
                {
                    var prod = context.Products.FirstOrDefault(p => p.name == newProduct.name);
                    newProduct.productID = prod.productID;
                    if (!prod.Equals(newProduct))
                        prod = newProduct;
                }
                else
                    context.Products.Add(newProduct);

                context.SaveChanges();
            }
        }

        public void insertSpecialPrice(SpecialPrice specialPrice)
        {
            using (var context = new dbContext())
            {
                context.SpecialPrices.Add(specialPrice);
                try
                {
                    context.SaveChanges();
                }
                catch
                {
                    throw new SQLiteException();
                }
            }
        }

        public void insertOrder(OrderHistory newOrder)
        {
            using (var context = new dbContext())
            {
                if (orderExists(newOrder.poNum))
                {
                    var order = context.OrderHistory.FirstOrDefault(o => o.poNum == newOrder.poNum);
                    if (!order.Equals(newOrder))
                    {
                        order.customerID = newOrder.customerID;
                        order.poNum = newOrder.poNum;
                        order.trackNum = newOrder.trackNum;
                        order.shipType = newOrder.shipType;
                        order.shipDate = newOrder.shipDate;
                    }
                }
                else
                    context.OrderHistory.Add(newOrder);

                try
                {
                    context.SaveChanges();
                }
                catch
                {
                    throw new SQLiteException();
                }
            }
        }

        private void deleteOrderRecord(int orderID)
        {
            using (var context = new dbContext())
            {
                var order = context.OrderHistory.FirstOrDefault(o => o.orderID == orderID);
                context.OrderHistory.Remove(order);
                context.SaveChanges();
            }
        }

        private int getOrderID(string poNum)
        {
            using (var context = new dbContext())
            {
                var orderID = context.OrderHistory.FirstOrDefault(o => o.poNum == poNum);
                return orderID.orderID;
            }
        }

        public bool orderExists(string poNum)
        {
            using (var context = new dbContext())
                return context.OrderHistory.Where(o => o.poNum == poNum).Any();
        }

        public int getProductID(string productName)
        {
            if (!partExists(productName))
                return -1;

            using (var context = new dbContext())
            {
                var product = context.Products.FirstOrDefault(p => p.name == productName);
                return product.productID;
            }
        }

        private static bool partExists(string productName)
        {
            using (var context = new dbContext())
                return context.Products.Where(p => p.name == productName).Any();
        }

        public bool customerExists(int customerID)
        {
            using (var context = new dbContext())
                return context.Customers.Where(c => c.customerID == customerID).Any();
        }

        public void removeCustomer(Customer selectedCustomer)
        {
            using (var context = new dbContext())
            {
                var customer = context.Customers.Include("BillAddress").Include("ShipAddress").FirstOrDefault(c => c.companyName == selectedCustomer.companyName);
                customer.active = false;
                context.SaveChanges();
            }
        }

        public void insertCustomer(Customer newCustomer)
        {
            using (var context = new dbContext())
            {
                if (customerExists(newCustomer.companyName))
                {
                    var customer = context.Customers.Include("BillAddress").Include("ShipAddress").FirstOrDefault(c => c.companyName == newCustomer.companyName);

                    if (customer.billAddress == null)
                        customer.billAddress = new BillAddress();
                    if (customer.shipAddress == null)
                        customer.shipAddress = new ShipAddress();

                    newCustomer.customerID = customer.customerID;
                    if (!customer.Equals(newCustomer))
                    {
                        customer.customerID = newCustomer.customerID;
                        customer.contactName = newCustomer.contactName;
                        customer.companyName = newCustomer.companyName;
                        customer.payTerms = newCustomer.payTerms;
                        customer.addressSame = newCustomer.addressSame;
                        customer.specialPricing = newCustomer.specialPricing;
                        customer.billAddress = newCustomer.billAddress;
                        customer.shipAddress = newCustomer.shipAddress;
                    }
                }
                else
                    context.Customers.Add(newCustomer);

                try
                {
                    context.SaveChanges();
                }
                catch
                {
                    throw new SQLiteException();
                }
            }
        }

        private bool customerExists(string companyName)
        {
            using (var context = new dbContext())
                return context.Customers.Where(c => c.companyName == companyName).Any();
        }

        public int getNextInvoiceNumber(Customer selectedCustomer)
        {
            using (var context = new dbContext())
            {
                try
                {
                    nextInvoiceNumber = context.OrderHistory.Where(c => c.customerID == selectedCustomer.customerID).Max(id => id.orderID);
                }
                catch
                {
                    nextInvoiceNumber = 5735; // default start number for invoices
                }
            }
            return nextInvoiceNumber + 5;
        }

        public void insertSN(SerialNumber serialNumber)
        {
            using (var context = new dbContext())
            {
                if (snExists(serialNumber))
                {
                    var sNumber = context.SerialNumbers.FirstOrDefault(sn => sn.serialNum == serialNumber.serialNum);
                    if (!sNumber.Equals(serialNumber))
                    {
                        sNumber.serialNum = serialNumber.serialNum;
                        sNumber.orderID = serialNumber.orderID;
                        sNumber.productID = serialNumber.productID;
                        sNumber.closedLoop = serialNumber.closedLoop;
                        sNumber.extIO = serialNumber.extIO;
                        sNumber.anaInputs = serialNumber.anaInputs;
                        sNumber.rigidTap = serialNumber.rigidTap;
                        sNumber.thc = serialNumber.thc;
                        sNumber.macroProg = serialNumber.macroProg;
                        sNumber.threading = serialNumber.threading;
                    }
                }
                else
                    context.SerialNumbers.Add(serialNumber);

                try
                {
                    context.SaveChanges();
                }
                catch
                {
                    throw new SQLiteException();
                }
            }
        }

        private bool snExists(SerialNumber serialNumber)
        {
            using (var context = new dbContext())
                return context.SerialNumbers.Where(sn => sn.serialNum == serialNumber.serialNum).Any();
        }

        public void removeSerialNumber(string serialNum)
        {
            using (var context = new dbContext())
            {
                var sNum = context.SerialNumbers.FirstOrDefault(s => s.serialNum == serialNum);
                context.SerialNumbers.Remove(sNum);
                context.SaveChanges();
            }
        }

        internal void displayOrderSerials(int orderID, DataGridView dtgvOrderSerials)
        {
            using (var context = new dbContext())
            {
                var custID = context.OrderHistory.FirstOrDefault(o => o.orderID == orderID); 
                var orderHistory = from o in context.OrderHistory
                                   where o.customerID == custID.customerID
                                   orderby o.shipDate descending
                                   select new { o.orderID, o.shipDate };

                var serialNumbers = from s in context.SerialNumbers
                                    join o in orderHistory on s.orderID equals o.orderID
                                    orderby o.shipDate descending
                                    select new { s.orderID, s.productID, o.shipDate, s.serialNum, s.closedLoop, s.extIO, s.anaInputs, s.rigidTap, s.thc, s.macroProg, s.threading };

                var result = (from s in serialNumbers
                              join p in context.Products on s.productID equals p.productID
                              select new { s.orderID, p.name, s.shipDate, s.serialNum, s.closedLoop, s.extIO, s.anaInputs, s.rigidTap, s.thc, s.macroProg, s.threading }).ToList();

                dtgvOrderSerials.DataSource = result;
                dtgvOrderSerials.Columns[0].HeaderCell.Value = "Order ID";
                dtgvOrderSerials.Columns[1].HeaderCell.Value = "Part Name";
                dtgvOrderSerials.Columns[2].HeaderCell.Value = "Ship Date";
                dtgvOrderSerials.Columns[3].HeaderCell.Value = "Serial Number";
                dtgvOrderSerials.Columns[4].HeaderCell.Value = "Closed Loop";
                dtgvOrderSerials.Columns[5].HeaderCell.Value = "Extended IO";
                dtgvOrderSerials.Columns[6].HeaderCell.Value = "Analog Inputs";
                dtgvOrderSerials.Columns[7].HeaderCell.Value = "Rigid Tap";
                dtgvOrderSerials.Columns[8].HeaderCell.Value = "Torch Height Control";
                dtgvOrderSerials.Columns[9].HeaderCell.Value = "Macro Programming";
                dtgvOrderSerials.Columns[10].HeaderCell.Value = "Threading";
            }
        }
    }
}
