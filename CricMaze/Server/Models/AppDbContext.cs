using CricMaze.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CricMaze.Server.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {

        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Code to seed data

            modelBuilder.Entity<Team>().HasData(
               new Team { TeamId = 1, TeamName = "RCB" });
            modelBuilder.Entity<Team>().HasData(
              new Team { TeamId = 2, TeamName = "Mumbai Indians" });
            modelBuilder.Entity<Team>().HasData(
              new Team { TeamId = 3, TeamName = "Rajasthan Royals" });
            modelBuilder.Entity<Team>().HasData(
              new Team { TeamId = 4, TeamName = "SRH" });
            modelBuilder.Entity<Team>().HasData(
              new Team { TeamId = 5, TeamName = "CSK" });
            modelBuilder.Entity<Team>().HasData(
              new Team { TeamId = 6, TeamName = "Delhi Capitals" });
            modelBuilder.Entity<Team>().HasData(
              new Team { TeamId = 7, TeamName = "Punjab Kings" });
            modelBuilder.Entity<Team>().HasData(
              new Team { TeamId = 8, TeamName = "KKR" });



            modelBuilder.Entity<Player>().HasData(new Player
            {
                PlayerId = 1,
                FirstName = "Virat",
                LastName = "Kohli",
                Country = "India",
                Matches = 254,
                Runs = 12123,
                Highest = 183,
                Wickets = 15,
                //DateOfBrith = new DateTime(1988, 11, 05),
                Role = Role.Batsman,
                TeamId = 1,
                //PhotoPath = "images/Virat.png"
            });

            modelBuilder.Entity<Player>().HasData(new Player
            {
                PlayerId = 2,
                FirstName = "Jasprit",
                LastName = "Bumrah",
                Country = "India",
                Matches = 90,
                Runs = 545,
                Highest = 26,
                Wickets = 165,
                // DateOfBrith = new DateTime(1993, 12, 06),
                Role = Role.Bowler,
                TeamId = 2,
                // PhotoPath = "images/Jasprit.jpg"
            });

            modelBuilder.Entity<Player>().HasData(new Player
            {
                PlayerId = 3,
                FirstName = "Ben",
                LastName = "Stokes",
                Country = "England",
                Matches = 152,
                Runs = 5252,
                Highest = 139,
                Wickets = 145,
                // DateOfBrith = new DateTime(199, 06, 04),
                Role = Role.Allrounder,
                TeamId = 3,
                // PhotoPath = "images/Ben.png"
            });

            modelBuilder.Entity<Player>().HasData(new Player
            {
                PlayerId = 4,
                FirstName = "David",
                LastName = "Warner",
                Country = "Australia",
                Matches = 205,
                Runs = 8989,
                Highest = 160,
                Wickets = 11,
                // DateOfBrith = new DateTime(1986, 10, 27),
                Role = Role.Batsman,
                TeamId = 4,
                // PhotoPath = "images/Warner.png"
            });

            modelBuilder.Entity<Player>().HasData(new Player
            {
                PlayerId = 5,
                FirstName = "Dwayne",
                LastName = "Bravo",
                Country = "West Indies",
                Matches = 192,
                Runs = 4258,
                Highest = 114,
                Wickets = 212,
                // DateOfBrith = new DateTime(1983, 10, 07),
                Role = Role.Allrounder,
                TeamId = 5,
                // PhotoPath = "images/Bravo.png"
            });

            modelBuilder.Entity<Player>().HasData(new Player
            {
                PlayerId = 6,
                FirstName = "Rishabh",
                LastName = "Pant",
                Country = "India",
                Matches = 69,
                Runs = 2152,
                Highest = 87,
                Wickets = 0,
                // DateOfBrith = new DateTime(1997, 10, 04),
                Role = Role.Batsman,
                TeamId = 6,
                // PhotoPath = "images/Pant.png"
            });

            modelBuilder.Entity<Player>().HasData(new Player
            {
                PlayerId = 7,
                FirstName = "Aiden",
                LastName = "Markram",
                Country = "South Africa",
                Matches = 76,
                Runs = 2545,
                Highest = 134,
                Wickets = 24,
                //DateOfBrith = new DateTime(1994, 10, 04),
                Role = Role.Batsman,
                TeamId = 7,
                // PhotoPath = "images/Markram.png"
            });

            modelBuilder.Entity<Player>().HasData(new Player
            {
                PlayerId = 8,
                FirstName = "Lockie",
                LastName = "Ferguson",
                Country = "New Zealand",
                Matches = 80,
                Runs = 824,
                Highest = 40,
                Wickets = 146,
                // DateOfBrith = new DateTime(1991, 06, 13),
                Role = Role.Bowler,
                TeamId = 8,
                // PhotoPath = "images/Lockie.png"
            });
        }
    }
}
