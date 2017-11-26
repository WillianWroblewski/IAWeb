namespace IAWeb.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v_103 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Users", newName: "User");
            AlterColumn("dbo.User", "Username", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.User", "Password", c => c.String(nullable: false, maxLength: 32, fixedLength: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "Password", c => c.String());
            AlterColumn("dbo.User", "Username", c => c.String());
            RenameTable(name: "dbo.User", newName: "Users");
        }
    }
}
