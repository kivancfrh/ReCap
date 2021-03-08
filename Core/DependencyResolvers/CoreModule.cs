﻿using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache(); //Hazır bir injection. Arkada hazır ICacheMemory hazırlar. .Net'ten gelir. IMemoryCache _memoryCache'i injection yapıyor.
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); //Client bir istek yapınca, isteğin takibini yapıyor
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
            serviceCollection.AddSingleton<Stopwatch>();
        }
    }
}
