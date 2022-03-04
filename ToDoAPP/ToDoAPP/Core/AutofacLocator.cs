using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Interfaces;
using ToDoAPP.Service;

namespace ToDoApp.Core
{
    public class AutofacLocator : IAutofacLocator
    {
        IContainer container;

        public TInterface Get<TInterface>()
        {
            return container.Resolve<TInterface>();
        }

        /// 注册容器映射关系
        public void Register()
        {
            var Container = new ContainerBuilder();

            //注入ToDo数据层服务映射
            Container.RegisterType<ToDoService>().As<IToDoService>();
            container = Container.Build();
        }
    }

    //全局容器管理器
    public class ServiceProvider
    {
        public static IAutofacLocator Instance { get; private set; }

        public static void RegisterSerivceLocator(IAutofacLocator locator)
        {
            Instance = locator;
        }
    }
}
