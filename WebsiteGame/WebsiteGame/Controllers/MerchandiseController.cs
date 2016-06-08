﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteGame.Models;

namespace WebsiteGame.Controllers
{

    public class MerchandiseController : Controller
    {
        private Store store = new Store("Markt 19", "5401CR", "Uden", "0413 256412");


        // GET: Merchandise
        public ActionResult Index(string productType)
        {
            ViewBag.MyList = store.GetProductCategorie(productType);
            return View();
        }
    }
}