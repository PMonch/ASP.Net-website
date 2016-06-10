using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using WebsiteGame.Models.exceptions;

namespace WebsiteGame.Models
{
    public class WebsiteGameRepository : IWebsiteGameRepository
    {
        private string connectionstring = "User id = Sillaatjuh; Password = apw6zq-; Data source =127.0.0.1";
        List<Product> products;
       
        //Get all products
        public List<Product> GetAllProducts()
        {
            products = new List<Product>();
            try
            {
                var conn = new OracleConnection(connectionstring);

                using (conn)
                {
                    conn.Open();

                    var command = new OracleCommand("SELECT * FROM Product", conn);
                    command.CommandType = CommandType.Text;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var productID = reader["ID"].ToString();
                            var productType = reader["ProductType"].ToString();
                            var productName = reader["NAME"].ToString();
                            var productDescription = reader["Description"].ToString();
                            var productPrice = Convert.ToDecimal(reader["Price"]);

                            Product p = new Product(productType, productName, productDescription, productPrice);
                            products.Add(p);
                            
                        }
                        conn.Close();
                    }

                }
            }
            catch
            {
                throw new DatabaseConnectionException("Database Error");
            }
            return products;
        }

        //get products with a certain categorie
        public List<Product> GetProductCategorie(string ProductType)
        {
            products = new List<Product>();
            try
            {
                var conn = new OracleConnection(connectionstring);

                using (conn)
                {
                    conn.Open();

                    var command = new OracleCommand("SELECT * FROM Product WHERE ProductType = '"+ ProductType + "'", conn);
                    command.CommandType = CommandType.Text;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var productID = reader["ID"].ToString();
                            var productType = reader["ProductType"].ToString();
                            var productName = reader["NAME"].ToString();
                            var productDescription = reader["Description"].ToString();
                            var productPrice = Convert.ToDecimal(reader["Price"]);

                            Product p = new Product(productType, productName, productDescription, productPrice);
                            products.Add(p);
                          
                        }
                        conn.Close();
                    }

                }
            }
            catch
            {
                throw new DatabaseConnectionException("Database Error");
            }
            return products;
        }

        //add an account
        public bool AddNewAccount(Account account)
        {

            try
            {
                using (OracleConnection connection = new OracleConnection(connectionstring))
                {
                  
                   
                    OracleCommand cmd = new OracleCommand("insert into Account values( accountID.NEXTVAL, '', '" + account.Username + "', '" + account.Password + "', '" + account.Gender + "', '" + account.Email + "','" + account.PhoneNumber + "','" + account.Address + "','" + account.Zipcode + "', '" + account.City + "')", connection);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                    
                }
              
            }
            catch
            {
                throw new DatabaseConnectionException("Database Error");
            }
            return true;
        }

        //login
        public bool Login(string username, string password)
        {
            try
            {
                var conn = new OracleConnection(connectionstring);

                using (conn)
                {
                    conn.Open();

                    var command = new OracleCommand("SELECT Username, Password FROM Account WHERE username = '" + username + "'", conn);
                    command.CommandType = CommandType.Text;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var Username = reader["Username"].ToString();
                            var Password = reader["Password"].ToString();
                            if(Username == username && Password==password)
                            {
                                return true;
                            }
                        }
                    }
                    conn.Close();

                }
            }
            catch
            {
                throw new DatabaseConnectionException("Database Error");
               
            }
            return false;
        }
    }
}