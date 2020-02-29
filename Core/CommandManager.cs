using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wsr1.Core.Commands;

namespace Wsr1.Core
{
    public static class UserCommandManager
    {
        private readonly static RelayCommand _backToLoginCommand;
        private readonly static RelayCommand _backToUserMenuCommand;

        static UserCommandManager()
        {
            _backToLoginCommand = new RelayCommand(BackToLogin);
            _backToUserMenuCommand = new RelayCommand(BackToUserMenu);
        }

        public static RelayCommand BackToLoginCommand { get => _backToLoginCommand; }
        public static RelayCommand BackToUserMenuCommand { get => _backToUserMenuCommand; }


        #region Command Realization
        private static void BackToLogin(object obj)
        {
            if (obj != null)
            {
                if (obj is Window window)
                {
                    UserModelSingleton.Clear();
                    new MainWindow().Show();
                    window.Close();
                }
                else
                    throw new Exception("Что-то пошло не так");
            }
            else
                throw new Exception("Что-то пошло не так");
        }
        private static void BackToUserMenu(object obj)
        {
            if (obj != null)
            {
                if (obj is Window window)
                {
                    new View.UserMenuWindow().Show();
                    window.Close();
                }
                else
                    throw new Exception("Что-то пошло не так");
            }
            else
                throw new Exception("Что-то пошло не так");
        }

        #endregion
    }
}
