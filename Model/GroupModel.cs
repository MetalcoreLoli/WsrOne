using System;
using Wsr1.Core.EntityModels;

namespace Wsr1.Model
{
    public class GroupModel : Core.AbstractBaseModel
    {
        private Int32 _id;
        private Int32 _managerId;
        private string _name;
        private Manager _manager;

        public Int32 Id
        {
            get => _id;
            set 
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public Int32 ManagerId
        {
            get => _managerId;
            set
            {
                _managerId = value;
                OnPropertyChanged(nameof(ManagerId));
            }
        }

        public string Name
        {
            get => _name;
            set 
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public Manager Manager
        {
            get => _manager;
            set
            {
                _manager = value;
                OnPropertyChanged(nameof(Manager));
            }
        }

        public static GroupModel FromGroup(Group group)
        {
            GroupModel groupModel = new GroupModel();
            groupModel.Id = group.Id;
            groupModel.ManagerId = group.IdManager;
            groupModel.Name = group.Name;
            groupModel.Manager = group.Manager;
            return groupModel;
        }
    }
}