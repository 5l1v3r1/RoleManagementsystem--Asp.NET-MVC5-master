using Role_Management_System.DataServices.Account;
using Role_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace Role_Management_System.Controllers
{
    [HandleError]
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Dashboard");
            }
           
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel login)
        {

            if(ModelState.IsValid)
            {
                bool Authenticated = WebSecurity.Login(login.Username, login.Password, login.RememberMe);

                if(Authenticated)
                {
                    string returnUrl = Request.QueryString["ReturnUrl"];
                    if(returnUrl== null)
                    {

                        return RedirectToAction("Index", "Dashboard");
                    }
                    else
                    {
                        return Redirect(Url.Content(returnUrl));
                    }
                }
                else
                {
                    ModelState.AddModelError("Error", "Kullanıcı adı veya şifre hatalı!");
                }
            }

 
            return View();
        }

        public ActionResult Signout()
        {
            WebSecurity.Logout();
            return RedirectToAction("Login", "Account");
        }

        [HttpGet,Authorize]
        public ActionResult Register()
        {
            AccountViewModel getRole = new AccountViewModel();
            var roles = getRole.GetRoles(WebSecurity.CurrentUserId);
            ViewBag.RoleName = roles;
            return View();
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]
        public ActionResult Register(RegisterModel register)
        {
            AccountViewModel getRole = new AccountViewModel();
            var roles = getRole.GetRoles(WebSecurity.CurrentUserId);
            ViewBag.RoleName = roles;
            if(ModelState.IsValid)
            {
                //bool UserExist = WebSecurity.UserExists(WebSecurity.CurrentUserName);

                if(register.Username == WebSecurity.CurrentUserName)
                {
                    ModelState.AddModelError("Error", "Başka bir kullanıcı adı seçininz!");
                }
                else
                {
                    WebSecurity.CreateUserAndAccount(register.Username, register.Password, new { Fullname = register.FullName, Email = register.Email });
                    Roles.AddUserToRole(register.Username, register.Role);
                    return RedirectToAction("Index", "Dashboard");
                }
            }

            return View(roles);
        }
	}
}