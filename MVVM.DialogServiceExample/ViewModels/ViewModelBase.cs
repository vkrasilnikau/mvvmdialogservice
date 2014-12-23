using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace MVVM.DialogServiceExample.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        protected void Notify(string name)
        {
            var t = PropertyChanged;
            if (t != null)
            {
                t(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}