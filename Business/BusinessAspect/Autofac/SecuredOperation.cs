using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Core.Extensions;
using Business.Constans;
using Microsoft.AspNetCore.Http;

namespace Business.BusinessAspect.Autofac
{
    //For JWT
    //Yetkileri kontrol eden kısım buras
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor; //Her istek için Httpcontext i oluşur.

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
            //ICarService = ServiceTool.ServiceProvider.GetService<ICarService>(); //Örn. WinForm Uygulaması için
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role)) //yetkilerin içinde rolü varsa claim i varsa devam et
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied); //Yoksa hata ver.
        }
    }
}
