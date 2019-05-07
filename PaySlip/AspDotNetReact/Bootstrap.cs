using System.Web.Mvc;
using Business.PaySlip.Provider;
using Unity.AspNet.Mvc;
using Business.PaySlip;
using AspDotNetReact.Controllers;
using Unity;
using Business.PaySlip.Interface;

namespace AspDotNetReact
{
    public class Bootstrap
    {
        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IPaySlip, PaySlipProvider>();
            container.RegisterType<IController, DataController>("Store");

            return container;
        }
    }
}