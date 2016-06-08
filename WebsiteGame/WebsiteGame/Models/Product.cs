using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteGame.Models
{
    public class Product
    {
        public string ProductType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int AmountInStore { get; set; }

        public Product(string productType, string name, string description, decimal price)
        {
            this.ProductType = productType;
            this.Name = name;
            this.Description = description;
            this.Price = price;
        }

        public bool ChangePrice(decimal newPrice)
        {
            return true;
        }

        public List<Product> ShowRelatedProducts()
        {
            List<Product> p = new List<Product>();
            return p;
        }

        public void SetAmount(int StoreId)
        {

        }


    }
}