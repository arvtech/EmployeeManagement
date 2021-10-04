using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmpMngSys.DBAccess;
using EmpMngSys.Models;

namespace EmpMngSys.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDBAccess db = new EmployeeDBAccess();
        EmployeeModal emp = new Models.EmployeeModal();



        EmployeeModal emp = new Models.EmployeeModal();

        //Get: All Employee into Model : //Select all Employee : using return model
        public ActionResult Index()
        {



            DataSet ds = new DataSet();
            ds = db.GetAllEmployee();
            List<EmployeeModal> emplist = new List<Models.EmployeeModal>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    EmployeeModal emp = new Models.EmployeeModal();

                    emp.EmpId = Convert.ToInt32(dr["EmpId"]);
                    emp.Name = dr["Name"].ToString();
                    emp.Department = dr["Department"].ToString();
                    emp.Salary = dr["Salary"].ToString();
                    emp.Email = dr["Email"].ToString();
                    emp.Contact = dr["Contact"].ToString();
                    emp.Address = dr["Address"].ToString();
                    emp.Image = dr["Image"].ToString();
                    emp.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    emplist.Add(emp);


                }
                emp.EmployeeList = emplist;
            }

            return View(emp);
        }
        // GET: Employee
        public ActionResult Create()
        {
            emp.Departments = db.PopulateDepartment();
            return View(emp);
        }

        //Add New Employee
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase ImageData, EmployeeModal employee)
        {
            if (ImageData != null)
            {
                int result = db.InsertEmployee(ImageData, employee);
                if (result > 0)
                {
                    TempData["Message"] = "<script>alert('Employee Added Successfully')</script>";

                    ModelState.Clear();
                }
            }
            else
            {
                TempData["Message"] = "<script>alert('Please Select Image')</script>";

            }

            emp.Departments = db.PopulateDepartment();
            return View(emp);
        }
    }
}