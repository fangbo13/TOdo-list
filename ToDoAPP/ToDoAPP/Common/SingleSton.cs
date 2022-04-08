using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ToDoAPP.Common
{
    public class SingleSton<T> where T : class, new()
    {
        private static T instance;
        public static T Instance
        {
            get
            {
                Interlocked.CompareExchange<T>(ref instance, new T(), null);
                return instance;
            }
        }
    }
}
