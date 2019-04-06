using ASPAssignment2.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Dependencies;
using System.Web.Mvc;
using Unity;
using Unity.Exceptions;
using Unity.Mvc5;

namespace ASPAssignment2
{

    /*
    public static void RegisterTypes(UnityContainer container)
    {
        container.RegisterType<IGenreMock, GenreLayer>();
    }


    public static void RegisterComponents()
    {
        var container = new UnityContainer();

        // register all your components with the container here
        // it is NOT necessary to register your controllers

        // e.g. container.RegisterType<ITestService, TestService>();
        container.RegisterType<DbContext, ApplicationDbContext>(new HierarchicalLifetimeManager());
        container.RegisterType<UserManager<ApplicationUser>>(new HierarchicalLifetimeManager());
        container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(new HierarchicalLifetimeManager());
        container.RegisterType<AccountController>(new InjectionConstructor());
        container.RegisterType<IAuthenticationManager>(new InjectionFactory(
            o => System.Web.HttpContext.Current.GetOwinContext().Authentication
        ));

        DependencyResolver.SetResolver(new UnityDependencyResolver(container));
    }*/
    public static class UnityConfig
    {
        public static void RegisterTypes(UnityContainer container)
        {
            container.RegisterType<IGenreMock, GenreLayer>();
            container.RegisterType<IVideoGamesMock, VideoGamesLayer>();
        }

        public static void RegisterWebApiComponents(HttpConfiguration config)
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            config.DependencyResolver = new UnityResolver(container);
        }


        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            RegisterTypes(container);
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }

    public class UnityResolver : System.Web.Http.Dependencies.IDependencyResolver
    {
        private readonly IUnityContainer _container;

        public UnityResolver(IUnityContainer container)
        {
            _container = container;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return _container.Resolve(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return new List<object>();
            }
        }

        public IDependencyScope BeginScope()
        {
            var child = _container.CreateChildContainer();
            return new UnityResolver(child);
        }

        public void Dispose()
        {
            _container.Dispose();
        }
    }
    
}