using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using Violet.Interfaces.ManagerInterfaces;
using Violet.Interfaces.RepositoryInterfaces;
using Violet.Managers;
using Violet.Repositories;

namespace Violet.Models
{
    public static class SimpleInjectorDependency
    {
        public static void RegisterDependencies()
        {
            var container = new Container();
            container.Register<IUsersRepository, UsersRepository>(Lifestyle.Transient);
            container.Register<IUsersManager, UsersManager>(Lifestyle.Transient);
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

    }
}