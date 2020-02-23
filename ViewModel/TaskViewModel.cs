using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wsr1.Core;
using Wsr1.Core.Commands;
using Wsr1.Core.DialogServices;
using Wsr1.Core.EntityModels;
using Wsr1.Model;

namespace Wsr1.ViewModel
{

    public class TaskViewModel : Core.AbstractBaseModel
    {
        #region Private Members
        private RelayCommand _clearCommand;
        private RelayCommand _editCommand;
        private RelayCommand _addCommand;
        private RelayCommand _delCommand;

        private IDialogService _dialogService;
        private TaskModel _selectedModel;
        #endregion

        #region PublicMembers
        public ObservableCollection<TaskModel> Tasks    { get; set; }
        public ObservableCollection<String> FistNames   { get; set; }
        public ObservableCollection<String> SecondNames { get; set; }
        public ObservableCollection<String> LastNames   { get; set; }
        public ObservableCollection<String> Statuses   { get; set; }


        public TaskModel SelectedModel
        {
            get => _selectedModel;
            set
            {
                _selectedModel = value;
                OnPropertyChanged(nameof(SelectedModel));
            }
        }

        public RelayCommand ClearCommand
        {
            get => _clearCommand ?? (_clearCommand = new RelayCommand(obj =>
            {
                try
                {
                    if (obj != null)
                    {
                        throw new NotImplementedException("TODO:");
                    }
                }
                catch (Exception ex)
                {
                    _dialogService.ShowErrorMessage(ex.Message);
                }
            }));
        }

        public RelayCommand EditCommand
        {
            get => _editCommand ?? (_editCommand = new RelayCommand(obj =>
            {
                try
                {
                    if (obj != null)
                    {
                        throw new NotImplementedException("TODO:");
                    }
                }
                catch (Exception ex)
                {
                    _dialogService.ShowErrorMessage(ex.Message);
                }
            }));
        }

        public RelayCommand AddCommand
        {
            get => _addCommand ?? (_addCommand = new RelayCommand(obj =>
            {
                try
                {
                    if (obj != null)
                    {
                        throw new NotImplementedException("TODO:");
                    }
                }
                catch (Exception ex)
                {
                    _dialogService.ShowErrorMessage(ex.Message);
                }
            }));
        }

        public RelayCommand DeleteCommand
        {
            get => _delCommand ?? (_delCommand = new RelayCommand(obj =>
            {
                try
                {
                    if (obj != null)
                    {
                        throw new NotImplementedException("TODO:");
                    }
                }
                catch (Exception ex)
                {
                    _dialogService.ShowErrorMessage(ex.Message);
                }
            }));
        }
        #endregion

        #region Constructors

        public TaskViewModel()
        {
            _dialogService = new MessageBoxService();
            Int32 id = UserModelSingleton.Instance().Id;
            var list = Init().Where(ts => ts.Executor.Group.ManagerId.Equals(id));
            Tasks       = new ObservableCollection<TaskModel>(list);
            
            FistNames   = new ObservableCollection<String>(list.Select(t => t.Executor.FirstName).Distinct());
            SecondNames = new ObservableCollection<String>(list.Select(t => t.Executor.SecondName).Distinct());
            LastNames   = new ObservableCollection<String>(list.Select(t => t.Executor.LastName).Distinct());
            using (var context = new EntityContext())
            {
                context.QuestStatus.Load();
                Statuses = new ObservableCollection<String>(context.QuestStatus.Local.Select(s => s.Value));
            }
        }
        #endregion

        #region Private Methods

        IEnumerable<TaskModel> Init()
        {
            using (var context = Core.DataBaseConnectionContext.GetContext())
            {
                context.Quest.Load();
                foreach (var quest in context.Quest.Local)
                {
                    var person = quest.Executors.Person;
                    yield return new TaskModel 
                    {
                        Id              = quest.Id,
                        Difficult       = Int32.Parse(quest.Difficult),
                        NatureOfWork    = quest.NatureOfWork.Value,
                        Status          = quest.QuestStatus.Value,
                        Executor        = new ExecutorModel().CreateFromPerson(person) as ExecutorModel
                    };
                }
            }
        }
        #endregion


    }
}
