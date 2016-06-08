using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteGame.Models
{
    public interface IWebsiteGameRepository
    {
        List<Product> GetAllProducts();
        List<Product> GetProductCategorie(string productType);
        bool AddNewAccount(Account account);
    }
}
