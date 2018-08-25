using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Domain.Entities.Repos;
using Unity;
using System.Diagnostics;
using Blog.Infrastructure;
namespace Blog.WebLayer.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index(int id)
        {
            return View(Container.DIContainer.Resolve<IPostRepo>().GetPost(id));
        }
    }
}