using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteGame.Models
{
    public class Store
    {
        public int ID { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }

        public List<Product> products { get; set; }

       private WebsiteGameDal dal = new WebsiteGameDal(new WebsiteGameRepository());

        public Store(string addres, string zipcode, string city, string phonenNumber)
        {
            this.Address = addres;
            this.Zipcode = zipcode;
            this.City = city;
            this.PhoneNumber = phonenNumber;
        }
        

        public void AddNewProduct(string productType, string name, string description, decimal price)
        {

        }

        public void ConfirmOrder(int orderID)
        {

        }

        public bool OrderPickedUp(int orderID)
        {
            return false;
        }

        public bool DeleteOrder(int orderID)
        {
            return false;
        }

        public bool AddOrderForCustomer(int ProductID)
        {
            return false;
        }

        public bool AddOrderForStore(int productID)
        {
            return false;
        }

        public bool AddAmountOfProduct(int productID, int newAmount)
        {
            return false;
        }

        public List<Product> GetAllProducts()
        {
            return dal.GetAllProducts();
        }

        public List<Product> GetProductCategorie(string productType)
        {
            return dal.GetProductCategorie(productType);
        }
    }
}