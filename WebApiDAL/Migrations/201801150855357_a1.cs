namespace WebApiDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceId = c.Int(nullable: false, identity: true),
                        InvoiceDate = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoices", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Invoices", new[] { "EmployeeId" });
            DropTable("dbo.Invoices");
        }
    }
}
