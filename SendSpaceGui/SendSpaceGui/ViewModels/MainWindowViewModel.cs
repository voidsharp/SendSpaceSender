using SendSpaceGui.Annotations;
using SendSpaceGui.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SendSpaceGui.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private MainWindowModel model;
        public MainWindowViewModel(MainWindowModel model)
        {
            this.model = model;
        }

        public void FilesDropped(IEnumerable<string> fileList)
        {
            model.FilesDropped(fileList);
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
