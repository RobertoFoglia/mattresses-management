using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace mattresses_management_dektop_app.Context
{
    public class ApplicationContext
    {
        public static IUnityContainer Container { get { return App.DependencyInjectionContainer; } }

        private ApplicationContext() { }
    }
}
