namespace Retail.Web.Migrations {
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Retail.Web.Models;
    using System.IO;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<Retail.Web.Models.RetailDbContext> {
        public Configuration() {
            AutomaticMigrationsEnabled = false;
        }

        static string[][] ParseFakeData(string fileName) {
            var reader = new StreamReader(File.OpenRead(fileName));
            List<string[]> list = new List<string[]>();
            while (!reader.EndOfStream) {
                var line = reader.ReadLine();
                var values = line.Split(',');
                list.Add(values);
            }
            return list.ToArray();
        }

        static List<Customer> ParseCustomersData() {

            string[][] customerDatas = ParseFakeData(@"C:/VBDB/MOCK_DATA.csv");

            List<Customer> customers = new List<Customer>();
            int id = 10;
            foreach (string[] customerData in customerDatas) {
                System.Diagnostics.Debug.Print(customerData.ToString());
                Customer customer = new Customer {
                    Id = id++,
                    FirstName = customerData[0],
                    LastName = customerData[1],
                    Email = customerData[2],
                    PhoneNumber = customerData[3],
                    AddressStreet = customerData[4],
                    AddressCity = customerData[5],
                    AddressState = EnumEx.GetValueFromName<State>(customerData[6]),
                    AddressZip = customerData[7]
                };
                customers.Add(customer);
            }

            return customers;
        }

        protected override void Seed(Retail.Web.Models.RetailDbContext context) {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Companies.AddOrUpdate(c => c.Id,
                new Company {
                    Id = 1,
                    Name = "Demo Company",
                    TaxRate = 5.5M
                }
            );

            context.Vendors.AddOrUpdate(v => v.Id,
                new Vendor {
                    Id = 1,
                    Name = "Vendor 1"
                }
            );

            context.Customers.AddOrUpdate(c => c.Id,
                new Customer {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    PhoneNumber = "6085551234",
                    Email = "jdoe@gmail.com",
                    AddressStreet = "123 Nowhere Lane",
                    AddressCity = "Nowhere",
                    AddressState = State.WI,
                    AddressZip = "12345"
                }
            );

            //if (System.Diagnostics.Debugger.IsAttached == false)
            //    System.Diagnostics.Debugger.Launch();

            //System.Diagnostics.Debugger.Break();

            //var _customers = ParseCustomersData().ToArray();

            //context.Customers.AddOrUpdate(c => new { c.FirstName, c.LastName, c.PhoneNumber }, _customers);

            context.Employees.AddOrUpdate(e => e.Id,
                new Employee {
                    Id = 1,
                    FirstName = "Joe",
                    LastName = "Schmoe",
                    PhoneNumber = "6085554321",
                    Email = "jscmoe@democompany.com",
                    AddressStreet = "123 Main Street",
                    AddressCity = "Nowhere",
                    AddressState = State.WI,
                    AddressZip = "12345",
                    Job = "Cashier"
                }
            );

            context.Categories.AddOrUpdate(c => c.Id,
                new Category {
                    Id = 1,
                    Name = "Category 1"
                }
            );

            context.SaveChanges();

            var customers = context.Customers.Where(customer => customer.Id == 1);
            var employees = context.Employees.Where(employee => employee.Id == 1);
            var vendors = context.Vendors.Where(vendor => vendor.Id == 1);
            var categories = context.Categories.Where(category => category.Id == 1);

            context.Products.AddOrUpdate(v => v.Id,
                new Product {
                    Id = 1,
                    Name = "Product 1",
                    Price = 1.00M,
                    Vendor = vendors.First(),
                    Category = categories.First()
                }
            );

            context.Sales.AddOrUpdate(s => s.Id,
                new Sale {
                    Id = 1,
                    Date = DateTime.Now,
                    SubTotal = 0.00M,
                    Discount = 0.00M,
                    Tax = 0.00M,
                    Total = 0.00M,
                    Customer = customers.First(),
                    Employee = employees.First()
                }
            );

            context.SaveChanges();

            var sales = context.Sales.Where(sale => sale.Id == 1);
            var products = context.Products.Where(product => product.Id == 1);

            context.SaleItems.AddOrUpdate(si => si.Id,
                new SaleItem {
                    Id = 1,
                    UnitPrice = 1.00M,
                    ItemPrice = 1.00M,
                    Quantity = 1,
                    Sale = sales.First(),
                    Product = products.First()
                }
            );

        }
    }
}
