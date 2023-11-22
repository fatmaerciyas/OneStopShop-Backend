using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<ApplicationUser>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-SUUA4BNC\\MSSQL;initial catalog=OneStopShopDb;integrated security=true; TrustServerCertificate=true");

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityUserLogin<string>>().HasKey(iul => new { iul.LoginProvider, iul.ProviderKey });
            builder.Entity<IdentityUserRole<string>>().HasKey(iur => new { iur.UserId, iur.RoleId });
            builder.Entity<IdentityUserToken<string>>().HasKey(iut => new { iut.UserId, iut.LoginProvider, iut.Name });

            base.OnModelCreating(builder);

            // Config anything we want
            //1
            builder.Entity<ApplicationUser>(e =>
            {
                e.ToTable("Users");
            });
            //2
            builder.Entity<IdentityUserClaim<string>>(e =>
            {
                e.ToTable("UserClaims");
            });
            //3
            builder.Entity<IdentityUserLogin<string>>(e =>
            {
                e.ToTable("UserLogins");
            });
            //4
            builder.Entity<IdentityUserToken<string>>(e =>
            {
                e.ToTable("UserTokens");
            });
            //5
            builder.Entity<IdentityRole>(e =>
            {
                e.ToTable("Roles");
            });
            //6
            builder.Entity<IdentityRoleClaim<string>>(e =>
            {
                e.ToTable("RoleClaims");
            });
            //7
            builder.Entity<IdentityUserRole<string>>(e =>
            {
                e.ToTable("UserRoles");
            });


            //     //PRODUCT-CART
            //     modelBuilder.Entity<ProductCart>()
            //         .HasKey(bc => new { bc.ProductId, bc.CartId });
            //     modelBuilder.Entity<ProductCart>()
            //         .HasOne(bc => bc.Product)
            //         .WithMany(b => b.ProductCarts)
            //         .HasForeignKey(bc => bc.ProductId);
            //     modelBuilder.Entity<ProductCart>()
            //         .HasOne(bc => bc.Cart)
            //         .WithMany(c => c.ProductCarts)
            //         .HasForeignKey(bc => bc.CartId);

            //     //PRODUCT-CATEGORY
            //     modelBuilder.Entity<ProductCategory>()
            //.HasKey(bc => new { bc.ProductId, bc.CategoryId });
            //     modelBuilder.Entity<ProductCategory>()
            //         .HasOne(bc => bc.Product)
            //         .WithMany(b => b.ProductCategories)
            //         .HasForeignKey(bc => bc.ProductId);
            //     modelBuilder.Entity<ProductCategory>()
            //         .HasOne(bc => bc.Category)
            //         .WithMany(c => c.ProductCategories)
            //         .HasForeignKey(bc => bc.CategoryId);

            //     //USER-NOTIFICATION
            //     modelBuilder.Entity<UserNotification>()
            // .HasKey(bc => new { bc.UserId, bc.NotificationId });
            //     modelBuilder.Entity<UserNotification>()
            //         .HasOne(bc => bc.User)
            //         .WithMany(b => b.UserNotifications)
            //         .HasForeignKey(bc => bc.UserId);
            //     modelBuilder.Entity<UserNotification>()
            //         .HasOne(bc => bc.Notification)
            //         .WithMany(c => c.UserNotifications)
            //         .HasForeignKey(bc => bc.NotificationId);
        }

        public DbSet<Cart> Carts { get; set; }
        //Product-Cart Many to Manty Relationship
        //public DbSet<ProductCart> ProductCarts { get; set; }
        //Product-Category Many to Manty Relationship
        //public DbSet<ProductCategory> ProductCategories { get; set; }
        //User-Notification Many to Manty Relationship
        public DbSet<Basket> Baskets { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        
      
    }
}
