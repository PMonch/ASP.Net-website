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

        [Required]
        public string Username { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string DateOfBirth { get; set; }

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

        public Account(string username, string password, string dateOfBirth, string email, string phoneNumber, string address, string zipcode, string city, UserType usertype)
        {
            this.Username = username;
            this.Password = password;
            this.DateOfBirth = dateOfBirth;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.Address = address;
            this.Zipcode = zipcode;
            this.City = city;
            this.Type = usertype;

        }

        public Account()
        {

        }

        public bool ChangePersonaldata(string username, string password, DateTime dateOfBirth, string email, string phoneNumber, string address,string zipcode, string city)
        {
            return false;
        }

        public bool AddCustomersCard(int cardnumber)
        {
            return false;
        }

        public void AddNewAccount(Account account)
        {
            dal.AddNewAccount(account);
        }
    }
}