using Blog.WebLayer.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Blog.WebLayer.Controllers
{
    public class APIAccountController : Controller
    {
        ApplicationUserManager userManager;
        ApplicationUserManager UserManager
        {
            get
            {
                if (userManager == null)
                {
                    userManager= HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                }
                return userManager;
            }
        }
        [HttpPost]
        public async HttpResponseMessage Register(ApplicationUser user)
        {
            IdentityResult result = await UserManager.CreateAsync(user, user.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Login", "Account");
            }
            return View("Login",user);

        }

    }
}