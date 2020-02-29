using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wsr1.Core;
using Wsr1.Core.Commands;
using Wsr1.Core.DialogServices;
using Wsr1.View;

namespace Wsr1.ViewModel
{
    public class UserMenuViewModel : Core.AbstractBaseModel
    {

        private RelayCommand _backCommand;
        private RelayCommand _coeffCommand;
        private RelayCommand _taskCommand;

        private IDialogService dialogService;

        public RelayCommand BackCommand
        {
            get => _backCommand ?? (_backCommand = UserCommandManager.BackToLoginCommand);
        }


        public RelayCommand CoeffCommand
        {
            get => _coeffCommand ?? (_coeffCommand = new RelayCommand(obj =>
            {
                try
                {
                    _ = obj ?? throw new Exception("Что-то пошло не так");
                    if (obj is UserMenuWindow menuWindow)
                    {
                        new View.ManagerView.ManagerWindow().Show();
                        menuWindow.Close();
                    }
                    else
                        throw new Exception("Что-то пошло не так");
                }
                catch (Exception ex)
                {
                    dialogService.ShowErrorMessage(ex.Message);
                }
            }, obj => 
            {

                bool isManager = UserModelSingleton.Instance().Role == Core.Enums.Role.Manager;
                if (!isManager) 
                    dialogService.ShowErrorMessage("Только менеджеры могут просматривать документы !!!");
                return isManager;
            }));
        }

        public RelayCommand TaskCommand
        {
            get => _taskCommand ?? (_taskCommand = new RelayCommand(obj =>
            {
                try
                {
                    if (obj != null)
                    {
                        if (obj is UserMenuWindow menuWindow)
                        {
                            new View.TaskView.TaskWindow().Show();
                            menuWindow.Close();
                        }
                        else
                            throw new Exception("Что-то пошло не так");
                    }
                    else
                        throw new Exception("Что-то пошло не так");

                }
                catch (Exception ex)
                {
                    dialogService.ShowErrorMessage(ex.Message);
                }
            }));
        }



        public UserMenuViewModel()
        {
            dialogService = new MessageBoxService();
        }
    }
}
