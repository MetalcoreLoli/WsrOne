using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wsr1.Model;

namespace Wsr1.Core
{
    public class UserModelSingleton
    {
        static UserModel _instance;

        public UserModelSingleton()
        {
            _instance = new UserModel();
        }

        public static UserModel Instance()
        {
            if (_instance == null)
            {
                _instance = new UserModel();
                return _instance;
            }
            else return _instance;
        }
    }
}
