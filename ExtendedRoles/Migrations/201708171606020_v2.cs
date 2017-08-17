namespace ExtendedRoles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetRoles", "Order", c => c.Int());
            AddColumn("dbo.AspNetRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));

            Sql("UPDATE dbo.AspNetRoles SET [Order] = 1 WHERE Name = 'SuperAdmin'");
            Sql("UPDATE dbo.AspNetRoles SET [Order] = 2 WHERE Name = 'Manager'");
            Sql("UPDATE dbo.AspNetRoles SET [Order] = 3 WHERE Name = 'Admin'");
            Sql("UPDATE dbo.AspNetRoles SET [Order] = 4 WHERE Name = 'Driver'");
        }

        public override void Down()
        {
            DropColumn("dbo.AspNetRoles", "Discriminator");
            DropColumn("dbo.AspNetRoles", "Order");
        }
    }
}