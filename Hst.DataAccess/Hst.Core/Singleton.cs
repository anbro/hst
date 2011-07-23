using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hst.Core
{
    public class Singleton<T>
        where T : class, new()
    {
        private static readonly T _instance;

        public static T Instance
        {
            get { return _instance; }
        }

        static Singleton()
        {
            _instance = new T();
        }
    }
}
