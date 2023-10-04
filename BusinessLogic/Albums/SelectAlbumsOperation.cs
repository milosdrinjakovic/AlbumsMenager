using Nedelja9_2021_1.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nedelja9_2021_1.BusinessLogic.Albums
{
    public class SelectAlbumsOperation : EntitiesOperation
    {
        public string Keyword { get; set; }

        public override OperationResult Execute()
        {

            var query = Entities.Albums.AsQueryable(); 

            if(Keyword != null) 
            {
                query = query.Where(x => x.Title.ToLower().Contains(Keyword.ToLower()));
            }

            var albums = query.Select(x => new AlbumDTO
            {
                Id = x.AlbumId,
                Name = x.Title,
                ArtistId = x.ArtistId,
                TracksCount = x.Tracks.Count
            }).ToList();


            return new OperationResult
            {
                Data = albums
            };
        }
    }
}
