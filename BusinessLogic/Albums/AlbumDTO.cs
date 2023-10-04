using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nedelja9_2021_1.BusinessLogic.Albums
{
    public class AlbumDTO : DTO
    {
        [DisplayName("Naziv Albuma")]
        public string Name { get; set; }
        [DisplayName("Broj Pesama")]
        public int TracksCount { get; set; }
        [Browsable(false)]
        public int ArtistId { get; set; }
    }
}
