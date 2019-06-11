namespace MyCurrencyPocketbook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PocketAccountNumberChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PocketAccounts", "PocketAccountNumber", c => c.String(nullable: false, maxLength: 8000, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PocketAccounts", "PocketAccountNumber", c => c.String(nullable: false));
        }
    }
}
