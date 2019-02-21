using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DeskJockey
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

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<BillAddress> BillAddresses { get; set; }
        public DbSet<ShipAddress> ShipAddresses { get; set; }
        public DbSet<OrderHistory> OrderHistory { get; set; }
        public DbSet<Manifest> Manifest { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

    class DatabaseManager
    {
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

        private bool partExists(string productName)
        {
            using (var context = new dbContext())
                return context.Products.Where(p => p.name == productName).Any();
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
                    newCustomer.customerID = customer.customerID;
                    if (!customer.Equals(newCustomer))
                        customer = newCustomer;
                }
                else
                    context.Customers.Add(newCustomer);

                context.SaveChanges();
            }
        }

        private bool customerExists(string companyName)
        {
            using (var context = new dbContext())
                return context.Customers.Where(c => c.companyName == companyName).Any();
        }

        public static int getNextInvoiceNumber()
        {
            int lastOrderID = 0;

            using (var context = new dbContext())
            {
                try
                {
                    lastOrderID = context.OrderHistory.Max(id => id.orderID);
                }
                catch
                {
                    lastOrderID = 9995; // new customer invoices start at 10000
                }
            }

            return lastOrderID + 5;
        }
    }
}
