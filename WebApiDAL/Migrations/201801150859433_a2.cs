namespace WebApiDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Invoices", "Amount", c => c.Decimal(nullable: false, precision: 9, scale: 3));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Invoices", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
