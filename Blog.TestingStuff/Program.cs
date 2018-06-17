using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.DataAccess;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity;
using Blog.Domain;

namespace Blog.TestingStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            using (BlogDataContext context = new BlogDataContext())
            {
                context.Users.Add(new User()
                {
                    UserCredentialsId = 1,
                    Bio = "testBIo",
                    Nickname = "testDude",
                    RoleId = 1,

                });
                context.SaveChanges();
                context.Posts.Add(new Post()
                {
                    Content = "test",
                    Rating = 1,
                    Views = 0,
                    UserId = 1
                });
                context.SaveChanges();
            }
        }
    }
}
