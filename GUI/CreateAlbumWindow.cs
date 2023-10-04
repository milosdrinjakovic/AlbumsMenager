using Nedelja9_2021_1.BusinessLogic;
using Nedelja9_2021_1.BusinessLogic.Albums;
using Nedelja9_2021_1.BusinessLogic.Artists;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nedelja9_2021_1.GUI
{
    public partial class CreateAlbumWindow : Form
    {
        public CreateAlbumWindow()
        {
            InitializeComponent();

            var operation = new SelectArtistsOperation();
            var result = OperationManager.Instance.ExecuteOperation(operation);

            if(result.IsSuccessfull)
            {
                cbArtists.DisplayMember = "Name";
                cbArtists.ValueMember = "Id";
                cbArtists.DataSource = result.Data as IEnumerable<ArtistDTO>;
            }

        }



        private void btnOtkazi_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnPotvrdi_Click(object sender, EventArgs e)
        {

            if(string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("Polje za naziv albuma ne sme biti prazno.");
                return;
            }

            var artist = cbArtists.SelectedItem as ArtistDTO;

            var albumToAdd = new AlbumDTO
            {
                Name = tbName.Text,
                ArtistId = artist.Id
            };

            var operation = new AddAlbumOperation(albumToAdd);

            var result = OperationManager.Instance.ExecuteOperation(operation);

            if(result.IsSuccessfull)
            {
                this.Dispose();
            } else
            {
                MessageBox.Show(result.Errors.First());
            }

        }
    }
}
