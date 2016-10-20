using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugsSystem.Data.Infrastructure
{
    public static class ExceptionExtensions
    {
        private static Dictionary<Type,string> _handleExceptions = new Dictionary<Type, string>
        {
            { typeof(DbUpdateException), "Update Database Exception: " },
            { typeof(DbUpdateConcurrencyException), "Update Concurrency Database Exception"},
            { typeof(DbEntityValidationException), ""},
            { typeof(NotSupportedException), "" },
            { typeof(ObjectDisposedException), ""},
            { typeof(InvalidOperationException), ""}
        };

        public static string Log(this Exception exception)
        {
            return string.Format("{0} {1}",exception.Message,exception.Source);
        }

        public static void Handler(Action action)
        {
            try
            {
                action();
            }
            catch(Exception exc)
            {
                if(_handleExceptions.Keys.Contains(exc.GetType()))
                {
                    Debug.WriteLine(_handleExceptions[exc.GetType()] + exc.Log());
                }
                else
                {
                    Debug.WriteLine(exc.Log());
                }
            }
        }
    }
}
