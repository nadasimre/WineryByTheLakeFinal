// <copyright file="Factory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WineryByTheLake.Program
{
    using WineryByTheLake.Logic;
    using WineryByTheLake.Models;
    using WineryByTheLake.Repository;

    /// <summary>
    /// Entities which are needed for the program to run, are here.
    /// </summary>
    public class Factory
    {
        private readonly WineRepository wine;

        private readonly SupplierRepository supplier;

        private readonly RegionRepository region;

        /// <summary>
        /// Initializes a new instance of the <see cref="Factory"/> class.
        /// </summary>
        public Factory()
        {
            this.Ctx = new WineryDbContext();
            this.wine = new WineRepository(this.Ctx);
            this.supplier = new SupplierRepository(this.Ctx);
            this.region = new RegionRepository(this.Ctx);
            this.Listing = new ListingLogic(this.wine, this.supplier, this.region);
            this.Modify = new ModifyLogic(this.wine, this.supplier, this.region);
            this.Product = new ProductLogic(this.wine, this.supplier, this.region);
        }

        /// <summary>
        /// Gets the database entity, it is required for the repository classes.
        /// </summary>
        public WineryDbContext Ctx { get; }

        /// <summary>
        /// Gets the ListingLogic entity.
        /// </summary>
        public ListingLogic Listing { get; }

        /// <summary>
        /// Gets the ModifyLogic entity.
        /// </summary>
        public ModifyLogic Modify { get; }

        /// <summary>
        /// Gets the ProductLogic entity.
        /// </summary>
        public ProductLogic Product { get; }
    }
}
