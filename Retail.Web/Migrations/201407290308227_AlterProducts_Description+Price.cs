namespace Retail.Web.Migrations {
    using System;
    using System.Data.Entity.Migrations;

    public partial class AlterProducts_DescriptionPrice : DbMigration {
        public override void Up() {
            AddColumn("dbo.Products", "Description", c => c.String(maxLength: 1000));
            AddColumn("dbo.Products", "Price", c => c.Decimal(nullable: false, storeType: "money"));
        }

        public override void Down() {
            DropColumn("dbo.Products", "Price");
            DropColumn("dbo.Products", "Description");
        }
    }
}
