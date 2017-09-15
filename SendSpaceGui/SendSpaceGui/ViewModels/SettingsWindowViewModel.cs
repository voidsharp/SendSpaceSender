using SendSpaceGui.Annotations;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SendSpaceGui.ViewModels
{
    public class SettingsWindowViewModel : INotifyPropertyChanged
    {
        private string sendSpaceApiKey;

        public string SendSpaceApiKey
        {
            get => sendSpaceApiKey;
            set
            {
                sendSpaceApiKey = value;
                if (value != sendSpaceApiKey)
                {
                    OnPropertyChanged(nameof(SendSpaceApiKey));
                }
            }
        }


        #region prop changed

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
