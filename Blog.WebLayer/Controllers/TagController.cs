using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.WebLayer.Controllers
{
    public class TagController : Controller
    {
        // GET: Tags
        public ActionResult Index(int TagId)
        {
            return View();
        }
    }
}