namespace Navtech.OMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBuyerEmailAddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buyers", "EmailAddress", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Buyers", "EmailAddress");
        }
    }
}
