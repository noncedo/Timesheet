namespace BeautySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeyToProjectIdToEMP : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "IdNumber", c => c.String(maxLength: 13));
            AddColumn("dbo.Projects", "ClientId", c => c.Int(nullable: false));
            CreateIndex("dbo.Projects", "ClientId");
            AddForeignKey("dbo.Projects", "ClientId", "dbo.Clients", "ClientId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "ClientId", "dbo.Clients");
            DropIndex("dbo.Projects", new[] { "ClientId" });
            DropColumn("dbo.Projects", "ClientId");
            DropColumn("dbo.Employees", "IdNumber");
        }
    }
}
