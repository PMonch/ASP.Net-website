using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebsiteGame.Models;
using System.ComponentModel.DataAnnotations;


namespace WebsiteGame.Controllers
{
    public class AccountController : Controller
    {

        private Account account;
        private int accountID = 1;
        

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Register")]
        [ValidateAntiForgeryToken]
        public ActionResult Register2(Account account)
        {
            if (ModelState.IsValid)
            {
                if(account.Gender == "male" || account.Gender == "female")
                {
                    this.account = account;
                    this.account.AddNewAccount(this.account);
                    this.accountID += 1;

                    return View("RegisterStep4");
                }
                
            }
            ViewBag.Message = "Not Valid";
            return View("Register");
        }

        
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult SubmitLogin()
        {
            string username = Request.Form["Username"];
            string password = Request.Form["password"];
            account = new Account(username, password);
            if (account.Login(username, password) == true)
            {
                ViewBag.Message = "Logged in";
                Session["Username"] = username;
                
            }
            else
            {
                ViewBag.Message = "Username or password is incorrect";
                return View("Login");
            }
            Store store = new Store("Markt 19", "5401CR", "Uden", "0413 256412");
            ViewBag.MyList = store.GetAllProducts();
            return View("../Home/Index");
        }

        public ActionResult LogOut()
        {
            Store store = new Store("Markt 19", "5401CR", "Uden", "0413 256412");
            ViewBag.MyList = store.GetAllProducts();
            Session["Username"] = null;
            return View("../Home/Index");
        }

        public new ActionResult Profile()
        {
            return View();
        }


    }
}