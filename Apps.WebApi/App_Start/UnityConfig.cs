using Apps.Core;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace Apps.WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {            
            //var container = new UnityContainer();

            //         // register all your components with the container here
            //         // it is NOT necessary to register your controllers

            //         // e.g. container.RegisterType<ITestService, TestService>();

            //GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
            UsingUnityContainer.Init();
            DependencyRegisterType.Container_Sys(ref UsingUnityContainer._container);
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(UsingUnityContainer._container);
        }
    }
}