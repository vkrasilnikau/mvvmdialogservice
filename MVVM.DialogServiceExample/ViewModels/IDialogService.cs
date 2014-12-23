using System;
using System.Collections.Generic;
using System.Windows;

namespace MVVM.DialogServiceExample.ViewModels
{
    public interface IDialogService
    {
        void Configure(Dictionary<string, Func<Window>> map);
        void ShowDialog(string token, object viewModel);
        void CloseDialog(string token);
    }
}