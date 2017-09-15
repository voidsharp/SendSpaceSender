using System.Collections.Generic;

namespace SendSpaceGui.Models
{
    public class MainWindowModel
    {
        private RootModel model;

        public MainWindowModel(RootModel model)
        {
            this.model = model;
        }

        public void FilesDropped(IEnumerable<string> droppedFilesList)
        {
            model.FilesDropped(droppedFilesList);
        }
    }
}
