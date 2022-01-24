using System;
using System.Collections.Generic;
using System.Text;

namespace mattresses_management_dektop_app.Core.Logging
{
    public interface Log
    {
        void Information(string messageTemplate);

        void Information(string messageTemplate, params object[] propertyValues);

        void Debug(string messageTemplate);

        void Debug(string messageTemplate, params object[] propertyValues);

        void Warning(string messageTemplate);

        void Warning(string messageTemplate, params object[] propertyValues);

        void Error(Exception exception, string messageTemplate);
    }
}
