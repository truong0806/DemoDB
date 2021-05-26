using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoDB.Models;
namespace DemoDB.Controllers
{
    public class CustomerController : Controller
    {
        DBSportStoreEntities db = new DBSportStoreEntities();
        // GET: Customer
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Customer cus)
        {
            if (ModelState.IsValid)
            {
                var check_ID = db.Customers.Where(s => s.IDCus == cus.IDCus).FirstOrDefault();
                if (check_ID == null)
                {
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.Customers.Add(cus);
                    db.SaveChanges();
                    return RedirectToAction("ShowCart","ShoppingCart");
                }
                else
                {
                    ViewBag.ErrorRegister = "This ID is exist";
                    return View();
                }
            }
            return View();
        }

       
    }
}