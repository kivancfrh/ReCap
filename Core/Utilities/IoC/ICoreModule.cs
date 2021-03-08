using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
    //Framework katmanımız diyebiliriz. Farklı bir projeye taşınsak bile bunları kullanabileceğiz.
    public interface ICoreModule
    {
        void Load(IServiceCollection serviceCollection);
    }
}
