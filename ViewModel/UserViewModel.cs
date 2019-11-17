using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Wsr1.Model;
using Wsr1.Core.DialogServices;

namespace Wsr1.ViewModel
{
    public class UserViewModel
    {
        public ObservableCollection<UserModel> Users { get; private set; }
        IDialogService dialogService;

        private bool IsCurrectUser(string login, string password) => Users.Any(u => u.Login == login && u.Password == password);
        public UserModel CheckUserByLoginAndPassword(string login, string password)
        {
            try
            {
                if (IsCurrectUser(login, password))
                    return Users.First(u => u.Login == login && u.Password == password);
                else throw new Exception("Нет такого пользователя");
            }
            catch (Exception ex)
            {
                (dialogService as MessageBoxService).Message = ex.Message;
                dialogService.Show();
            }
            return null;
        }
        
        public UserViewModel()
        {
            dialogService = new MessageBoxService("");
            Users = new ObservableCollection<UserModel>(InitUsers());
        }

        public List<UserModel> InitUsers() 
        {
            var temp = new List<UserModel>();
            using (var con = Core.DataBaseConnectionContext.GetContext())
            {
                foreach (var user in con.Person.AsParallel())
                {
                    temp.Add(new UserModel
                    {
                        FirstName   = user.FirstName,
                        SecondName  = user.SecondName,
                        LastName    = user.LastName,
                        Login       = user.Login,
                        Password    = user.Password,
                        Role        = (con.Manager.Select(m => m.IdPerson).Contains(user.Id)) ? "Менеджер" : "Исполнитель"
                    });
                }
                return temp;
            }
        }
    }
}
