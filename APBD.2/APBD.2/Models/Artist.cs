using System.Collections;
using System.Collections.Generic;

namespace APBD._2.Models
{
    public class Artist
    {
        public int IdArtist { get; set; }
        public string NickName { get; set; }
        public ICollection<ArtistEvent> ArtistEvents { get; set; }
    }
}