﻿using DuplexCenima.Models;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace DuplexCenima.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Movie>().HasOne(am => new
            {
                am.ActorId,
                am.MoiveId
            });
            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Movies).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.MoiveId);
            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Actors).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.ActorId);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor_Movie> Actors_Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Producer> Producers { get; set; }

    }
}
   