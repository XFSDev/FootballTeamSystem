namespace FootballTeamSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePlayerDataModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Players", "FullName", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Players", "FullName", c => c.String(nullable: false));
        }
    }
}
