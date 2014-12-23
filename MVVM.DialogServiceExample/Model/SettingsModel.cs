using System;
using System.Threading;
using System.Threading.Tasks;

namespace MVVM.DialogServiceExample.Model
{
    public sealed class SettingsModel : ISettingsModel
    {
        public UserModel User { get; set; }

        public Task Save()
        {
            if (User == null) throw new ArgumentNullException();
            return Task.Factory.StartNew(() => Thread.Sleep(10)).ContinueWith(task => { // Init server call
                var t = Saved;
                if (t != null)
                {
                    t(this, new EventArgs());
                }
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public event EventHandler<EventArgs> Saved;
    }
}