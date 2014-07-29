namespace Retail.Web.Migrations {
    using System;
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration {
        public override void Up() {
            CreateTable(
                "dbo.Categories",
                c => new {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 100),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name);

            CreateTable(
                "dbo.Products",
                c => new {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 100),
                    Vendor_Id = c.Int(nullable: false),
                    Category_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vendors", t => t.Vendor_Id, cascadeDelete: false)
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: false)
                .Index(t => t.Name)
                .Index(t => t.Vendor_Id)
                .Index(t => t.Category_Id);

            CreateTable(
                "dbo.SaleItems",
                c => new {
                    Id = c.Int(nullable: false, identity: true),
                    UnitPrice = c.Decimal(nullable: false, storeType: "money"),
                    ItemPrice = c.Decimal(nullable: false, storeType: "money"),
                    Sale_Id = c.Int(nullable: false),
                    Product_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sales", t => t.Sale_Id, cascadeDelete: false)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: false)
                .Index(t => t.Sale_Id)
                .Index(t => t.Product_Id);

            CreateTable(
                "dbo.Sales",
                c => new {
                    Id = c.Int(nullable: false, identity: true),
                    Date = c.DateTime(nullable: false),
                    SubTotal = c.Decimal(nullable: false, storeType: "money"),
                    Discount = c.Decimal(nullable: false, storeType: "money"),
                    Tax = c.Decimal(nullable: false, storeType: "money"),
                    Total = c.Decimal(nullable: false, storeType: "money"),
                    Employee_Id = c.Int(nullable: false),
                    Customer_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id, cascadeDelete: false)
                .ForeignKey("dbo.Customers", t => t.Customer_Id, cascadeDelete: false)
                .Index(t => t.Employee_Id)
                .Index(t => t.Customer_Id);

            CreateTable(
                "dbo.Customers",
                c => new {
                    Id = c.Int(nullable: false, identity: true),
                    FirstName = c.String(nullable: false, maxLength: 50),
                    LastName = c.String(nullable: false, maxLength: 50),
                    PhoneNumber = c.String(maxLength: 10),
                    AddressStreet = c.String(maxLength: 100),
                    AddressCity = c.String(maxLength: 50),
                    AddressZip = c.String(maxLength: 5),
                    AddressState = c.Int(nullable: false),
                    Email = c.String(maxLength: 100),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.LastName)
                .Index(t => t.PhoneNumber)
                .Index(t => t.AddressZip)
                .Index(t => t.AddressState);

            CreateTable(
                "dbo.Incidents",
                c => new {
                    Id = c.Int(nullable: false, identity: true),
                    Date = c.DateTime(nullable: false),
                    IsOpen = c.Boolean(nullable: false),
                    Description = c.String(maxLength: 1000),
                    Employee_Id = c.Int(nullable: false),
                    Customer_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id, cascadeDelete: false)
                .ForeignKey("dbo.Customers", t => t.Customer_Id, cascadeDelete: false)
                .Index(t => t.Employee_Id)
                .Index(t => t.Customer_Id);

            CreateTable(
                "dbo.Employees",
                c => new {
                    Id = c.Int(nullable: false, identity: true),
                    FirstName = c.String(nullable: false, maxLength: 50),
                    LastName = c.String(nullable: false, maxLength: 50),
                    PhoneNumber = c.String(maxLength: 10),
                    AddressStreet = c.String(maxLength: 100),
                    AddressCity = c.String(maxLength: 50),
                    AddressZip = c.String(maxLength: 5),
                    AddressState = c.Int(nullable: false),
                    Email = c.String(maxLength: 100),
                    Job = c.String(nullable: false, maxLength: 100),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.LastName)
                .Index(t => t.PhoneNumber)
                .Index(t => t.AddressZip)
                .Index(t => t.AddressState);

            CreateTable(
                "dbo.Services",
                c => new {
                    Id = c.Int(nullable: false, identity: true),
                    Date = c.DateTime(nullable: false),
                    IsOpen = c.Boolean(nullable: false),
                    Description = c.String(maxLength: 1000),
                    Employee_Id = c.Int(nullable: false),
                    Customer_Id = c.Int(nullable: false),
                    Product_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id, cascadeDelete: false)
                .ForeignKey("dbo.Customers", t => t.Customer_Id, cascadeDelete: false)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: false)
                .Index(t => t.Employee_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.Product_Id);

            CreateTable(
                "dbo.Vendors",
                c => new {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 100),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name);

        }

        public override void Down() {
            DropForeignKey("dbo.Products", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Products", "Vendor_Id", "dbo.Vendors");
            DropForeignKey("dbo.Services", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.SaleItems", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.SaleItems", "Sale_Id", "dbo.Sales");
            DropForeignKey("dbo.Services", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Sales", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Incidents", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Services", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.Sales", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.Incidents", "Employee_Id", "dbo.Employees");
            DropIndex("dbo.Vendors", new[] { "Name" });
            DropIndex("dbo.Services", new[] { "Product_Id" });
            DropIndex("dbo.Services", new[] { "Customer_Id" });
            DropIndex("dbo.Services", new[] { "Employee_Id" });
            DropIndex("dbo.Employees", new[] { "AddressState" });
            DropIndex("dbo.Employees", new[] { "AddressZip" });
            DropIndex("dbo.Employees", new[] { "PhoneNumber" });
            DropIndex("dbo.Employees", new[] { "LastName" });
            DropIndex("dbo.Incidents", new[] { "Customer_Id" });
            DropIndex("dbo.Incidents", new[] { "Employee_Id" });
            DropIndex("dbo.Customers", new[] { "AddressState" });
            DropIndex("dbo.Customers", new[] { "AddressZip" });
            DropIndex("dbo.Customers", new[] { "PhoneNumber" });
            DropIndex("dbo.Customers", new[] { "LastName" });
            DropIndex("dbo.Sales", new[] { "Customer_Id" });
            DropIndex("dbo.Sales", new[] { "Employee_Id" });
            DropIndex("dbo.SaleItems", new[] { "Product_Id" });
            DropIndex("dbo.SaleItems", new[] { "Sale_Id" });
            DropIndex("dbo.Products", new[] { "Category_Id" });
            DropIndex("dbo.Products", new[] { "Vendor_Id" });
            DropIndex("dbo.Products", new[] { "Name" });
            DropIndex("dbo.Categories", new[] { "Name" });
            DropTable("dbo.Vendors");
            DropTable("dbo.Services");
            DropTable("dbo.Employees");
            DropTable("dbo.Incidents");
            DropTable("dbo.Customers");
            DropTable("dbo.Sales");
            DropTable("dbo.SaleItems");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
