using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteGame.Models
{
    public class Order
    {
        public int ID { get; set; }
        public int AccountID { get; set; }
        public int StoreID{ get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }

        private List<Product> products;

        public Order(int accountID, int storeID, int productName)
        {

        }

        public bool PlaceOrder(int productID)
        {
            return false;
        }
       
    }
}