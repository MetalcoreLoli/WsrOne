using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wsr1.Core;
using Wsr1.Core.Commands;
using Wsr1.Core.DialogServices;
using Wsr1.Core.EnityModels;
using Wsr1.View.ManagerView;

namespace Wsr1.ViewModel
{
    public class LoginViewModel : Core.AbstractBaseModel
    {
        #region Private Members

        IDialogService dialogService;
        private RelayCommand _logIn;
        #endregion
        #region Public Properties

        public RelayCommand LogIn
        {
            get => _logIn ?? (_logIn = new RelayCommand(async obj => {
                try
                {
                    if (obj != null)
                    {
                        var loginWindow = obj as MainWindow;
                        var login = loginWindow.LoginBox.Text;
                        var password = loginWindow.PassWordBox.Password;

                        using (var context = Core.DataBaseConnectionContext.GetContext())
                        {
                            Person user = await context
                                              .Person
                                              .FirstOrDefaultAsync(person => person.Login.Equals(login) && person.Password.Equals(password));
                            if (user != null)
                            { 
                                UserModelSingleton.Instance(user);

                                switch (UserModelSingleton.Instance().Role)
                                {
                                    case "Менеджер":
                                        new ManagerWindow().Show();
                                        loginWindow.Close();
                                        break;
                                    case "Исполнитель": 
                                        break;
                                    default: throw new Exception("Неизвестный пользователь");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    dialogService.ShowErrorMessage(ex.Message);
                }
            }));
        }
        #endregion

        #region Constructor

        public LoginViewModel()
        {
            dialogService = new MessageBoxService();
        }
        #endregion
    }
}
