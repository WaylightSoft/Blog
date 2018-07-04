using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Blog.Domain.Entities.Repos;
using Blog.DataAccess.Entities.Repos;

namespace Blog.Infrastructure
{
    class Container
    {
        private static UnityContainer dIContainer;
        public static UnityContainer DIContainer
        {
            get {
                if (dIContainer == null)
                {
                    dIContainer = new UnityContainer();
                }
                return dIContainer;
            }
        }
        private void RegisterAll(UnityContainer container)
        {
            container.RegisterType<IImageRepo, EFImageRepo>();
            container.RegisterType<IPostImageRepo, EFPostImageRepo>();
            container.RegisterType<IPostRepo, EFPostRepo>();
            container.RegisterType<IRoleRepo, EFRoleRepo>();
            container.RegisterType<ITagRepo, EFTagRepo>();
            container.RegisterType<IUserCredentialRepo, EFUserCredentialRepo>();
            container.RegisterType<IUserRepo, EFUserRepo>();
        }
    }
}
