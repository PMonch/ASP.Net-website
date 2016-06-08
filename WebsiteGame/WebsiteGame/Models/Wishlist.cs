using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteGame.Models
{
    public class Wishlist
    {
        public int ID { get; set; }
        public int AccountID { get; set; }

        private List<Product> products;
        public Wishlist()
        {

        }

        public bool AddToWishlist(int productID)
        {
            return false;
        }

        public bool RemoveFromWishlist(int ProductId)
        {
            return false;
        }
    }
}