using System;
using System.Collections.Generic;
using System.Windows;
using MVVM.DialogServiceExample.Model;

namespace MVVM.DialogServiceExample.ViewModels
{
    public sealed class DialogService : IDialogService
    {
        private Dictionary<string, Func<Window>> _map;
        private readonly Dictionary<string, Window> _opened = new Dictionary<string, Window>();

        public void ShowDialog(string token, object viewModel)
        {
            if (_map == null || !_map.ContainsKey(token)) return;
            var dialog = _map[token]();
            dialog.DataContext = viewModel;
            _opened.Add(token, dialog);
            dialog.ShowDialog();
        }

        public void CloseDialog(string token)
        {
            if (_opened.ContainsKey(token))
            {
                _opened[token].Close();
                _opened.Remove(token);
            }
        }

        public void Configure(Dictionary<string, Func<Window>> map)
        {
            _map = map;
        }
    }

    public static class Bootstrapper
    {
        public static IApplicationViewModel Run()
        {
            var model = new ApplicationModel(new SettingsModel(), new ModuleModel());
            return new ApplicationViewModel(model, new DialogService());
        }
    }
}