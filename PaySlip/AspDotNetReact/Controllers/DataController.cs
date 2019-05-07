using AspDotNetReact.Domain;

using System.Collections.Generic;
using System.Web.Mvc;
using Unity.AspNet.Mvc;
using Business.PaySlip.Provider;
using Business.PaySlip.Interface;
using Business.PaySlip.Model;
using System;

namespace AspDotNetReact.Controllers
{
    public class DataController : Controller
    {
        private readonly IPaySlip _paySlip;
        public DataController(IPaySlip paySlip)
        {
            _paySlip = paySlip;
        }
        // GET: Data
        [HttpGet]
        public JsonResult Index()
        {
           
            return Json(new { result = "" }, JsonRequestBehavior.AllowGet);
        }
       
        [HttpPost]
        public JsonResult GeneratePaySlip(EmployeeDetails employeeDetails)
        {
          EmployeePaySlipDetails paySlipDetails=_paySlip.GeneratePaySlip(employeeDetails);
            return Json(new { result = paySlipDetails }, JsonRequestBehavior.AllowGet);
        }

       
    }
}
