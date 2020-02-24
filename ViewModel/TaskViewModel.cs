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
using Wsr1.View.TaskView;

namespace Wsr1.ViewModel
{

    public class TaskViewModel : Core.AbstractBaseModel
    {
        #region Private Members
        private RelayCommand _clearCommand;
        private RelayCommand _editCommand;
        private RelayCommand _addCommand;
        private RelayCommand _delCommand;

        private RelayCommand _statusFilterCommand;
        private RelayCommand _executorFilterCommand;

        private IDialogService _dialogService;
        private TaskModel _selectedModel;

        private ExecutorModel _selectedExecutor;
        #endregion

        #region PublicMembers
        public ObservableCollection<TaskModel> Tasks { get; set; }
        public ObservableCollection<String> FistNames { get; set; }
        public ObservableCollection<String> SecondNames { get; set; }
        public ObservableCollection<String> LastNames { get; set; }
        public ObservableCollection<String> Statuses { get; set; }
        public ObservableCollection<String> NatureOfWorks { get; set; }
        public ObservableCollection<ExecutorModel> Executors { get; set; }
        public ObservableCollection<String> Groups { get; set; }

        public TaskModel SelectedModel
        {
            get => _selectedModel;
            set
            {
                _selectedModel = value;
                OnPropertyChanged(nameof(SelectedModel));
            }
        }

