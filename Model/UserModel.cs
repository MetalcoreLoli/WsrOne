using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Wsr1.Core.ValidationModel.Attributes;
using Wsr1.Core.EnityModels;
using Wsr1.Core.Enums;

namespace Wsr1.Model
{
    public class UserModel : Core.AbstractBaseModel
    {
        int _id; 
        string _firstName;
        string _secondName;
        string _lastName;
        string _loginName;
        string _passwordName;
        Role _role;

        [NotNull]
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        [NotNull]
        public string FirstName
        {
            get => _firstName;
            set 
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        [NotNull]
        public string SecondName
        {
            get => _secondName;
            set
            {
                _secondName = value;
                OnPropertyChanged(nameof(SecondName));
            }
        }
        [NotNull]
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        [NotNull] 
        public string Login
        {
            get => _loginName;
            set
            {
                _loginName = value;
                OnPropertyChanged(nameof(Login));
            }
        }
        [NotNull]
        public string Password
        {
            get => _passwordName;
            set
            {
                _passwordName = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        [NotNull]
        public Role Role
        {
            get => _role;
            set
            {
                _role = value;
                OnPropertyChanged(nameof(Role));
            }
        }

        public UserModel CreateFromPerson(Person person)
        {
            Id = person.Id;
            FirstName = person.FirstName;
            SecondName = person.SecondName;
            LastName = person.LastName;
            Login = person.Login;
            Password = person.Password;
            using (var context = Core.DataBaseConnectionContext.GetContext())
                Role = (context.Manager.Select(manager => manager.IdPerson).Contains(person.Id)) ? Role.Manager : Role.Executer;
            return this;
        }
    }
}
