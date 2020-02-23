using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Wsr1.Core;
using Wsr1.Core.EntityModels;
using Wsr1.Core.ValidationModel.Attributes;

namespace Wsr1.Model
{
    public class CoefficientModel : Core.AbstractBaseModel
    {
        int _id;
        int _idManager;
        decimal _coefficientAnalis;
        decimal _coefficientInstall;
        decimal _coefficientService;
        decimal _coefficientTime;
        decimal _coefficientDifficult;
        decimal _coefficientMoney;
        decimal _junior;
        decimal _middle;
        decimal _senior;

        [NotNull]
        public decimal Junior
        {
            get => _junior;
            set
            {
                _junior = value;
                OnPropertyChanged();
            }
        }

        [NotNull]
        public decimal Middle
        {
            get => _middle;
            set
            {
                _middle = value;
                OnPropertyChanged();
            }
        }
        
        [NotNull]
        public decimal Senior
        {
            get => _senior;
            set
            {
                _senior = value;
                OnPropertyChanged();
            }
        }

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
        public int IdManager
        {
            get => _idManager;
            set
            {
                _idManager = value;
                OnPropertyChanged();
            }
        }

        [NotNull, Range(0, 1)] 
        public decimal CoefficientAnalis
        {
            get => _coefficientAnalis;
            set 
            {
                _coefficientAnalis = value;
                OnPropertyChanged();
            }
        }
        [NotNull, Range(0, 1)]
        public decimal CoefficientInstall
        {
            get => _coefficientInstall;
            set
            {
                _coefficientInstall = value;
                OnPropertyChanged();
            }
        }

        [NotNull, Range(0, 1)]
        public decimal CoefficientService
        {
            get => _coefficientService;
            set
            {
                _coefficientService = value;
                OnPropertyChanged();
            }
        }
        [NotNull]
        public decimal CoefficientTime
        {
            get => _coefficientTime;
            set
            {
                _coefficientTime = value;
                OnPropertyChanged();
            }

        }
        
        [NotNull]
        public decimal CoefficientDifficult
        {
            get => _coefficientDifficult;
            set
            {
                _coefficientDifficult = value;
                OnPropertyChanged();
            }
        }

        [NotNull]
        public decimal CoefficientMoney
        {
            get => _coefficientMoney;
            set
            {
                _coefficientMoney = value;
                OnPropertyChanged();
            }
        }

        public CoefficientModel CreateFrom(Coefficient coefficient)
        {
            using (var con = DataBaseConnectionContext.GetContext())
            {
                int id = UserModelSingleton.Instance().Id;
                con.Manager.Load();
                int salaryId = (int)con.Manager.Local.FirstOrDefault(m => m.Id == id).IdSalary;
                Id = coefficient.Id;
                IdManager = con.Manager.Where(m => m.IdCoefficient == coefficient.Id).Select(m => m.Id).First();
                CoefficientAnalis = coefficient.CoefficientAnalis;
                CoefficientDifficult = coefficient.CoefficientDifficult;
                CoefficientInstall = coefficient.CoefficientInstall;
                CoefficientMoney = coefficient.CoefficientMoney;
                CoefficientService = coefficient.CoefficientService;
                CoefficientTime = coefficient.CoefficientTime;
                
                Junior = con.Salary.FirstOrDefault(s => s.Id == salaryId).JuniorMin;
                Middle = con.Salary.FirstOrDefault(s => s.Id == salaryId).MiddleMin;
                Senior = con.Salary.FirstOrDefault(s => s.Id == salaryId).SeniorMin;
            }
            return this;
        }
    }
}
