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
        private List<Product> products;
        private Account account;

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
                  
                   
                    OracleCommand cmd = new OracleCommand("insert into Account values( accountID.NEXTVAL, '', '" + account.Username + "', '" + account.Password + "', '" + account.Gender + "', '" + account.Email + "','" + account.PhoneNumber + "','" + account.Address + "','" + account.Zipcode + "', '" + account.City + "','"+account.FirstName+"','"+ account.LastName+"')", connection);
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

        public Account GetAccount(string username, string password)
        {
            
            try
            {
                var conn = new OracleConnection(connectionstring);

                using (conn)
                {
                    conn.Open();

                    var command = new OracleCommand("SELECT * FROM Account WHERE username = '" + username + "'", conn);
                    command.CommandType = CommandType.Text;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var Username = reader["Username"].ToString();
                            var Password = reader["Password"].ToString();
                            var Customerscard = reader["CustomersCard_ID"].ToString();
                            var Gender = reader["Gender"].ToString();
                            var Email = reader["Email"].ToString();
                            var PhoneNumber = reader["PhoneNumber"].ToString();
                            var Address = reader["Address"].ToString();
                            var Zipcode = reader["ZipCode"].ToString();
                            var City = reader["City"].ToString();
                            var Firstname = reader["FirstName"].ToString();
                            var Lastname = reader["LastName"].ToString();
                            if (Username == username && Password == password)
                            {
                                account = new Account(Username, password, Email, PhoneNumber, Address, Zipcode, City, Firstname, Lastname, Gender, Customerscard);
                                
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
            return account;
        }

        public bool ChangePersonaldata(string username, string password, string gender, string customerscard, string email, string phoneNumber, string address, string zipcode, string city, string firstname, string lastname)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(connectionstring))
                {


                    OracleCommand cmd = new OracleCommand("Update Account Set  CustomersCard_ID = '"+ customerscard+ "', Gender = '"+ gender+"',  Email ='" + email+"', PhoneNumber = '"+ phoneNumber+ "', Address='"+address+ "', ZipCode = '"+ zipcode+ "', City = '"+ city+ "', FirstName = '" + firstname+ "', LastName = '"+ lastname+"' WHERE Username = '"+ username+"'" , connection);
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
    }
}