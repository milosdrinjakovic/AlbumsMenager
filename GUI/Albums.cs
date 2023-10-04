using Nedelja9_2021_1.BusinessLogic;
using Nedelja9_2021_1.BusinessLogic.Albums;
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
    public partial class AlbumsWindow : Form
    {
        public AlbumsWindow()
        {
            InitializeComponent();
            LoadGrid();
        }

        private void LoadGrid()
        {
            var operation = new SelectAlbumsOperation();

            var keyword = this.tbSearch.Text;

            if(!string.IsNullOrEmpty(keyword))
            {
                operation.Keyword = keyword;
            }

            OperationResult result = OperationManager.Instance.ExecuteOperation(operation);

            if (result.IsSuccessfull)
            {
                var albums = result.Data as IEnumerable<AlbumDTO>;

                this.dgvAlbums.DataSource = albums;

                this.dgvAlbums.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            else
            {
                MessageBox.Show(result.Errors.First());
            }
        }

        private AlbumDTO SelectedAlbum
        {
            get
            {
                if (this.dgvAlbums.SelectedRows.Count == 0)
                {
                    return null;
                }

                return this.dgvAlbums.SelectedRows[0].DataBoundItem as AlbumDTO;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(SelectedAlbum == null)
            {
                return;
            }

            var operation = new DeleteAlbumOperation(SelectedAlbum.Id);
            var result = OperationManager.Instance.ExecuteOperation(operation);

            if(!result.IsSuccessfull)
            {
                MessageBox.Show(result.Errors.First());
            } else
            {
                MessageBox.Show("Uspešno brisanje!");
                LoadGrid();
            }

        }

        private void izlazToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dodajNoviZapisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var createAlbumWindow = new CreateAlbumWindow();
            createAlbumWindow.Show();

            createAlbumWindow.Disposed += (x, y) =>
            {
                LoadGrid();
            };

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (SelectedAlbum == null)
            {
                return;
            }

            var editAlbumWindow = new EditAlbumWindow(SelectedAlbum);
            editAlbumWindow.Show();

            editAlbumWindow.Disposed += (x, y) =>
            {
                LoadGrid();
            };

        }
    }
}
