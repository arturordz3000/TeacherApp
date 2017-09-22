using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherHiring.ViewModels.Implementations
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public void OnPropertyChanged<T>(ref T current, ref T updated, string propertyName)
        {
            if (current == null || !current.Equals(updated))
            {
                current = updated;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
