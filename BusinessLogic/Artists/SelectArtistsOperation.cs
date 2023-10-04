using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nedelja9_2021_1.BusinessLogic.Artists
{
    public class SelectArtistsOperation : EntitiesOperation
    {
        public override OperationResult Execute()
        {
            return new OperationResult
            {
                Data = Entities.Artists.Select(x => new ArtistDTO
                {
                    Id = x.ArtistId,
                    Name = x.Name
                }).ToList()
            };
        }
    }
}
