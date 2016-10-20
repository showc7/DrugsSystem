using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugsSystem.Data.Infrastructure
{
    public static class ExceptionExtensions
    {
        public static string Log(this Exception exception)
        {
            return string.Format("{0} {1}",exception.Message,exception.Source);
        }
    }
}
