namespace FootballTeamSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePlayerModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Players", "PlayerImagePath", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Players", "PlayerImagePath", c => c.String(nullable: false));
        }
    }
}
