using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity;
using Blog.Infrastructure;
using Blog.Domain.Entities;
using Blog.Domain.Entities.Repos;
using Unity;
using Blog.DataAccess;

namespace Blog.TestingStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            
            IPostRepo repo= Container.DIContainer.Resolve<IPostRepo>();
            
            foreach(var item in repo.GetPosts(1, 0, 1))
            {
                Console.WriteLine(item.Id); 
            }


        }
    }
}
