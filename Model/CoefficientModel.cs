using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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

        public decimal Junior
        {
            get => _junior;
            set
            {
                _junior = value;
                OnPropertyChanged();
            }
        }

        public decimal Middle
        {
            get => _middle;
            set
            {
                _middle = value;
                OnPropertyChanged();
            }
        }
        public decimal Senior
        {
            get => _senior;
            set
            {
                _senior = value;
                OnPropertyChanged();
            }
        }
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        public int IdManager
        {
            get => _idManager;
            set
            {
                _idManager = value;
                OnPropertyChanged();
            }
        }

        public decimal CoefficientAnalis
        {
            get => _coefficientAnalis;
            set 
            {
                _coefficientAnalis = value;
                OnPropertyChanged();
            }
        }
        public decimal CoefficientInstall
        {
            get => _coefficientInstall;
            set
            {
                _coefficientInstall = value;
                OnPropertyChanged();
            }
        }

        public decimal CoefficientService
        {
            get => _coefficientService;
            set
            {
                _coefficientService = value;
                OnPropertyChanged();
            }
        }
        public decimal CoefficientTime
        {
            get => _coefficientTime;
            set
            {
                _coefficientTime = value;
                OnPropertyChanged();
            }
        }
        public decimal CoefficientDifficult
        {
            get => _coefficientDifficult;
            set
            {
                _coefficientDifficult = value;
                OnPropertyChanged();
            }
        }
        public decimal CoefficientMoney
        {
            get => _coefficientMoney;
            set
            {
                _coefficientMoney = value;
                OnPropertyChanged();
            }
        }
    }
}
