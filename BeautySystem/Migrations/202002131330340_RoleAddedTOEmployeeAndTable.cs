namespace BeautySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoleAddedTOEmployeeAndTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Employees", "EmpRoleId", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "EmployeeRole_Id", c => c.Int());
            CreateIndex("dbo.Employees", "EmployeeRole_Id");
            AddForeignKey("dbo.Employees", "EmployeeRole_Id", "dbo.EmployeeRoles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "EmployeeRole_Id", "dbo.EmployeeRoles");
            DropIndex("dbo.Employees", new[] { "EmployeeRole_Id" });
            DropColumn("dbo.Employees", "EmployeeRole_Id");
            DropColumn("dbo.Employees", "EmpRoleId");
            DropTable("dbo.EmployeeRoles");
        }
    }
}
