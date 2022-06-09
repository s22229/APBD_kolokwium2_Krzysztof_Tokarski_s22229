using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium.Models
{
    public class MyDbContext : DbContext
    {
        protected MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Musican> Musicans { get; set; }
        public DbSet<MusicanTrack> MusicanTracks { get; set; }
        public DbSet<MusicLabel> MusicLabels { get; set; }
        public DbSet <Track> Tracks { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Album>(a =>
            {
                a.HasKey(e => e.IdAlbum);
                a.Property(e => e.AlbumName).IsRequired().HasMaxLength(30);
                a.Property(e => e.PublishDate);
                a.HasOne(e => e.MusicLabel).WithMany(e => e.Albums).HasForeignKey(e => e.IdMusicLabel);

                a.HasData(
                
                        new Album { IdAlbum = 1, AlbumName = "DobryAlbum", PublishDate = DateTime.Parse("2022-01-02"), IdMusicLabel = 1 },
                        new Album { IdAlbum = 2, AlbumName = "LepszyAlbum", PublishDate = DateTime.Parse("2022-05-12"), IdMusicLabel = 2}
                
                );
            });

            modelBuilder.Entity<Musican>(m =>
            {
                m.HasKey(e => e.IdMusican);
                m.Property(e => e.FirstName).IsRequired().HasMaxLength(30);
                m.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                m.Property(e => e.Nickname).HasMaxLength(20);

                m.HasData(
                        new Musican { IdMusican = 1, FirstName = "Alfred", LastName = "Alfredo", Nickname = "Alf"},
                        new Musican { IdMusican = 2, FirstName = "Zbigniew", LastName = "Ziobro", Nickname = "Wieli Z"}
                );
            });


            modelBuilder.Entity<Track>(t =>
            {
                t.HasKey(e => e.IdTrack);
                t.Property(e => e.TrackName).IsRequired().HasMaxLength(20);
                t.Property(e => e.Duration).IsRequired();
                t.HasOne(e => e.Album).WithMany(e => e.Tracks).HasForeignKey(e => e.IdAlbum);

                t.HasData(
                        new Track { IdTrack = 1, TrackName = "Traczek", Duration = 4.5f, IdAlbum = 1},
                        new Track { IdTrack = 2, TrackName = "FajnyTraczek", Duration = 3.5f, IdAlbum = 2}
                );

            });

            modelBuilder.Entity<MusicLabel>(m => {

                m.HasKey(e => e.IdMusicLabel);
                m.Property(e => e.Name).IsRequired().HasMaxLength(50);

                m.HasData(
                        new MusicLabel { IdMusicLabel = 1, Name = "Wytwornia1"},
                        new MusicLabel { IdMusicLabel = 2, Name = "Wytwornia2"}
                );
            });

            modelBuilder.Entity<MusicanTrack>(m => {

                m.HasKey(e => new { e.IdMusican, e.IdTrack });
                m.HasOne(e => e.Musican).WithMany(e => e.MusicanTracks).HasForeignKey(e => e.IdMusican);
                m.HasOne(e => e.Track).WithMany(e => e.MusicanTracks).HasForeignKey(e => e.IdTrack);

                m.HasData(
                        new MusicanTrack { IdMusican = 1, IdTrack = 1},
                        new MusicanTrack { IdMusican = 2, IdTrack = 2}
                );
            
            });
           
        }

    }
}
