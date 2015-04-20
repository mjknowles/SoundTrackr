namespace SoundTrackr.Repository.Migrations
{
    using SoundTrackr.Repository.DatabaseModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Spatial;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SoundTrackr.Repository.SoundTrackrContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SoundTrackr.Repository.SoundTrackrContext context)
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

            context.Tracks.Add(
                new TrackDb
                {
                    UserId = "f176cb13-aaf6-49a4-ba34-a1ec65e3d358",
                    TrackStart = DateTime.Now,
                    TrackEnd = DateTime.Now.AddMinutes(2),
                    TrackStats = new System.Collections.Generic.List<TrackStatDb>
                    {
                        
                        new TrackStatDb{Location = DbGeography.FromText("POINT(33.656415 -86.527409)", 4326), Timestamp = DateTime.Now},
                        new TrackStatDb{Location = DbGeography.FromText("POINT(34.787571 -86.939557)", 4326), Timestamp = DateTime.Now.AddMinutes(1)},
                        new TrackStatDb{Location = DbGeography.FromText("POINT(36.145660 -86.795120)", 4326), Timestamp = DateTime.Now.AddMinutes(2)}
                    }                    
                }
            );
        }
    }
}
