namespace Retail.Web.Migrations {
    using System;
    using System.Data.Entity.Migrations;

    public partial class CreateCompany : DbMigration {
        public override void Up() {
            CreateTable(
                "dbo.Companies",
                c => new {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 100),
                    TaxRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name);

        }

        public override void Down() {
            DropIndex("dbo.Companies", new[] { "Name" });
            DropTable("dbo.Companies");
        }
    }
}
