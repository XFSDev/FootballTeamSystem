namespace FootballTeamSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPlayerModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FullName = c.String(nullable: false),
                        Birthdate = c.DateTime(nullable: false),
                        ShirtNumber = c.Byte(nullable: false),
                        Position = c.Int(nullable: false),
                        PlayerImagePath = c.String(nullable: false),
                        IsCaptain = c.Boolean(nullable: false),
                        IsViceCaptain = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Players", new[] { "IsDeleted" });
            DropTable("dbo.Players");
        }
    }
}
