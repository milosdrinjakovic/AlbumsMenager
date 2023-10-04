using Nedelja9_2021_1.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nedelja9_2021_1.BusinessLogic.Albums
{
    public class DeleteAlbumOperation : EntitiesOperation
    {
        private int idToDelete;

        public DeleteAlbumOperation(int idToDelete)
        {
            if(idToDelete <= 0)
            {
                throw new InvalidOperationException("Identifikator ne moze biti manji ili jednak 0.");
            }

            this.idToDelete = idToDelete;
        }

        public override OperationResult Execute()
        {
            
            var album = Entities.Albums.Find(idToDelete);

            var result = new OperationResult();

            if(album == null)
            {
                result.Errors.Add("Album ne postoji.");
                
                return result;
            }

            if(album.Tracks.Any())
            {
                result.Errors.Add("Album se ne moze obrisati jer sadrzi pesme.");

                return result;
            }

            Entities.Albums.Remove(album);
            Entities.SaveChanges();

            return result;
        }
    }
}
