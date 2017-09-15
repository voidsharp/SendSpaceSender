using Hardcodet.Wpf.TaskbarNotification;
using SendSpaceGui.Properties;

namespace SendSpaceGui
{
    public class AppCore
    {
        private TaskbarIcon taskBar;



        public AppCore()
        {
            taskBar = new TaskbarIcon();
            taskBar.Icon = Resources.favicon;

        }
    }
}
