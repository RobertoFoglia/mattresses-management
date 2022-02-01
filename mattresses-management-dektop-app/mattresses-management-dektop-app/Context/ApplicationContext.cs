using Microsoft.Practices.Unity;

namespace mattresses_management_dektop_app.Context
{
    public class ApplicationContext
    {
        public static IUnityContainer Container
        { get { return App.IOCContainer; } }

        private ApplicationContext()
        { }
    }
}
