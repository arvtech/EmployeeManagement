using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmpMngSys.Models;
using EmpMngSys.DBAccess;

namespace EmpMngSys.Controllers
{
    public class DepartController : Controller
    {
        // GET: Depart
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(DepartModel depart)
        {
            if (ModelState.IsValid)
            {
                DepartmentDBAccess db = new DBAccess.DepartmentDBAccess();
                int result = db.AddDepartment(depart);
                if (result > 0)
                {
                    TempData["Message"] = "<script>alert('Department Added')</script>";
                    ModelState.Clear();
                }

            }
            return View();
        }
    }
}