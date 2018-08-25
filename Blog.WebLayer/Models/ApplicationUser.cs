using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.WebLayer.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int UserId { get; set; }
        public string Password { get; set; }
    }
}