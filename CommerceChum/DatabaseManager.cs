using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Text;

namespace CommerceChum
{
    class dbContext : DbContext
    {
        private static string folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
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

        public List<OrderHistory> orders
        {
            get
            {
                using (var context = new dbContext())
                    return context.OrderHistory.Select(row => row).Distinct().OrderByDescending(x => x.shipDate).ToList();
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

        public int getNextInvoiceNumber()
        {
            using (var context = new dbContext())
            {
                try
                {
                    nextInvoiceNumber = context.OrderHistory.Max(id => id.orderID);
                }
                catch
                {
                    nextInvoiceNumber = 9995; // new customer invoices start at 10000
                }
            }
            return nextInvoiceNumber + 5;
        }
    }
}
