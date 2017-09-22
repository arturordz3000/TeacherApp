﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherHiring.ViewModels.Implementations
{
    public abstract class AsyncViewModel : BaseViewModel
    {
        private bool isBusy = false;

        public bool IsBusy
        {
            set
            {
                if (isBusy != value)
                {
                    isBusy = value;
                    OnPropertyChanged("IsBusy");
                    OnBusyChange();
                }
            }

            get
            {
                return isBusy;
            }
        }

        public abstract void OnBusyChange();
    }
}
