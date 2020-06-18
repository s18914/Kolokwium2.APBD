using APBD._2.Exceptions;
using APBD._2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD._2.Services
{
    public class SqlServerMusicDbService : IMusicDbService
    {
        private readonly MusicDbContext _context;
        public SqlServerMusicDbService(MusicDbContext context)
        {
            _context = context;
        }
        public Artist GetArtist(int id)
        {
           
            var artist = _context.Artists
                            .Include(m => m.ArtistEvents)
                            .SingleOrDefault(m => m.IdArtist == id); 
            if(artist == null)
            {
                throw new ArtistDoesNotExistException($"Artist with this ID does not exists!");
            }

            artist.ArtistEvents = artist.ArtistEvents.OrderByDescending(ml => ml.PerformanceDate).ToList();

            return artist;
        }

        public void UpgradeDate(ArtistRequest request)
        {
            var musician = _context.ArtistEvents
                .Include(x => x.Event)
                .SingleOrDefault(m => m.IdArtist == request.IdArtist && 
                m.IdEvent == request.IdEvent);

            if (musician == null)
            {
                throw new ArtistDoesNotExistException($"Artist with this ID does not exists!");
            }

            if (request.PerformanceDate < DateTime.Now)
            {
                throw new Exception("Invalid Performancedate!");
            }

            if (musician.Event.StartDate < request.PerformanceDate || musician.Event.EndDate > request.PerformanceDate)
            {
                throw new Exception("Invalid Performancedate!");
            }

            musician.PerformanceDate = request.PerformanceDate;

            _context.SaveChanges();
        }

    }
}
