using System;

namespace APBD._2.Models
{
    public class ArtistEvent
    {
        public int IdEvent { get; set; }
        public int IdArtist { get; set; }
        public Event Event { get; set; } //gdy klucz opcy to referencja do utworu
        public Artist Artist { get; set; }
        public DateTime PerformanceDate { get; set; }
    }
}