using combit.ListLabel25.Repository;
using combit.ReportServer.ClientApi.Objects;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ClientApiExample.Dialogs
{
    public partial class ViewRepositoryImageDialog : Form
    {

        private readonly TemplateRepositoryItem _repositoryItem;

        public ViewRepositoryImageDialog(TemplateRepositoryItem repositoryItem)
        {
            _repositoryItem = repositoryItem;
            InitializeComponent();
        }

        private async void ViewRepositoryImageDialog_Load(object sender, EventArgs e)
        {
            if (_repositoryItem.Type != RepositoryItemType.Image.Value)
            {
                MessageBox.Show("The selected repository item is not an image!");
                this.Close();
                return;
            }


            using (Stream content = await _repositoryItem.GetContentStreamAsync())
            {

                Image image = Image.FromStream(content);
                this.ClientSize = image.Size;
                pictureBox.Image = image;
            }
        }
    }
}
