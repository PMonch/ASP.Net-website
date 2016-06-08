using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteGame.Models
{
    public class Collection
    {
        public int ID { get; set; }
        public int AccountID { get; set; }

        private List<Product> products;
        public Collection()
        {

        }

        public bool AddToCollection(int productID)
        {
            return false;
        }

        public bool RemoveFromCollection(int ProductId)
        {
            return false;
        }
    }
}