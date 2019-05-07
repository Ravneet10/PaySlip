using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc3;
using Business.PaySlip.Provider;
using AspDotNetReact.Controllers;
using Business.PaySlip.Interface;

namespace AspDotNetReact
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IPaySlip, PaySlipProvider>();
            container.RegisterType<IController, DataController>("Store");

            return container;
        }
    }
}