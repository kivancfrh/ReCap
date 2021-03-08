using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
    //Extension yazabilmek için class statik olur
    public static class ServiceCollectionExtensions
    {
        //Polimorfizim!!!!!
        //Ekleyeceğimiz bütün injeksınları bir arada toplayabileceğimiz bir yapıya dönüştürdük!
        //Service collection Api mizin servis bağımlılıklarımızı eklediğimiz, yada araya girmesini istedğimiz servisleri eklediğimiz koleksiyondur
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection, ICoreModule[] modules) // virgül sonrası parametredir.
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollection);
            }
            return ServiceTool.Create(serviceCollection);
        }
    }
}
