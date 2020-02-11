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

namespace Wsr1.ViewModel
{
    public class CoefficientViewModel : Core.AbstractBaseModel
    {

        RelayCommand _acceptCommand;

        public RelayCommand Accept
        {
            get => _acceptCommand ?? (_acceptCommand = new RelayCommand(obj => 
            {
                try
                {
                    if (obj != null)
                    {
                        CoefficientModel model = obj as CoefficientModel;
                        Coefficients.Add(model);
                        using (var db = DataBaseConnectionContext.GetContext())
                        { 
                            
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }, model => Validator.IsValidModel(model as CoefficientModel)));
        }

        public ObservableCollection<CoefficientModel> Coefficients { get; set; }

        public CoefficientViewModel()
        {
            Coefficients = new ObservableCollection<CoefficientModel>(Init().Where(c => c.IdManager == UserModelSingleton.Instance().Id));
        }

        //this method for init list
        private IEnumerable<CoefficientModel> Init() 
        {
            using (var con =  DataBaseConnectionContext.GetContext())
            {
                foreach (var coenff in con.Coefficient.AsParallel())
                {
                    int id = UserModelSingleton.Instance().Id;
                    int salaryId = (int)con.Manager.FirstOrDefault(m => m.Id == id).SalaryId;
                    yield return new CoefficientModel
                    {
                        Id = coenff.Id,
                        IdManager = con.Manager.Where(m => m.CoefficientId == coenff.Id).Select(m => m.Id).First(),
                        CoefficientAnalis = coenff.CoefficientAnalis,
                        CoefficientDifficult = coenff.CoefficientDifficult,
                        CoefficientInstall = coenff.CoefficientInstall,
                        CoefficientMoney = coenff.CoefficientMoney,
                        CoefficientService = coenff.CoefficientService,
                        CoefficientTime = coenff.CoefficientTime,
                        Junior = con.Salary.FirstOrDefault(s => s.Id == salaryId).JuniorMin,
                        Middle = con.Salary.FirstOrDefault(s => s.Id == salaryId).MiddleMin,
                        Senior = con.Salary.FirstOrDefault(s => s.Id == salaryId).SeniorMin
                    };
                }
                
            }
        }
    }
}
