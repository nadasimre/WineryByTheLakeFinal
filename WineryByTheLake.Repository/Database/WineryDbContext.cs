// <copyright file="WineryDbContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WineryByTheLake.Repository
{
    using Microsoft.EntityFrameworkCore;
    using WineryByTheLake.Models;

    /// <summary>
    /// Database context class.
    /// </summary>
    public class WineryDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WineryDbContext"/> class.
        /// </summary>
        public WineryDbContext() => this.Database.EnsureCreated();

        /// <summary>
        /// Gets or sets the wine table.
        /// </summary>
        public DbSet<Wine> Wines { get; set; }

        /// <summary>
        /// Gets or sets the supplier table.
        /// </summary>
        public DbSet<Supplier> Suppliers { get; set; }

        /// <summary>
        /// Gets or sets the region table.
        /// </summary>
        public DbSet<Region> Regions { get; set; }

        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder != null && !optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseInMemoryDatabase("wine");
            }
        }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Wine>(entity =>
            {
                entity.HasOne(wine => wine.Supplier)
                        .WithMany(supplier => supplier.Wines)
                        .HasForeignKey(wine => wine.SupplierID)
                        .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasOne(supplier => supplier.Region)
                        .WithMany(region => region.Suppliers)
                        .HasForeignKey(supplier => supplier.RegionID)
                        .OnDelete(DeleteBehavior.ClientSetNull);
            });

            Region badacsony = new Region()
            {
                Id = 1,
                Name = "Badacsonyi borvidék",
            };

            Region eger = new Region()
            {
                Id = 2,
                Name = "Egri borvidék",
            };

            Region tokaj = new Region()
            {
                Id = 3,
                Name = "Tokaji borvidék",
            };

            Supplier szabo = new Supplier()
            {
                Id = 1,
                Name = "Szabó pincészet",
                RegionID = badacsony.Id,
            };

            Supplier skizo = new Supplier()
            {
                Id = 2,
                Name = "Skizo pincészet",
                RegionID = badacsony.Id,
            };

            Supplier molnar = new Supplier()
            {
                Id = 3,
                Name = "Molnár pincészet",
                RegionID = eger.Id,
            };

            Supplier sandor = new Supplier()
            {
                Id = 4,
                Name = "Sándor borászat",
                RegionID = eger.Id,
            };

            Supplier erzsebet = new Supplier()
            {
                Id = 5,
                Name = "Erzsébet pince",
                RegionID = tokaj.Id,
            };

            Supplier erdos = new Supplier()
            {
                Id = 6,
                Name = "Erdős pincészet",
                RegionID = tokaj.Id,
            };

            Wine cabernet = new Wine()
            {
                Id = 1,
                Name = "Cabernet Sauvignon",
                Color = ColorE.Red,
                Sweetness = "száraz",
                Price = 1500,
                SupplierID = szabo.Id,
            };

            Wine szurke = new Wine()
            {
                Id = 2,
                Name = "Szürkebarát",
                Color = ColorE.White,
                Sweetness = "édes",
                Price = 1400,
                SupplierID = szabo.Id,
            };

            Wine irsai = new Wine()
            {
                Id = 3,
                Name = "Irsai Olivér",
                Color = ColorE.White,
                Sweetness = "száraz",
                Price = 1600,
                SupplierID = skizo.Id,
            };

            Wine blanc = new Wine()
            {
                Id = 4,
                Name = "Sauvignon blanc",
                Color = ColorE.White,
                Sweetness = "száraz",
                Price = 1800,
                SupplierID = skizo.Id,
            };

            Wine bika = new Wine()
            {
                Id = 5,
                Name = "Egri Bikavér",
                Color = ColorE.Red,
                Sweetness = "száraz",
                Price = 1700,
                SupplierID = molnar.Id,
            };

            Wine csillag = new Wine()
            {
                Id = 6,
                Name = "Egri Csillag",
                Color = ColorE.White,
                Sweetness = "száraz",
                Price = 1200,
                SupplierID = molnar.Id,
            };

            Wine roze = new Wine()
            {
                Id = 7,
                Name = "Egri Rozé",
                Color = ColorE.Rose,
                Sweetness = "száraz",
                Price = 1000,
                SupplierID = sandor.Id,
            };

            Wine muskotaly = new Wine()
            {
                Id = 8,
                Name = "Egri Muskotály",
                Color = ColorE.White,
                Sweetness = "félédes",
                Price = 900,
                SupplierID = sandor.Id,
            };

            Wine aszu = new Wine()
            {
                Id = 9,
                Name = "Tokaji Aszú",
                Color = ColorE.White,
                Sweetness = "édes",
                Price = 50000,
                SupplierID = erzsebet.Id,
            };

            Wine furmint = new Wine()
            {
                Id = 10,
                Name = "Tokaji Furmint",
                Color = ColorE.White,
                Sweetness = "száraz",
                Price = 2300,
                SupplierID = erzsebet.Id,
            };

            Wine esszencia = new Wine()
            {
                Id = 11,
                Name = "Tokaji Esszencia",
                Color = ColorE.White,
                Sweetness = "édes",
                Price = 240000,
                SupplierID = erdos.Id,
            };

            Wine kabar = new Wine()
            {
                Id = 12,
                Name = "Tokaji Kabar",
                Color = ColorE.White,
                Sweetness = "száraz",
                Price = 18000,
                SupplierID = erdos.Id,
            };

            modelBuilder.Entity<Region>().HasData(badacsony, eger, tokaj);
            modelBuilder.Entity<Supplier>().HasData(szabo, skizo, molnar, sandor, erzsebet, erdos);
            modelBuilder.Entity<Wine>().HasData(cabernet, szurke, irsai, blanc, bika, csillag, roze, muskotaly, aszu, furmint, esszencia, kabar);
        }
    }
}
