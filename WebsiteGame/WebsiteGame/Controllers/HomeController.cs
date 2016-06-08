using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteGame.Models;


namespace WebsiteGame.Controllers
{
    public class HomeController : Controller
    {
        private Store store = new Store("Markt 19", "5401CR", "Uden", "0413 256412");
        private Product pr;
        private List<Product> related;
        // GET: Home
        public ActionResult Index()
        {
           
            ViewBag.MyList = store.GetAllProducts();
            return View();
        }

        public ActionResult ProductDetails(string name)
        {
            
            foreach(Product p in store.GetAllProducts())
            {
                if(p.Name == name)
                {
                    pr = p;
                }
            }
            related = new List<Product>();
            foreach(Product ps in store.GetAllProducts())
            {
                if (ps.ProductType == pr.ProductType && ps.Name != pr.Name)
                {
                    related.Add(ps);
                }
            }
            ViewBag.MyList = related;
            ViewBag.Data = pr;
            return View();
        }
    }
}