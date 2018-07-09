using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity;
using Blog.Infrastructure;
using Blog.Domain.Entities.Repos;
using Unity;

namespace Blog.TestingStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            IUserCredentialRepo repo= Container.DIContainer.Resolve<IUserCredentialRepo>();
            using (repo)
                repo.Create("testlogi1213n11", "test-password");
            Console.WriteLine(repo.GetUserCredential(12).Login);
            using (repo)
                repo.Delete(12);
            
        }
    }
}
