using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BusinessLogic.Implementations;
using BusinessLogic.Interfaces;
using Domain;
using Ninject;
using BusinessLogic;

namespace Web
{
    public class NinjectControllerFactory:DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            ninjectKernel=new StandardKernel();
            AddBindings();
        }
        //извлекаем экземпляр контролера для заданного контекста запроса и типа контролера
        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController) ninjectKernel.Get(controllerType);
        }
        // отправляем все привязки
        private void AddBindings()
        {
            ninjectKernel.Bind<IUsersRepository>().To<EFUsersRepository>();
            ninjectKernel.Bind<IOrdersRepository>().To<EFOrdersRepository>();
            ninjectKernel.Bind<IBooksRepository>().To<EFBooksRepository>();
            ninjectKernel.Bind<IAuthorRepository>().To<EFAuthorsRepository>();
            ninjectKernel.Bind<EFDbContext>().ToSelf().WithConstructorArgument("connectionString",
                                                                               ConfigurationManager.ConnectionStrings[0]
                                                                                   .ConnectionString);
            ninjectKernel.Inject(Membership.Provider);
        }
    }
}