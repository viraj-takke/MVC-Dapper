using Dapper_Project.Models;
using Dapper_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc; 

namespace Dapper_Project.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer/GetAllCustDetails      
        public ActionResult GetAllCustDetails()
        {
            CustRepository CustRepo = new CustRepository();
            return View(CustRepo.GetAllCustDetails());
        }
        // GET: Customer/AddCustomer      
        public ActionResult AddCustomer()
        {
            return View();
        }

        // POST: Customer/AddCustomer      
        [HttpPost]
        public ActionResult AddCustomer(CustModel Cust)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CustRepository CustRepo = new CustRepository();
                    CustRepo.AddNewcustDetails(Cust);

                    ViewBag.Message = "Records added successfully.";

                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Bind controls to Update details      
        public ActionResult EditCustDetails(int id)
        {
            CustRepository CustRepo = new CustRepository();
            return View(CustRepo.GetAllCustDetails().Find(Cust => Cust.Custid == id));

        }

        // POST:Update the details into database      
        [HttpPost]
        public ActionResult EditCustDetails( CustModel obj)
        {
            try
            {
                CustRepository EmpRepo = new CustRepository();

                EmpRepo.UpdateCustDetails(obj);

                return RedirectToAction("GetAllCustDetails");
            }
            catch
            {
                return View();
            }
        }

        // GET: Delete  Customer details by id      
        public ActionResult DeleteCust(int id)
        {
            try
            {
                CustRepository CustRepo = new CustRepository();
                if (CustRepo.DeletecustById(id))
                {
                    ViewBag.AlertMsg = "Customer details deleted successfully";

                }
                return RedirectToAction("GetAllCustDetails");
            }
            catch
            {
                return RedirectToAction("GetAllCustDetails");
            }
        }
    }
}
