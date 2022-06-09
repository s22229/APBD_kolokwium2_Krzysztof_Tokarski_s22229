using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium.Models.DTOs
{
    public class SomeSortOfAlbum
    {
        public string AlbumName { get; set; }
        public DateTime PublishDate { get; set; }

        public IEnumerable<SomeSortOfTracks> Tracks { get; set; }
        public IEnumerable<SomeSortOfMusicLabel> MusicLabels { get; set; }
    }
}
