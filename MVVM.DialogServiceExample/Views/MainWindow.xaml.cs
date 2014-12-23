using System.Windows;
using MVVM.DialogServiceExample;

namespace MVVM.DialogServiceExample.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += (o, e) =>
            {
                var vm = Bootstrapper.Run();
                DataContext = vm;
                vm.Run();
            };
        }
    }
}