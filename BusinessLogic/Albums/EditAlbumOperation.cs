using Nedelja9_2021_1.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nedelja9_2021_1.BusinessLogic.Albums
{
    public class EditAlbumOperation : EntitiesOperation
    {
        private readonly AlbumDTO dto;
        public EditAlbumOperation(AlbumDTO dto)
        {
            if(dto == null)
            {
                throw new NullReferenceException();
            }

            this.dto = dto;
        }

        public override OperationResult Execute()
        {
            var albumToEdit = Entities.Albums.Find(dto.Id);

            var result = new OperationResult();

            if(albumToEdit == null)
            {
                result.Errors.Add($"Album sa identifikatorom {dto.Id} ne postoji u sistemu.");
                return result;
            }

            albumToEdit.ArtistId = dto.ArtistId;
            albumToEdit.Title = dto.Name;

            Entities.SaveChanges(); 

            return result;
        }
    }
}
