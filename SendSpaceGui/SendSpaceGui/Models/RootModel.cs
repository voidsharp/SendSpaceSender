using SendSpaceGui.Windows;
using System.Collections.Generic;

namespace SendSpaceGui.Models
{
    public class RootModel
    {
        private MainWindow mainWindow;
        private SettingsWindow settingsWindow;
        void CreateWindows()
        {
            mainWindow = new MainWindow();
            settingsWindow = new SettingsWindow();
        }

        public void FilesDropped(IEnumerable<string> droppedFilesList)
        {
            throw new System.NotImplementedException();
        }
    }
}
