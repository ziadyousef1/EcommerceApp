using EcommerceApp.Domain.Entities;
using EcommerceApp.Domain.Entities.Cart;
using EcommerceApp.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<AppUser>(options)
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "User", NormalizedName = "USER" }
            );
            builder.Entity<PaymentMethod>().HasData(
                new PaymentMethod { Id = Guid.NewGuid(), Name = "Cash" },
                new PaymentMethod { Id = Guid.NewGuid(), Name = "Credit Card" },
                new PaymentMethod { Id = Guid.NewGuid(), Name = "PayPal" }
            );
        }
    }
}

