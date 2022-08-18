namespace _4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sample : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        AuthorName = c.String(),
                        Country = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.AuthorId);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        BookTitle = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Language = c.String(),
                        AuthorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        PersonName = c.String(),
                        Password = c.String(),
                        EmailId = c.String(),
                        PersonCity = c.String(),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropIndex("dbo.People", new[] { "RoleId" });
            DropIndex("dbo.Books", new[] { "AuthorId" });
            DropTable("dbo.Roles");
            DropTable("dbo.People");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
