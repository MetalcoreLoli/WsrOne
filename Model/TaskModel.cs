using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wsr1.Model
{
    public class TaskModel : Core.AbstractBaseModel
    {
        #region Private Members

        private Int32 _id;
        private string _status;
        private string _natureOfWork;
        private ExecutorModel _executor;
        private Int32 _difficult;
        private DateTime _time;
        #endregion

        #region Public Properties

        public Int32 Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }
        public string NatureOfWork
        {
            get => _natureOfWork;
            set
            {
                _natureOfWork = value;
                OnPropertyChanged(nameof(NatureOfWork));
            }
        }


        public ExecutorModel Executor
        {
            get => _executor;
            set
            {
                _executor = value;
                OnPropertyChanged(nameof(Executor));
            }
        }
        public Int32 Difficult
        {
            get => _difficult;
            set
            {
                _difficult = value;
                OnPropertyChanged(nameof(Difficult));
            }
        }
        
        public DateTime Time
        {
            get => _time;
            set
            {
                _time = value;
                OnPropertyChanged(nameof(Time));
            }
        }
        #endregion
    }
}
