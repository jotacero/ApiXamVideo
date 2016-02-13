using System.Data.Entity;
using Microsoft.Practices.Unity;
using System.Web.Http;
using ApiContactos.Models;
using ApiContactos.Repositorios;
using Unity.WebApi;

namespace ApiContactos
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            // register all your components with the container here
            var container = new UnityContainer();

            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<DbContext, UsuariosEntities>();
            container.RegisterType<UsuarioRepositorio>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}