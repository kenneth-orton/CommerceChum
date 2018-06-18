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

        public static List<Product> getDBProducts()
        {
            List<Product> resultSet = new List<Product>();
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
                                Product product = new Product(reader.GetInt32(0), reader["name"].ToString(), reader["description"].ToString(),
                                                              reader.GetDouble(3), true);
                                resultSet.Add(product);
                            }
                        }
                    }
                }
            }
            return resultSet;
        }

        public static List<Customer> getDBCustomers()
        {
            List<Customer> resultSet = new List<Customer>();
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
                                                                 addrSame, true, billAddress, shipAddress);
                                resultSet.Add(customer);
                            }
                        }
                    }
                }
            }
            return resultSet;
        }


        public static bool partExists(string productName)
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
            return productID > 0;
        }

        public static void insertPart(string partName, string partDesc, double partPrice, bool active = true)
        {
            int activeBit = active ? 1 : 0;
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                string query = "INSERT INTO products(name, description, price, active) VALUES(@name, @description, @price, @active)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", partName);
                    cmd.Parameters.AddWithValue("@description", partDesc);
                    cmd.Parameters.AddWithValue("@price", partPrice);
                    cmd.Parameters.AddWithValue("@active", activeBit);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void updatePart(Product selectedProduct, bool active = true)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                int activeBit = active ? 1 : 0;
                string query = @"UPDATE products SET name=@name, description=@description, 
                                 price=@price, active=@active WHERE productID=@productID";

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@productID", selectedProduct.productID);
                    cmd.Parameters.AddWithValue("@name", selectedProduct.productName);
                    cmd.Parameters.AddWithValue("@description", selectedProduct.productDescription);
                    cmd.Parameters.AddWithValue("@price", selectedProduct.price);
                    cmd.Parameters.AddWithValue("@active", activeBit);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void removePart(Product selectedProduct)
        {
            if (selectedProduct == null)
                return;

            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                string query1 = "DELETE FROM products WHERE name = @name";
                using (SQLiteCommand cmd = new SQLiteCommand(query1, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@name", selectedProduct.productName);
                    cmd.ExecuteNonQuery();
                }
            }

            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                string query2 = "UPDATE products SET productID = productID - 1 where productID > @productID";
                using (SQLiteCommand cmd = new SQLiteCommand(query2, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@productID", selectedProduct.productID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void insertCustomer(Customer customer)
        {
            int addrSame = (bool)customer.addressSame ? 1 : 0;
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                string query = "INSERT INTO customers(customerID, companyName, payTerms, addressSame) VALUES(@cid, @coName, @payTerms, @addrSame)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@cid", customer.customerID);
                    cmd.Parameters.AddWithValue("@coName", customer.companyName);
                    cmd.Parameters.AddWithValue("@payTerms", customer.payTerms);
                    cmd.Parameters.AddWithValue("@addrSame", addrSame);
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
