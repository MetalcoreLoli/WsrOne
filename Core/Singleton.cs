using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wsr1.Core
{
    public static class Singleton<T> where T : class, new()
    {
        static T _instance;

        public static T Instance()
        {
            if (_instance == null)
            {
                _instance = new T();
                return _instance;
            }
            else return _instance;
        }
    }
}
