using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        //Sen artık bir autofac modulusün

        //Yayınladığınız zaman yada uygulama ayağa kalktığında burası çalışacak
        protected override void Load(ContainerBuilder builder)
        {
            //Bu yapılar ReCap'te kullanılacak şeylerdir
            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance(); //Birisi senden ICarService istersen ona bir CarManager instance(örneği) i ver 
                                                                                   //SingleInstance --> sadece operasyon çağırma. Data tutmuyor.
            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();

            builder.RegisterType<CarImageMaganer>().As<ICarImageService>().SingleInstance();
            builder.RegisterType<EfCarImageDal>().As<ICarImageDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
