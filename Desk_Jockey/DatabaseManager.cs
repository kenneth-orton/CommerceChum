﻿using System;
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
                    prod.name = newProduct.name;
                    prod.price = newProduct.price;
                    prod.description = newProduct.description;
                    prod.active = true;
                    context.SaveChanges();
                }
                else
                {
                    context.Products.Add(newProduct);
                    context.SaveChanges();
                }
            }  
        }

        private bool partExists(string productName)
        {
            using (var context = new dbContext())
                return context.Products.Where(p => p.name == productName).Any();
        }

        public void insertCustomer(Customer newCustomer)
        {
            using (var context = new dbContext())
            {
                if (customerExists(newCustomer.companyName))
                {
                    var customer = context.Customers.FirstOrDefault(c => c.companyName == newCustomer.companyName);
                    customer.companyName = newCustomer.companyName;
                }
            }
        }

        public bool customerExists(string companyName)
        {
            using (var context = new dbContext())
                return context.Customers.Where(c => c.companyName == companyName).Any();
        }
    }
}