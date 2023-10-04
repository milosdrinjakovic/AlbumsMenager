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
    public partial class EditAlbumWindow : Form
    {
        private readonly AlbumDTO dto;
        public EditAlbumWindow(AlbumDTO dto)
        {
            this.dto = dto;
            InitializeComponent();

            this.tbName.Text = dto.Name;

            var selectArtists = new SelectArtistsOperation();

            var result = OperationManager.Instance.ExecuteOperation(selectArtists);

            this.cbArtists.DisplayMember = "Name";
            this.cbArtists.ValueMember = "Id";

           if(result.IsSuccessfull)
           {
                var artists = result.Data as IEnumerable<ArtistDTO>;
                this.cbArtists.DataSource = artists;
                var itemToPreselect = artists.FirstOrDefault(x => x.Id == dto.ArtistId);

                if(itemToPreselect != null)
                {
                    this.cbArtists.SelectedItem = itemToPreselect;
                }

           } 
            else
            {
                MessageBox.Show("Doslo je do greske");
            }

        }

        private void btnPotvrdi_Click(object sender, EventArgs e)
        {
            dto.ArtistId = (cbArtists.SelectedItem as ArtistDTO).Id;
            dto.Name = tbName.Text;

            var operation = new EditAlbumOperation(dto);

            var result = OperationManager.Instance.ExecuteOperation(operation);


            if(result.IsSuccessfull)
            {
                this.Dispose();
            } else
            {
                MessageBox.Show(result.Errors.First());
            }

            
        }

        private void btnOtkazi_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
