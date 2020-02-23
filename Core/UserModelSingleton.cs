using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wsr1.Core.EntityModels;
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

        public static UserModel Instance(Person user)
        {
            var user_singleton = UserModelSingleton.Instance();
            user_singleton.CreateFromPerson(user);
            return user_singleton;
        }
        public static void Clear()
        {
            if (_instance != null)
                _instance = null;
        }
    }
}
