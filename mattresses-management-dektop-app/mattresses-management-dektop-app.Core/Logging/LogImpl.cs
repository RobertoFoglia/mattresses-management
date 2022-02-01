using System;

namespace mattresses_management_dektop_app.Core.Logging
{
    public class LogImpl : Log
    {
        private Type _classWhereItIsUsed;

        public LogImpl(Type classWhereItIsUsed)
        {
            this._classWhereItIsUsed = classWhereItIsUsed;
        }

        public void Debug(string messageTemplate) =>
            Serilog.Log.Debug(MakeMessageTemplate(messageTemplate));

        private string MakeMessageTemplate(string messageTemplate) => _classWhereItIsUsed.FullName + " - " + messageTemplate;

        public void Debug(string messageTemplate, params object[] propertyValues) =>
            Serilog.Log.Debug(MakeMessageTemplate(messageTemplate), propertyValues);

        public void Information(string messageTemplate) =>
            Serilog.Log.Information(MakeMessageTemplate(messageTemplate));

        public void Information(string messageTemplate, params object[] propertyValues) =>
            Serilog.Log.Information(MakeMessageTemplate(messageTemplate), propertyValues);

        public void Warning(string messageTemplate) =>
            Serilog.Log.Warning(MakeMessageTemplate(messageTemplate));

        public void Warning(string messageTemplate, params object[] propertyValues) =>
            Serilog.Log.Warning(MakeMessageTemplate(messageTemplate), propertyValues);

        public void Error(Exception exception, string messageTemplate) =>
            Serilog.Log.Error(exception, MakeMessageTemplate(messageTemplate));
    }
}