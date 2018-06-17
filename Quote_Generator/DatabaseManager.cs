using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;


namespace DeskJockey
{
    class DatabaseManager
    {
        private static string folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        private static string pathToDB = System.IO.Path.Combine(folder, "sales_manager.db");
        private static string connStr = string.Format("{0}{1}", "DataSource=", pathToDB);

        public static Dictionary<int, List<object>> getDBProducts()
        {
            int i = 0;
            Dictionary<int, List<object>> dbDict = new Dictionary<int, List<object>>();
            
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                string query = "SELECT * FROM products ORDER BY productID;"; 
                using (SQLiteCommand cmd = new SQLiteCommand(query.ToString(), conn))
                {
                    conn.Open();
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.GetInt32(4) == 1) // item is set as active in database
                            {
                                List<object> dbEntries = new List<object>();
                                dbEntries.Add(reader["name"]);
                                dbEntries.Add(reader["description"]);
                                dbEntries.Add(reader["price"]);
                                dbDict[i++] = dbEntries;
                            }
                        }
                    }
                }
            }
            return dbDict;
        }

        public static Dictionary<int, Customer> getDBCustomers()
        {
            int i = 0;
            Dictionary<int, Customer> dbDict = new Dictionary<int, Customer>();

            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                string query = @"SELECT customers.customerID, companyName, payTerms, addressSame, active, billContactName, billAddr1, billAddr2, billCity, billState, 
                                billZip, billCountry, billPhoneNo, shipContactName, shipAddr1, shipAddr2, shipCity, shipState, shipZip, shipCountry, shipPhoneNo
                                FROM customers
                                JOIN billAddress ON customers.customerID = billAddress.customerID 
                                JOIN shipAddress ON customers.customerID = shipAddress.customerID
                                ORDER BY companyName;";
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.GetInt32(4) == 1) // item is set as active in database
                            {
                                BillAddress billAddress = new BillAddress(reader["billContactName"].ToString(), reader["billAddr1"].ToString(), 
                                                                          reader["billAddr2"].ToString(), reader["billCity"].ToString(), reader["billState"].ToString(),
                                                                          reader["billZip"].ToString(), reader["billCountry"].ToString(), reader["billPhoneNo"].ToString());

                                ShipAddress shipAddress = new ShipAddress(reader["shipContactName"].ToString(), reader["shipAddr1"].ToString(),
                                                                          reader["shipAddr2"].ToString(), reader["shipCity"].ToString(), reader["shipState"].ToString(),
                                                                          reader["shipZip"].ToString(), reader["shipCountry"].ToString(), reader["shipPhoneNo"].ToString());

                                bool addrSame = reader.GetInt32(3) != 0;
                                Customer customer = new Customer(reader.GetInt32(0), reader["companyName"].ToString(), reader["payTerms"].ToString(),
                                                                 addrSame, billAddress, shipAddress);
                                dbDict[i++] = customer;
                            }
                        }
                    }
                }
            }
            return dbDict;
        }

        public enum TableID { products, customers, orders };

        public static int getTableSize(TableID table)
        {
            string tableName;
            switch(table)
            {
                case TableID.products:
                    tableName = "products";
                    break;
                case TableID.customers:
                    tableName = "customers";
                    break;
                default:
                    return 0;
            }

            int rowCount;
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                string query = string.Format("SELECT COUNT(*) FROM \"{0}\";", tableName);
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    conn.Open();
                    rowCount = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return rowCount;
        }

        public static int getProductIndex(string productName)
        {
            int productID = 0;
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                string query = string.Format("SELECT * FROM products WHERE name = \"{0}\";", productName);
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    conn.Open();
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productID = reader.GetInt32(0);
                        }
                    }
                }
            }
            return productID - 1;
        }

        public static string getProductDescription(string productName)
        {
            string productDescription = "";
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                string query = string.Format("SELECT description FROM products WHERE name = \"{0}\";", productName);
                using (SQLiteCommand cmd = new SQLiteCommand(query.ToString(), conn))
                {
                    conn.Open();
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productDescription = reader.GetString(0);
                        }
                    }
                }
            }
            return productDescription;
        }

        public static double getProductPrice(string productName)
        {
            double productPrice = 0.0;
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                string query = string.Format("SELECT price FROM products WHERE name = \"{0}\";", productName);
                using (SQLiteCommand cmd = new SQLiteCommand(query.ToString(), conn))
                {
                    conn.Open();
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productPrice = reader.GetDouble(0);
                        }
                    }
                }
            }
            return productPrice;
        }

        public static void insertPart(string partName, string partDesc, double partPrice)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                string query = "INSERT INTO products(name, description, price) VALUES(@name, @description, @price)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", partName);
                    cmd.Parameters.AddWithValue("@description", partDesc);
                    cmd.Parameters.AddWithValue("@price", partPrice);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void updatePart(string partName, string partDesc, double partPrice, bool active)
        {
            int index = getProductIndex(partName) + 1;
            if (index < 1)
                return;

            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                int activeBit = active ? 1 : 0;
                string query = @"UPDATE products SET name=@name, description=@description, 
                                 price=@price, active=@active WHERE productID=@productID";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", partName);
                    cmd.Parameters.AddWithValue("@description", partDesc);
                    cmd.Parameters.AddWithValue("@price", partPrice);
                    cmd.Parameters.AddWithValue("@active", activeBit);
                    cmd.Parameters.AddWithValue("@productID", index);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void removePart(string partName)
        {
            int index = getProductIndex(partName) + 1;
            if (index < 1)
                return;

            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                string query1 = "DELETE FROM products WHERE name = @name";
                using (SQLiteCommand cmd = new SQLiteCommand(query1, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@name", partName);
                    cmd.ExecuteNonQuery();
                }
            }

            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                string query2 = "UPDATE products SET productID = productID - 1 where productID > @productID";
                using (SQLiteCommand cmd = new SQLiteCommand(query2, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@productID", index);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //public static void insertCustomer(int customerID, string payTerms, bool addressSame, string[] billingAddress, string[] shippingAddress = null)
        public static void insertCustomer(Customer customer)
        {
            //int addrSame = (bool)customer.addressSame ? 1 : 0;
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                string query = "INSERT INTO customers(customerID, companyName, payTerms) VALUES(@cid, @coName, @payTerms)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@cid", customer.customerID);
                    cmd.Parameters.AddWithValue("@coName", customer.companyName);
                    cmd.Parameters.AddWithValue("@payTerms", customer.payTerms);
                    //cmd.Parameters.AddWithValue("@addrSame", customer.addrSame);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                query = @"INSERT INTO billAddress(customerID, contactName, address1, 
                                                  address2, city, state, zip, country, phoneNo) 
                          VALUES(@cid, @cname, @addr1, @addr2, @city, @state, @zip, @country, @phoneNo)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@cid", customer.customerID);
                    cmd.Parameters.AddWithValue("@cname", customer.billAddress.contactName);
                    cmd.Parameters.AddWithValue("@addr1", customer.billAddress.addr1);
                    cmd.Parameters.AddWithValue("@addr2", customer.billAddress.addr2);
                    cmd.Parameters.AddWithValue("@city", customer.billAddress.city);
                    cmd.Parameters.AddWithValue("@state", customer.billAddress.state);
                    cmd.Parameters.AddWithValue("@zip", customer.billAddress.zip);
                    cmd.Parameters.AddWithValue("@country", customer.billAddress.country);
                    cmd.Parameters.AddWithValue("@phoneNo", customer.billAddress.phoneNo);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                query = @"INSERT INTO shipAddress(customerID, contactName, address1, 
                                                  address2, city, state, zip, country, phoneNo) 
                          VALUES(@cid, @cname, @addr1, @addr2, @city, @state, @zip, @country, @phoneNo)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@cid", customer.customerID);
                    cmd.Parameters.AddWithValue("@cname", customer.shipAddress.contactName);
                    cmd.Parameters.AddWithValue("@addr1", customer.shipAddress.addr1);
                    cmd.Parameters.AddWithValue("@addr2", customer.shipAddress.addr2);
                    cmd.Parameters.AddWithValue("@city", customer.shipAddress.city);
                    cmd.Parameters.AddWithValue("@state", customer.shipAddress.state);
                    cmd.Parameters.AddWithValue("@zip", customer.shipAddress.zip);
                    cmd.Parameters.AddWithValue("@country", customer.shipAddress.country);
                    cmd.Parameters.AddWithValue("@phoneNo", customer.shipAddress.phoneNo);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
