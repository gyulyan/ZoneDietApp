using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using ZoneDietApp.Data.Models;

namespace ZoneDietApp.Data
{
    public class ZoneDbContext : IdentityDbContext
    {
        public ZoneDbContext(DbContextOptions<ZoneDbContext> options)
           : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //this is the way we define the PRIMARY KEY into the Data.Models.EventParticipants
            //modelBuilder.Entity<Product>()
            //    .HasKey(p => new
            //    {
            //        p.TypeId,
            //        p.ZoneChoiceColorId
            //    });

            modelBuilder
                .Entity<ProductTypeOption>()
                .HasData(new ProductTypeOption()
                {
                    Id = 1,
                    Name = "Въглехидрат"
                },
                new ProductTypeOption()
                {
                    Id = 2,
                    Name = "Мазнини"
                },
                new ProductTypeOption()
                {
                    Id = 3,
                    Name = "Протеин"
                },
                new ProductTypeOption()
                {
                    Id = 4,
                    Name = "Смесени продукти"
                });

            modelBuilder
    .Entity<ZoneChoiceColor>()
    .HasData(new ZoneChoiceColor()
    {
        Id = 1,
        Name = "Зелен"
    },
    new ZoneChoiceColor()
    {
        Id = 2,
        Name = "Оранжев"
    },
    new ZoneChoiceColor()
    {
        Id = 3,
        Name = "Червен"
    });

            modelBuilder
                .Entity<Product>()
                .HasData(new Product()
                {
                    Id = 1,
                    Name = "Заешко месо",
                    TypeId = 3,
                    ZoneChoiceColorId = 1,
                    Weight = "0.028"
                },
                new Product()
                {
                    Id = 2,
                    Name = "Алабаш",
                    TypeId = 1,
                    ZoneChoiceColorId = 1,
                    Weight = "0.300"
                },
                new Product()
                {
                    Id = 3,
                    Name = "Авокадо",
                    TypeId = 2,
                    ZoneChoiceColorId = 1,
                    Weight = "0.010"
                },
                new Product()
                {
                    Id = 4,
                    Name = "Кисело мляко",
                    TypeId = 4,
                    ZoneChoiceColorId = 1,
                    Weight = "0.220"
                }); ;

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ProductTypeOption> ProductTypeOptions { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<ZoneChoiceColor> ZoneChoiceColors { get; set; }

    }
}
