namespace AgileTemp.WebUi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class done : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.EventProfileProfiles", newName: "ProfileEventProfiles");
            DropPrimaryKey("dbo.ProfileEventProfiles");
            CreateTable(
                "dbo.EventProfileEvents",
                c => new
                    {
                        EventProfile_Id = c.Int(nullable: false),
                        Event_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EventProfile_Id, t.Event_Id })
                .ForeignKey("dbo.EventProfiles", t => t.EventProfile_Id, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.Event_Id, cascadeDelete: true)
                .Index(t => t.EventProfile_Id)
                .Index(t => t.Event_Id);
            
            AddPrimaryKey("dbo.ProfileEventProfiles", new[] { "Profile_Id", "EventProfile_Id" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EventProfileEvents", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.EventProfileEvents", "EventProfile_Id", "dbo.EventProfiles");
            DropIndex("dbo.EventProfileEvents", new[] { "Event_Id" });
            DropIndex("dbo.EventProfileEvents", new[] { "EventProfile_Id" });
            DropPrimaryKey("dbo.ProfileEventProfiles");
            DropTable("dbo.EventProfileEvents");
            AddPrimaryKey("dbo.ProfileEventProfiles", new[] { "EventProfile_Id", "Profile_Id" });
            RenameTable(name: "dbo.ProfileEventProfiles", newName: "EventProfileProfiles");
        }
    }
}
