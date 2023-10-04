using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nedelja9_2021_1.BusinessLogic.Albums
{
    public class AddAlbumOperation : EntitiesOperation
    {
        private readonly AlbumDTO _dto;
        public AddAlbumOperation(AlbumDTO dto)
        {
            _dto = dto;
        }
             
        public override OperationResult Execute()
        {
            var result = new OperationResult();

            if(Entities.Albums.Any(x => x.ArtistId == _dto.ArtistId && x.Title == _dto.Name))
            {
                result.Errors.Add("Album sa istim nazivom za istog izvodjaca vec postoji u sistemu.");
                return result;
            }

            if(!Entities.Artists.Any(x => x.ArtistId == _dto.ArtistId))
            {
                result.Errors.Add("Prosledjeni izvodjac ne postoji u sistemu.");
                return result;
            }

            Entities.Albums.Add(new DataAccess.Album
            {
                ArtistId = _dto.ArtistId,
                Title = _dto.Name
            });

            Entities.SaveChanges();

            return result;
        }
    }
}
