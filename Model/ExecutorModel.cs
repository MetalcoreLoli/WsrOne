using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wsr1.Core.EntityModels;

namespace Wsr1.Model
{
    public class ExecutorModel : UserModel
    {
        private GroupModel _group;


        public GroupModel Group
        {
            get => _group;
            set
            {
                _group = value;
                OnPropertyChanged(nameof(Group));
            }
        }

        public override UserModel CreateFromPerson(Person person)
        {
            var executor = base.CreateFromPerson(person);
            using (var context = new EntityContext())
            {
                context.Executors.Load();
                var group = context.Executors.FirstOrDefault(ex => ex.IdPerson.Equals(person.Id)).Group;
                (executor as ExecutorModel).Group = GroupModel.FromGroup(group);

            }
            return executor;
        }
    }
}
