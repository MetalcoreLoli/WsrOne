using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Wsr1.Model;
using System.Collections.ObjectModel;
using Wsr1.Core;
using Wsr1.Core.Commands;
using Wsr1.Core.ValidationModel;
using System.Windows;
using Wsr1.Core.DialogServices;
using Wsr1.View.ManagerView;
using Wsr1.View.TaskView;

namespace Wsr1.ViewModel
{
    public class CoefficientViewModel : Core.AbstractBaseModel
    {

        private CoefficientModel _selectedModel;

        private IDialogService dialogService;

        RelayCommand _editCommand;
        RelayCommand _acceptCommand;
        RelayCommand _closeCommand;
        RelayCommand _openTaskList;

        public CoefficientModel SelecteModel
        {
            get => _selectedModel;
            set
            {
                _selectedModel = value;
                OnPropertyChanged(nameof(SelecteModel));
            }
        }

        public RelayCommand OpenTaskListCommand
        {
            get => _openTaskList ?? (_openTaskList = new RelayCommand(obj =>
            {
                try
                {
                    if (obj != null)
                    {
                        var win = obj as ManagerWindow;
                        win.Hide();
                        new TaskWindow().ShowDialog();
                        win.Show();
                    }
                    else
                        throw new NullReferenceException();
                }
                catch (Exception ex)
                {
                    dialogService.ShowErrorMessage(ex.Message);
                }
            }));
        }
        public RelayCommand CloseCommand
        {
            get => _closeCommand ?? (_closeCommand = UserCommandManager.BackToUserMenuCommand);
        }

        public RelayCommand EditCommand
        {
            get => _editCommand ?? (_editCommand = new RelayCommand(obj => 
            {
                try
                {
                    if (obj != null)
                    {
                        var coeff       = obj as CoefficientModel;
                        var editWindow  = new EditWindow();

                        editWindow.CurrentCoeffcientModel = coeff;
                        editWindow.CoefficientAnalisBox.Text    = coeff.CoefficientAnalis.ToString();
                        editWindow.CoefficientDifficultBox.Text = coeff.CoefficientDifficult.ToString();
                        editWindow.CoefficientInstallBox.Text   = coeff.CoefficientInstall.ToString();
                        editWindow.CoefficientServiceBox.Text   = coeff.CoefficientService.ToString();
                        editWindow.CoefficientTimeBox.Text      = coeff.CoefficientTime.ToString();
                        
                        editWindow.JuniorBox.Text               = coeff.Junior.ToString();
                        editWindow.SeniorBox.Text               = coeff.Senior.ToString();
                        editWindow.MiddleBox.Text               = coeff.Middle.ToString();

                        editWindow.ShowDialog();
                    }
                    else
                        throw new NullReferenceException("Command Parameter was NULL");
                }
                catch (Exception ex)
                {
                    dialogService.ShowErrorMessage(ex.Message);
                }
            }, obj => UserModelSingleton.Instance().Role == Core.Enums.Role.Manager));
        }

        public RelayCommand AcceptCommand
        {
            get => _acceptCommand ?? (_acceptCommand = new RelayCommand(obj =>
            {
                try
                {
                    if (obj != null)
                    {
                        var editWindow = obj as EditWindow;
                        using (var context = Core.DataBaseConnectionContext.GetContext())
                        {
                            int manager_id = UserModelSingleton.Instance().Id;
                            var coefficienet = context.Coefficient.FirstOrDefault(coeff => coeff.Id == SelecteModel.Id);
                            var salary = context.Manager.FirstOrDefault(m => m.Id == manager_id).Salary;

                            coefficienet.CoefficientAnalis       = decimal.Parse(editWindow.CoefficientAnalisBox.Text);
                            coefficienet.CoefficientDifficult    = decimal.Parse(editWindow.CoefficientDifficultBox.Text);
                            coefficienet.CoefficientInstall      = decimal.Parse(editWindow.CoefficientInstallBox.Text);
                            coefficienet.CoefficientService      = decimal.Parse(editWindow.CoefficientServiceBox.Text);
                            coefficienet.CoefficientTime         = decimal.Parse(editWindow.CoefficientTimeBox.Text);

                            salary.JuniorMin = decimal.Parse(editWindow.JuniorBox.Text);
                            salary.SeniorMin = decimal.Parse(editWindow.SeniorBox.Text);
                            salary.MiddleMin = decimal.Parse(editWindow.MiddleBox.Text);

                            context.SaveChanges();
                            editWindow.DialogResult = true;
                            dialogService.ShowMessage("Коеффициенты обновлены");
                        }
                    }
                    else
                        throw new NullReferenceException("Command Parameter is NULL");
                }
                catch (Exception ex)
                {
                    dialogService.ShowErrorMessage(ex.Message);
                }
            }));
        }

        public ObservableCollection<CoefficientModel> Coefficients { get; set; }

        public CoefficientViewModel()
        {
            dialogService = new MessageBoxService();
            Coefficients = new ObservableCollection<CoefficientModel>(Init().Where(c => c.IdManager == UserModelSingleton.Instance().Id));
            //Coefficients.CollectionChanged += Coefficients_CollectionChanged;
        }

        //this method for init list
        private IEnumerable<CoefficientModel> Init() 
        {
            using (var con =  DataBaseConnectionContext.GetContext())
                foreach (var coenff in con.Coefficient.AsParallel())
                    yield return new CoefficientModel().CreateFrom(coenff);
        }
    }
}
