using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteGame.Models
{
    public interface IWebsiteGameRepository
    {
        //Get all product or product from a certain categorie
        List<Product> GetAllProducts();
        List<Product> GetProductCategorie(string productType);

        //add an account
        bool AddNewAccount(Account account);

        //login
        bool Login(string username, string password);

        //Get account
        Account GetAccount(string username, string password);

        //Change personal data
        bool ChangePersonaldata(string username, string password, string gender, string customerscard, string email, string phoneNumber, string address, string zipcode, string city, string firstname, string lastname);
       
    }
}
