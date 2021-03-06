﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteGame.Models
{
    public class WebsiteGameDal
    {
        IWebsiteGameRepository _repository;
  
        public WebsiteGameDal(IWebsiteGameRepository repository)
        {
            _repository = repository;
        }

        //  get products to show in website.
        public List<Product> GetAllProducts()
        {
            return _repository.GetAllProducts();
        }

       
        public List<Product> GetProductCategorie(string productType)
        {
            return _repository.GetProductCategorie(productType);
        }

        //add a new account
        public bool AddNewAccount(Account account)
        {
            return _repository.AddNewAccount(account);
        }

        //login
        public bool Login(string username, string password)
        {
            return _repository.Login(username, password);
        }

        //Get account
        public Account GetAccount(string username, string password)
        {
            return _repository.GetAccount(username, password);
        }

        //Change personal data
        public bool ChangePersonaldata(string username, string password, string gender, string customerscard, string email, string phoneNumber, string address, string zipcode, string city, string firstname, string lastname)
        {
            return _repository.ChangePersonaldata(username, password, gender,customerscard, email, phoneNumber, address, zipcode, city, firstname, lastname);
           
        }
    }
}