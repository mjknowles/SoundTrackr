namespace SoundTrackr.Repository.Migrations
{
    using SoundTrackr.Repository.DatabaseModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Spatial;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SoundTrackr.Repository.Context.SoundTrackrContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SoundTrackr.Repository.Context.SoundTrackrContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Tracks.AddOrUpdate(
                new TrackDb
                {
                    UserId = "f176cb13-aaf6-49a4-ba34-a1ec65e3d358",
                    Name = "Nash to Bham",
                    TrackStart = DateTime.Now,
                    TrackEnd = DateTime.Now.AddMinutes(2),
                    TrackStats = new System.Collections.Generic.List<TrackStatDb>
                    {
                        
                        new TrackStatDb{Location = DbGeography.FromText("POINT(-86.527409 33.656415)", 4326), Timestamp = DateTime.Now, Song = "Sleepwalking", Artist = "Chain Gang of 1974" },
                        new TrackStatDb{Location = DbGeography.FromText("POINT(-86.939557 34.787571)", 4326), Timestamp = DateTime.Now.AddMinutes(1), Song = "Throw It Up", Artist = "Yelawolf" },
                        new TrackStatDb{Location = DbGeography.FromText("POINT(-86.795120 36.145660)", 4326), Timestamp = DateTime.Now.AddMinutes(2), Song = "10 Bands", Artist = "Drake" }
                    }                    
                },
                new TrackDb
                {
                    UserId = "f176cb13-aaf6-49a4-ba34-a1ec65e3d358",
                    Name = "Apt to Taco Mamacita",
                    TrackStart = DateTime.Now.AddMinutes(60),
                    TrackEnd = DateTime.Now.AddMinutes(64),
                    TrackStats = new System.Collections.Generic.List<TrackStatDb>
                    {
                        
                        new TrackStatDb{Location = DbGeography.FromText("POINT(-86.795372 36.145263)", 4326), Timestamp = DateTime.Now.AddMinutes(60), Song = "All Day", Artist = "Kanye West" },
                        new TrackStatDb{Location = DbGeography.FromText("POINT(-86.795672 36.143669)", 4326), Timestamp = DateTime.Now.AddMinutes(62), Song = "Seasons", Artist = "Future Islands" },
                        new TrackStatDb{Location = DbGeography.FromText("POINT(-86.791488 36.143218)", 4326), Timestamp = DateTime.Now.AddMinutes(64), Song = "Peaches", Artist = "In the Valley Below" }
                    }                    
                },
                new TrackDb
                {
                    UserId = "f176cb13-aaf6-49a4-ba34-a1ec65e3d358",
                    Name = "Apt to Satco",
                    TrackStart = DateTime.Now.AddMinutes(120),
                    TrackEnd = DateTime.Now.AddMinutes(124),
                    TrackStats = new System.Collections.Generic.List<TrackStatDb>
                    {
                        
                        new TrackStatDb{Location = DbGeography.FromText("POINT(-86.795372 36.145263)", 4326), Timestamp = DateTime.Now.AddMinutes(120), Song = "Busy Earnin'", Artist = "Jungle" },
                        new TrackStatDb{Location = DbGeography.FromText("POINT(-86.799513 36.146078)", 4326), Timestamp = DateTime.Now.AddMinutes(122), Song = "My Type", Artist = "Saint Motel" },
                        new TrackStatDb{Location = DbGeography.FromText("POINT(-86.799449 36.146701)", 4326), Timestamp = DateTime.Now.AddMinutes(124), Song = "Walkin on a Pretty Day", Artist = "Kurt Vile" }
                    }                    
                });
        }
    }
}
