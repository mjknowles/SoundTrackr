namespace SoundTrackr.Repository.Migrations
{
    using DatabaseModels;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Spatial;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Text;

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

            context.Users.AddOrUpdate(
                // password is testUser_1
                new UserDb
                {
                    Id = "9feb9a5d-2906-42c5-adc1-9a106785f879",
                    Email = "testuser@test.com",
                    EmailConfirmed = false,
                    PasswordHash = "AFNGxWiULuFWlfL/mxwYkUCQtNhLn+RRV5/5p6w6vdCESHqrgP1AWCkjK+CYvwoFNg==",
                    SecurityStamp = "8f76743d - 1757 - 48ee - bfd1 - f9e0082a2956",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = false,
                    AccessFailedCount = 0,
                    UserName = "testuser@test.com"
                }
            );

            context.Tracks.AddOrUpdate(t => t.Name,
                new TrackDb
                {
                    UserId = "9feb9a5d-2906-42c5-adc1-9a106785f879",
                    Name = "Nash to Bham",
                    TrackStart = DateTime.Now,
                    TrackEnd = DateTime.Now.AddMinutes(2),
                    SubTracks = new List<SubTrackDb>
                    {
                        new SubTrackDb {
                            StartTimestamp = DateTime.Now,
                            Artist = "Chain Gang of 1974",
                            Song = "Sleepwalking",
                            TrackStats = new List<TrackStatDb> {
                                new TrackStatDb{Location = DbGeography.FromText("POINT(-86.527409 33.656415)", 4326), Timestamp = DateTime.Now },
                                new TrackStatDb{Location = DbGeography.FromText("POINT(-86.939557 34.787571)", 4326), Timestamp = DateTime.Now.AddMinutes(1) },
                            }
                        },
                        new SubTrackDb {
                            StartTimestamp = DateTime.Now,
                            Artist = "Drake",
                            Song = "10 Bands",
                            TrackStats = new List<TrackStatDb> {
                                new TrackStatDb{Location = DbGeography.FromText("POINT(-86.939557 34.787571)", 4326), Timestamp = DateTime.Now.AddMinutes(1) },
                                new TrackStatDb{Location = DbGeography.FromText("POINT(-86.795120 36.145660)", 4326), Timestamp = DateTime.Now.AddMinutes(2) }
                            }
                        }
                    }
                },
                new TrackDb
                {
                    UserId = "9feb9a5d-2906-42c5-adc1-9a106785f879",
                    Name = "Apt to Taco Mamacita",
                    TrackStart = DateTime.Now.AddMinutes(60),
                    TrackEnd = DateTime.Now.AddMinutes(64),
                    SubTracks = new List<SubTrackDb>
                    {
                        new SubTrackDb {
                            StartTimestamp = DateTime.Now.AddMinutes(60),
                            Artist = "Future Islands",
                            Song = "Seasons",
                            TrackStats = new List<TrackStatDb> {
                                new TrackStatDb{Location = DbGeography.FromText("POINT(-86.795372 36.145263)", 4326), Timestamp = DateTime.Now.AddMinutes(60) },
                                new TrackStatDb{Location = DbGeography.FromText("POINT(-86.795672 36.143669)", 4326), Timestamp = DateTime.Now.AddMinutes(62) },
                            }
                        },
                        new SubTrackDb {
                            StartTimestamp = DateTime.Now.AddMinutes(60),
                            Artist = "In the Valley Below",
                            Song = "Peaches",
                            TrackStats = new List<TrackStatDb> {
                                new TrackStatDb{Location = DbGeography.FromText("POINT(-86.795672 36.143669)", 4326), Timestamp = DateTime.Now.AddMinutes(62) },
                                new TrackStatDb{Location = DbGeography.FromText("POINT(-86.791488 36.143218)", 4326), Timestamp = DateTime.Now.AddMinutes(64) }
                            }
                        }
                    }
                },
                new TrackDb
                {
                    UserId = "9feb9a5d-2906-42c5-adc1-9a106785f879",
                    Name = "Apt to Satco",
                    TrackStart = DateTime.Now.AddMinutes(120),
                    TrackEnd = DateTime.Now.AddMinutes(124),
                    SubTracks = new List<SubTrackDb>
                    {
                        new SubTrackDb {
                            StartTimestamp = DateTime.Now.AddMinutes(120),
                            Artist = "Jungle",
                            Song = "Busy Earnin",
                            TrackStats = new List<TrackStatDb> {
                                new TrackStatDb{Location = DbGeography.FromText("POINT(-86.795372 36.145263)", 4326), Timestamp = DateTime.Now.AddMinutes(120) },
                                new TrackStatDb{Location = DbGeography.FromText("POINT(-86.799513 36.146078)", 4326), Timestamp = DateTime.Now.AddMinutes(122) },
                            }
                        },
                        new SubTrackDb {
                            StartTimestamp = DateTime.Now.AddMinutes(120),
                            Artist = "Kurt Vile",
                            Song = "Walkin on a Pretty Day",
                            TrackStats = new List<TrackStatDb> {
                                new TrackStatDb{Location = DbGeography.FromText("POINT(-86.799513 36.146078)", 4326), Timestamp = DateTime.Now.AddMinutes(122) },
                                new TrackStatDb{Location = DbGeography.FromText("POINT(-86.799449 36.146701)", 4326), Timestamp = DateTime.Now.AddMinutes(124) }
                            }
                        }
                    }
                });

            SaveChanges(context);
        }

        /// <summary>
        /// Wrapper for SaveChanges adding the Validation Messages to the generated exception
        /// </summary>
        /// <param name="context">The context.</param>
        private void SaveChanges(DbContext context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                ); // Add the original exception as the innerException
            }
        }
    }
}
