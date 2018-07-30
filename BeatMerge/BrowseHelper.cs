using System.Windows.Forms;

namespace BeatMerge
{
    public static class BrowseHelper
    {
        public static void BrowseDialog(object sender)
        {
            var currentTextBox = (TextBox)sender;
            var folderDialog = new FolderBrowserDialog();
            folderDialog.ShowNewFolderButton = false;

            DialogResult result = folderDialog.ShowDialog();

            if (result == DialogResult.OK)
                currentTextBox.Text = folderDialog.SelectedPath;
        }
        public static string BrowseDialog()
        {
            var folderDialog = new FolderBrowserDialog();
            folderDialog.ShowNewFolderButton = false;

            DialogResult result = folderDialog.ShowDialog();

            if (result == DialogResult.OK)
                return folderDialog.SelectedPath;

            return null;
        }

        public static void BrowseFile(object sender)
        {
            var currentTextBox = (TextBox)sender;
            var fileDialog = new OpenFileDialog();
            fileDialog.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";

            DialogResult result = fileDialog.ShowDialog();

            if (result == DialogResult.OK)
                currentTextBox.Text = fileDialog.FileName;
        }
    }
}
