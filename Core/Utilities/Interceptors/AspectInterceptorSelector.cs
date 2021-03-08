using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Core.Utilities.Interceptors
{

    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            //classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger))); // Otomatik olarak sistemdeki tüm metodları log a dahil et. Şuan loglama altyapımız hazır değil o yüzden kullanmıyoruz
            //İstersek buraya performance ı eklersek sistemdeki tüm hareketlerin performansına bakar ve rapor verir.
            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
