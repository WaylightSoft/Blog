using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Infrastructure;
using Blog.Domain.Entities.Repos;
using Blog.Domain.Entities;
using Unity;
using System.Diagnostics;
namespace Blog.WebLayer.Controllers
{
    public class ProfileController : Controller
    {
       
        public ActionResult Index(string nick)
        {
            IUserRepo repo=Container.DIContainer.Resolve<IUserRepo>();
            User user=null;
            try
            {
                user = repo.GetUser(nick);
            }
            catch
            {
                return View("errorpage");
            }
            return View(user);
        }
    }
}