using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Role_Management_System.Controllers
{
    [Authorize]
    [HandleError]
    public class StudentController : Controller
    {

        public ActionResult StudentList()
        {
            return View();
        }
	}
}