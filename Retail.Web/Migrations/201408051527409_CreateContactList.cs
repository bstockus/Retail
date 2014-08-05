namespace Retail.Web.Migrations {
    using System;
    using System.Data.Entity.Migrations;

    public partial class CreateContactList : DbMigration {
        public override void Up() {
            CreateTable(
                "dbo.ContactLists",
                c => new {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 100),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name);

            CreateTable(
                "dbo.ContactListCustomers",
                c => new {
                    ContactList_Id = c.Int(nullable: false),
                    Customer_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.ContactList_Id, t.Customer_Id })
                .ForeignKey("dbo.ContactLists", t => t.ContactList_Id, cascadeDelete: false)
                .ForeignKey("dbo.Customers", t => t.Customer_Id, cascadeDelete: false)
                .Index(t => t.ContactList_Id)
                .Index(t => t.Customer_Id);

        }

        public override void Down() {
            DropForeignKey("dbo.ContactListCustomers", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.ContactListCustomers", "ContactList_Id", "dbo.ContactLists");
            DropIndex("dbo.ContactListCustomers", new[] { "Customer_Id" });
            DropIndex("dbo.ContactListCustomers", new[] { "ContactList_Id" });
            DropIndex("dbo.ContactLists", new[] { "Name" });
            DropTable("dbo.ContactListCustomers");
            DropTable("dbo.ContactLists");
        }
    }
}
