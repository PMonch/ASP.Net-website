using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebsiteGame.Models
{
    public enum UserType
    {
        Employee,
        Admin,
        Customer
    }
    public class Account
    {
        public int ID { get; }


        public Customerscard Card { get; set; }

        [MinLength(13, ErrorMessage ="Customerscard doesn't have the right length")]
        public string Customerscard { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Password { get; set; }
        
        [Required(ErrorMessage ="Gender is niet correct")]
        public string Gender { get; set; }

        [Required]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address{ get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public UserType Type { get; set; }

        private WebsiteGameDal dal = new WebsiteGameDal(new WebsiteGameRepository());

        public Account()
        {

        }

        public Account(string username, string password, string email, string phoneNumber, string address, string zipcode, string city, string firstname, string lastname, string gender, string customerscard)
        {
            this.Username = username;
            this.Password = password;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.Address = address;
            this.Zipcode = zipcode;
            this.City = city;
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Gender = gender;
            this.Customerscard = customerscard;
            

        }
        
        public Account(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

  

        public bool ChangePersonaldata(string username, string password, string gender, string customerscard, string email, string phoneNumber, string address,string zipcode, string city, string firstname, string lastname)
        {
            return dal.ChangePersonaldata(username, password, gender, customerscard, email, phoneNumber, address, zipcode, city, firstname, lastname);
           
        }

        public bool AddCustomersCard(int cardnumber)
        {
            return false;
        }

        public void AddNewAccount(Account account)
        {
            dal.AddNewAccount(account);
        }

        public bool Login(string username, string password)
        {
            return dal.Login(username, password);
        }
        public Account GetAccount(string username, string password)
        {
            return dal.GetAccount(username, password);
        }
    }
}