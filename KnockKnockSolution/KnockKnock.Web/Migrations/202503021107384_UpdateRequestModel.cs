namespace KnockKnock.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRequestModel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Requests", newName: "Request");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Request", newName: "Requests");
        }
    }
}
