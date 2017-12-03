namespace IAWeb.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v_104 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Conversation",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Question = c.String(nullable: false, maxLength: 250),
                        Answer = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Conversation");
        }
    }
}
