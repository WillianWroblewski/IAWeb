namespace IAWeb.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v_100 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name_FirstName = c.String(nullable: false, maxLength: 60),
                        Name_LastName = c.String(nullable: false, maxLength: 60),
                        Document_Number = c.String(nullable: false, maxLength: 11, fixedLength: true),
                        Email_Address = c.String(nullable: false, maxLength: 160),
                        User_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Username = c.String(),
                        Password = c.String(),
                        AccessLevel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customer", "User_Id", "dbo.Users");
            DropIndex("dbo.Customer", new[] { "User_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Customer");
        }
    }
}
