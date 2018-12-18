using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DesctopClient.ViewModels
{
    abstract class BaseViewModel : INotifyPropertyChanged
    {
        public abstract Task OnOpenAsync();
        public abstract Task OnOpenAsync(int id);

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        protected void OnPropertyChanged<T>(ref T target, T val, [CallerMemberName]string PropertyName = "")
        {
            target = val;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
