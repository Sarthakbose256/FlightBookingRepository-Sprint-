namespace FlightBookingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Agents", "status", c => c.String());
            DropTable("dbo.AuthenticateAgents");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AuthenticateAgents",
                c => new
                    {
                        ApplicantNum = c.Int(nullable: false, identity: true),
                        password = c.String(),
                        ApplicantName = c.String(),
                        ApplicantEmail = c.String(),
                        ApplicantPhone = c.String(maxLength: 10),
                        ApplicantCity = c.String(),
                        ApplicantLocation = c.String(),
                        CommissionRate = c.Double(nullable: false),
                        ApprovalStatus = c.String(),
                    })
                .PrimaryKey(t => t.ApplicantNum);
            
            DropColumn("dbo.Agents", "status");
        }
    }
}
