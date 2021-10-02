using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EmpMngSys.Models
{
    public class DepartModel
    {
        //Department Properties
        [Required(ErrorMessage = "Please Enter Department")]

        public string Department { get; set; }

        [Required(ErrorMessage = "Please Enter Contact Number")]
        public string Contact { get; set; }

        [Required(ErrorMessage = "Please Enter Manager Name")]
        public string Manager { get; set; }

        public int Checktype { get; set; }
    }
}