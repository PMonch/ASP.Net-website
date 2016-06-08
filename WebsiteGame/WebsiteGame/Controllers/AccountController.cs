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

     
    }
}