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
    }
}
