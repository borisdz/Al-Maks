namespace Al_Maks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        ArticleId = c.Int(nullable: false, identity: true),
                        ArticleName = c.String(nullable: false),
                        ArticlePrice = c.Double(nullable: false),
                        ArticleImgUrl = c.String(nullable: false),
                        StoreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ArticleId)
                .ForeignKey("dbo.Stores", t => t.StoreId, cascadeDelete: true)
                .Index(t => t.StoreId);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        StoreId = c.Int(nullable: false, identity: true),
                        StoreName = c.String(nullable: false),
                        StoreAddress = c.String(nullable: false),
                        City_CityId = c.Int(),
                    })
                .PrimaryKey(t => t.StoreId)
                .ForeignKey("dbo.Cities", t => t.City_CityId)
                .Index(t => t.City_CityId);
            
            CreateTable(
                "dbo.Distributors",
                c => new
                    {
                        DistributorId = c.Int(nullable: false, identity: true),
                        DistributorName = c.String(nullable: false),
                        DistributorDescription = c.String(nullable: false),
                        TelephoneNo = c.String(nullable: false),
                        Address = c.String(),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DistributorId)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CityId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(nullable: false),
                        CustomerEmail = c.String(nullable: false),
                        CustomerPhone = c.String(nullable: false),
                        CustomerAddress = c.String(nullable: false),
                        CityId = c.Int(nullable: false),
                        CustomerDOB = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceId = c.Int(nullable: false, identity: true),
                        InvoiceDate = c.DateTime(nullable: false),
                        OrderId = c.Int(nullable: false),
                        DistributorId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Distributors", t => t.DistributorId, cascadeDelete: false)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.DistributorId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        PaymentType = c.Int(nullable: false),
                        StoreId = c.Int(nullable: false),
                        Delivery_DeliveryId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: false)
                .ForeignKey("dbo.Stores", t => t.StoreId, cascadeDelete: true)
                .ForeignKey("dbo.Deliveries", t => t.Delivery_DeliveryId)
                .Index(t => t.CustomerId)
                .Index(t => t.StoreId)
                .Index(t => t.Delivery_DeliveryId);
            
            CreateTable(
                "dbo.Deliveries",
                c => new
                    {
                        DeliveryId = c.Int(nullable: false, identity: true),
                        DeliveryDate = c.DateTime(nullable: false),
                        DistributorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DeliveryId)
                .ForeignKey("dbo.Distributors", t => t.DistributorId, cascadeDelete: true)
                .Index(t => t.DistributorId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.DeliveryCities",
                c => new
                    {
                        Delivery_DeliveryId = c.Int(nullable: false),
                        City_CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Delivery_DeliveryId, t.City_CityId })
                .ForeignKey("dbo.Deliveries", t => t.Delivery_DeliveryId, cascadeDelete: true)
                .ForeignKey("dbo.Cities", t => t.City_CityId, cascadeDelete: false)
                .Index(t => t.Delivery_DeliveryId)
                .Index(t => t.City_CityId);
            
            CreateTable(
                "dbo.DistributorStores",
                c => new
                    {
                        Distributor_DistributorId = c.Int(nullable: false),
                        Store_StoreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Distributor_DistributorId, t.Store_StoreId })
                .ForeignKey("dbo.Distributors", t => t.Distributor_DistributorId, cascadeDelete: true)
                .ForeignKey("dbo.Stores", t => t.Store_StoreId, cascadeDelete: true)
                .Index(t => t.Distributor_DistributorId)
                .Index(t => t.Store_StoreId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Articles", "StoreId", "dbo.Stores");
            DropForeignKey("dbo.DistributorStores", "Store_StoreId", "dbo.Stores");
            DropForeignKey("dbo.DistributorStores", "Distributor_DistributorId", "dbo.Distributors");
            DropForeignKey("dbo.Distributors", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Stores", "City_CityId", "dbo.Cities");
            DropForeignKey("dbo.Orders", "Delivery_DeliveryId", "dbo.Deliveries");
            DropForeignKey("dbo.Deliveries", "DistributorId", "dbo.Distributors");
            DropForeignKey("dbo.DeliveryCities", "City_CityId", "dbo.Cities");
            DropForeignKey("dbo.DeliveryCities", "Delivery_DeliveryId", "dbo.Deliveries");
            DropForeignKey("dbo.Invoices", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "StoreId", "dbo.Stores");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Invoices", "DistributorId", "dbo.Distributors");
            DropForeignKey("dbo.Invoices", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "CityId", "dbo.Cities");
            DropIndex("dbo.DistributorStores", new[] { "Store_StoreId" });
            DropIndex("dbo.DistributorStores", new[] { "Distributor_DistributorId" });
            DropIndex("dbo.DeliveryCities", new[] { "City_CityId" });
            DropIndex("dbo.DeliveryCities", new[] { "Delivery_DeliveryId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Deliveries", new[] { "DistributorId" });
            DropIndex("dbo.Orders", new[] { "Delivery_DeliveryId" });
            DropIndex("dbo.Orders", new[] { "StoreId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.Invoices", new[] { "CustomerId" });
            DropIndex("dbo.Invoices", new[] { "DistributorId" });
            DropIndex("dbo.Invoices", new[] { "OrderId" });
            DropIndex("dbo.Customers", new[] { "CityId" });
            DropIndex("dbo.Distributors", new[] { "CityId" });
            DropIndex("dbo.Stores", new[] { "City_CityId" });
            DropIndex("dbo.Articles", new[] { "StoreId" });
            DropTable("dbo.DistributorStores");
            DropTable("dbo.DeliveryCities");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Deliveries");
            DropTable("dbo.Orders");
            DropTable("dbo.Invoices");
            DropTable("dbo.Customers");
            DropTable("dbo.Cities");
            DropTable("dbo.Distributors");
            DropTable("dbo.Stores");
            DropTable("dbo.Articles");
        }
    }
}
