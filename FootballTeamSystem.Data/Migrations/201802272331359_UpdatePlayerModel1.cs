namespace FootballTeamSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePlayerModel1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Players", "Nickname", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Players", "Nickname");
        }
    }
}
