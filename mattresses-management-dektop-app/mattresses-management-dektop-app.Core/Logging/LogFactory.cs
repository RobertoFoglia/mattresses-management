using System;

namespace mattresses_management_dektop_app.Core.Logging
{
    public class LogFactory
    {
        public static Log CreateNewIstance(Type clazzWhereItIsUsed) => new LogImpl(clazzWhereItIsUsed);
    }
}