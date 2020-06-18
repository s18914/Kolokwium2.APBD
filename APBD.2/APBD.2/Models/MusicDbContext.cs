using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD._2.Models
{
    public class MusicDbContext : DbContext
    {
        //obiekty reprezentujące tabele w bazie danych
        public DbSet<EventOrganiser> EventOrganisers { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Organiser> Organisers { get; set; }
        public DbSet<ArtistEvent> ArtistEvents { get; set; }

        public MusicDbContext()
        {

        }

        public MusicDbContext(DbContextOptions options) : base(options)
        {

        }
        //ograniczenia
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //po kolei dla tabelek robie ograniczenia
            modelBuilder.Entity<Organiser>(opt =>
            {
                opt.HasKey(p => p.IdOrganiser);          //PK
                opt.Property(p => p.IdOrganiser)         
                    .ValueGeneratedOnAdd();
                opt.Property(p => p.Name)
                    .HasMaxLength(50)                     //string max 50
                    .IsRequired();                        //not null
                opt.HasMany(p => p.EventOrganisers)
                    .WithOne(p => p.Organiser)
                    .HasForeignKey(p => p.IdOrganiser);  //opcjonalne

            });
            modelBuilder.Entity<ArtistEvent>(opt =>
            {
                opt.HasKey(p => p.IdEvent);
                opt.HasKey(p => p.IdArtist);
                //opt.Property(p => p.IdMusicianTrack)         
                //    .ValueGeneratedOnAdd();
                opt.HasOne(p => p.Artist)
                    .WithMany(p => p.ArtistEvents)
                    .HasForeignKey(p => p.IdArtist);
                opt.HasOne(p => p.Event)
                    .WithMany(p => p.ArtistEvents)
                    .HasForeignKey(p => p.IdEvent);

            });
            modelBuilder.Entity<Event>(opt =>
            {
                opt.HasKey(p => p.IdEvent);         
                opt.Property(p => p.IdEvent)         
                    .ValueGeneratedOnAdd();
                opt.Property(p => p.Name)
                    .HasMaxLength(100)  
                    .IsRequired();

            });
            modelBuilder.Entity<EventOrganiser>(opt =>
            {
                opt.HasKey(p => p.IdEvent);
                opt.HasKey(p => p.IdOrganiser);
                opt.HasOne(p => p.Organiser)
                    .WithMany(p => p.EventOrganisers)
                    .HasForeignKey(p => p.IdOrganiser);
                opt.HasOne(p => p.Event)
                    .WithMany(p => p.EventOrganisers)
                    .HasForeignKey(p => p.IdEvent);

            });
            modelBuilder.Entity<Artist>(opt =>
            {
                opt.HasKey(p => p.IdArtist);
                opt.Property(p => p.IdArtist)
                    .ValueGeneratedOnAdd();
                opt.Property(p => p.NickName)
                    .HasMaxLength(20)
                    .IsRequired();

            });

        }

    }
}
