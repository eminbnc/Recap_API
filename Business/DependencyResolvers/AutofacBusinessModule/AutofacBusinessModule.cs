using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Concrete;

namespace Business.DependencyResolvers.AutofacBusinessModule
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();
            builder.RegisterType<JWTHelper>().As<ITokenHelper>().SingleInstance();
            builder.RegisterType<EfUserOperationClaimDal>().As<IUserOperationClaimDal>().SingleInstance();
            builder.RegisterType<EfCompanyOperationClaimDal>().As<ICompanyOperationClaimDal>().SingleInstance();
            builder.RegisterType<EfCompanyDal>().As<ICompanyDal>().SingleInstance();
            builder.RegisterType<EfJobApplicationDal>().As<IJobApplicationDal>().SingleInstance();
            builder.RegisterType<EfJobPostingDal>().As<IJobPostingDal>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
            .EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();
        }
    }
}
