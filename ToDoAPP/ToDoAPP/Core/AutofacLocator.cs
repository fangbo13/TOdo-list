using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Interfaces;
using ToDoApp.Service;

namespace ToDoApp.Core
{
    public class AutofacLocator : IAutofacLocator
    {
        IContainer container;

        public TInterface Get<TInterface>()
        {
            return container.Resolve<TInterface>();
        }

        // Registering container mapping relationships
        public void Register()
        {
            var Container = new ContainerBuilder();

            //Injection of ToDo data layer service mapping
            Container.RegisterType<ToDoService>().As<IToDoService>();

            container = Container.Build();
        }
    }

    // Global Container Manager
    public class ServiceProvider
    {
        public static IAutofacLocator Instance { get; private set; }

        public static void RegisterSerivceLocator(IAutofacLocator locator)
        {
            Instance = locator;
        }
    }
}
