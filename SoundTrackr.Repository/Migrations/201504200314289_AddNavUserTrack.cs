namespace SoundTrackr.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNavUserTrack : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.TrackDbs", "UserId");
            AddForeignKey("dbo.TrackDbs", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrackDbs", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.TrackDbs", new[] { "UserId" });
        }
    }
}
