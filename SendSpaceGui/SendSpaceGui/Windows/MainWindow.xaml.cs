using System;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace SendSpaceGui.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                // Assuming you have one file that you care about, pass it off to whatever
                // handling code you have defined.
                FileName.Content = FormatFilesList(files);
            }
        }

        string FormatFilesList(string[] filesList)
        {
            var sb = new StringBuilder();

            foreach (var fileName in filesList)
            {
                sb.Append(fileName + Environment.NewLine);
            }

            return sb.ToString();
        }

        private void MainWindow_OnMouseEnter(object sender, MouseEventArgs e)
        {
            Grid.Opacity = 0.25D;
            Opacity = 0.25D;
        }


        private void MainWindow_OnMouseLeave(object sender, MouseEventArgs e)
        {
            Grid.Opacity = 1D;
            Opacity = 1D;
        }
    }
}
