using System;

namespace MVVM.DialogServiceExample.ViewModels
{
    public interface IModuleViewModel
    {
        string Login { get; }
        void Refresh();
    }
}