        public ExecutorModel SelectedExecutor
        {
            get => _selectedExecutor;
            set
            {
                _selectedExecutor = value;
                OnPropertyChanged(nameof(SelectedExecutor));
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
                        var win = obj as TaskWindow;
                        win.StatusFilterBox.Text      = "";
                        win.FirstNameFillterBox.Text  = "";
                        win.SecondNameFillterBox.Text = "";
                        win.LastNameFillterBox.Text   = "";
                        win.TasksDataGrid.ItemsSource = Tasks;
                        _dialogService.ShowMessage("Фильтры сброщены");
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
                        var editWin = new EditTaskWindow(this);
                        editWin.DifficultBox.Text = SelectedModel.Difficult.ToString();
                        editWin.NatureOfWorkBox.Text = SelectedModel.NatureOfWork;
                        editWin.TitleBox.Text = ":C";
                        editWin.StatusBox.Text = SelectedModel.Status;
                        editWin.DateTimeBox.Text = SelectedModel.Time.ToString();
                        editWin.GroupBox.Text = SelectedModel.Executor.Group.Name;
                        editWin.ExecutorInGroup.ItemsSource = Executors.Where(ex => ex.Group.Name.Equals(SelectedModel.Executor.Group.Name));

                        editWin.GroupBox.SelectionChanged += (s, evArg) =>
                        {
                            editWin.ExecutorInGroup.ItemsSource = Executors.Where(ex => ex.Group.Name.Equals(editWin.GroupBox.SelectedItem as string)).Distinct();
                        };

                        editWin.BackButton.Click += (s, evArg) => editWin.Close();

                        editWin.DoneButton.Click += (s, evArg) =>
                        {
                            using (var context = new EntityContext())
                            {
                                var quest = context.Quest.FirstOrDefault(q => q.Id.Equals(SelectedModel.Id));
                                string status = editWin.StatusBox.SelectedItem as string;
                                string natureOfWork = editWin.NatureOfWorkBox.SelectedItem as string;
                                if (quest != null)
                                {
                                    quest.Title = editWin.TitleBox.Text;
                                    quest.IdStatus = context.QuestStatus.FirstOrDefault(st => st.Value.Equals(status)).Id;
                                    quest.IdNatureOfWork = context.NatureOfWork.FirstOrDefault(nt => nt.Value.Equals(natureOfWork)).Id;
                                    quest.Difficult = editWin.DifficultBox.Text;
                                }
                                context.SaveChanges();
                            }
                        };
                        editWin.ShowDialog();

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
                    var addwin = new AddTaskWindow(this);

                    addwin.DoneButton.Click += (s, evArg) =>
                    {
                        using (var context = new EntityContext())
                        {
                            var quest = new Quest();
                            string status = addwin.StatusBox.SelectedItem as string;
                            string natureOfWork = addwin.NatureOfWorkBox.SelectedItem as string;
                            context.Executors.Load();
                            if (quest != null)
                            {
                                quest.Title = addwin.TitleBox.Text;
                                quest.IdStatus = context.QuestStatus.FirstOrDefault(st => st.Value.Equals(status)).Id;
                                quest.IdNatureOfWork = context.NatureOfWork.FirstOrDefault(nt => nt.Value.Equals(natureOfWork)).Id;
                                quest.Difficult = addwin.DifficultBox.Text;
                                quest.ExecutorId = context.Executors.FirstOrDefault(ex => ex.Person.FirstName.Equals(SelectedExecutor.FirstName) && ex.Person.SecondName.Equals(SelectedExecutor.SecondName) && ex.Person.LastName.Equals(SelectedExecutor.LastName)).Id;
                            }
                            context.Quest.Add(quest);
                            context.SaveChanges();
                            _dialogService.ShowMessage("Задача Успешо создана");

                        }
                        using (var context = new EntityContext())
                        {
                            context.Quest.Load();
                            var quest = context.Quest.Local.Last();
                            var person = quest.Executors.Person;
                            Tasks.Add(new TaskModel
                            {
                                Id = quest.Id,
                                Difficult = Int32.Parse(quest.Difficult),
                                NatureOfWork = quest.NatureOfWork.Value,
                                Status = quest.QuestStatus.Value,
                                Executor = new ExecutorModel().CreateFromPerson(person) as ExecutorModel
                            });
                        }
                    };
                    addwin.ShowDialog();


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
                        TaskModel model = obj as TaskModel;
                        using (var context = new EntityContext())
                        {
                            var modelForDel = context.Quest.Find(model.Id);
                            context.Quest.Remove(modelForDel);
                            context.SaveChanges();
                            _dialogService.ShowMessage("Удаление завершено");
                            Tasks.Remove(model);
                        }
                    }
                    else
                        throw new NotImplementedException("Перед удалением выделите нужную строку !!!");

                }
                catch (Exception ex)
                {
                    _dialogService.ShowErrorMessage(ex.Message);
                }
            }));
        }


        public RelayCommand StatusFilterCommand
        {
            get => _statusFilterCommand ?? (_statusFilterCommand = new RelayCommand(obj =>
            {
                try
                {
                    if (obj != null)
                    {
                        var win = obj as TaskWindow;
                        string status = win.StatusFilterBox.SelectedItem as string;
                        win.TasksDataGrid.ItemsSource = new ObservableCollection<TaskModel>(Tasks.Where(ts => ts.Status.Equals(status)));
                        _dialogService.ShowMessage($"Задачи отфильтованны по статусу {status}");
                    }
                    else
                        throw new Exception("");

                }
                catch (Exception ex)
                {
                    _dialogService.ShowErrorMessage(ex.Message);
                }
               
            }));
        }

        public RelayCommand ExecutorFilterCommand
        {
            get => _executorFilterCommand ?? (_executorFilterCommand = new RelayCommand(obj =>
            {
                try
                {
                    if (obj != null)
                    {
                        var win = obj as TaskWindow;
                        string firstName    = win.FirstNameFillterBox.SelectedItem  as string;
                        string secondName   = win.SecondNameFillterBox.SelectedItem as string;
                        string lastName     = win.LastNameFillterBox.SelectedItem   as string;
                        string status       = win.StatusFilterBox.SelectedItem      as string; 
                        win.TasksDataGrid.ItemsSource = new ObservableCollection<TaskModel>
                        (
                            Tasks.Where(ts =>   ts.Executor.FirstName   .Equals(firstName)    ||
                                                ts.Executor.SecondName  .Equals(secondName)   || 
                                                ts.Executor.LastName    .Equals(lastName)     ||
                                                ts.Status               .Equals(status)
                                                ));
                        _dialogService.ShowMessage($"Задачи отфильтованны по ФИО");
                    }
                    else
                        throw new Exception("");

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
            Executors   = new ObservableCollection<ExecutorModel>(list.Select(t => t.Executor).Where(ex => ex.Group.ManagerId.Equals(id)));
            
            using (var context = new EntityContext())
            {
                Statuses        = new ObservableCollection<String>(context.QuestStatus.Select(s => s.Value));
                NatureOfWorks   = new ObservableCollection<String>(context.NatureOfWork.Select(s => s.Value));
                Groups          = new ObservableCollection<String>(context.Group.Where(gr => gr.IdManager.Equals(id)).Select(g => g.Name));
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