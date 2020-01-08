namespace BeautySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Employee_Projects : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        AppointmentId = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        SlotId = c.Int(nullable: false),
                        ServiceId = c.Int(nullable: false),
                        AppointmentDate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        UserCharID = c.String(),
                        EmployeeId = c.Int(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AppointmentId);
            
            CreateTable(
                "dbo.EmployeeProjects",
                c => new
                    {
                        EmployeeProjectId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        HoursWorked = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeProjectId)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.ProjectId)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(),
                        ProjectDesc = c.String(),
                    })
                .PrimaryKey(t => t.ProjectId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        text = c.String(),
                        start_date = c.DateTime(nullable: false),
                        end_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeProjects", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.EmployeeProjects", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.EmployeeProjects", "ClientId", "dbo.Clients");
            DropIndex("dbo.EmployeeProjects", new[] { "ClientId" });
            DropIndex("dbo.EmployeeProjects", new[] { "ProjectId" });
            DropIndex("dbo.EmployeeProjects", new[] { "EmployeeId" });
            DropTable("dbo.Events");
            DropTable("dbo.Projects");
            DropTable("dbo.EmployeeProjects");
            DropTable("dbo.Appointments");
        }
    }
}
