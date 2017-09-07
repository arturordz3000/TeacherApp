using Common.Alerts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Common.Handlers
{
    public class AppExceptionHandler : IAlertExceptionHandler
    {
        public Dictionary<Type, string> RegisteredExceptions { get; private set; }

        private IAlertDisplayer alertDisplayer;

        public AppExceptionHandler(IAlertDisplayer alertDisplayer)
        {
            this.alertDisplayer = alertDisplayer;
            RegisteredExceptions = new Dictionary<Type, string>();
        }

        public void RegisterExceptionType(Type exceptionType, string alertMessage)
        {
            if (!isValidException(exceptionType))
                throw new ArgumentException("The type is not an Exception");

            RegisteredExceptions.Add(exceptionType, alertMessage);
        }

        private bool isValidException(Type exceptionType)
        {
            return exceptionType.GetTypeInfo().IsSubclassOf(typeof(Exception))
                || exceptionType == typeof(Exception);
        }

        public void HandleException(object sender, Exception ex)
        {
            if (RegisteredExceptions.ContainsKey(ex.GetType()))
            {
                string message = RegisteredExceptions[ex.GetType()];
                alertDisplayer.DisplayAlert(sender, "Teacher Hiring App", message, "Ok");

                return;
            }

            alertDisplayer.DisplayAlert(sender, "Teacher Hiring App", "Ha ocurrido un problema desconocido", "Ok");
        }
    }
}
