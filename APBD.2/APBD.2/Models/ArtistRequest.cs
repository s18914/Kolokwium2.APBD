using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD._2.Models
{
    public class ArtistRequest
    {
        public int IdArtist { get; set; }
        public int IdEvent { get; set; }
        public DateTime PerformanceDate { get; set; }
    }
}
