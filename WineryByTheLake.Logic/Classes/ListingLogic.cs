// <copyright file="ListingLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WineryByTheLake.Logic
{
    using System.Collections.Generic;
    using System.Linq;
    using WineryByTheLake.Models;
    using WineryByTheLake.Repository;

    /// <summary>
    /// Implements the methods which the interface requires.
    /// </summary>
    public class ListingLogic : IListing
    {
        private IWineRepository wine;
        private ISupplierRepository supplier;
        private IRegionRepository region;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListingLogic"/> class.
        /// </summary>
        /// <param name="wine">Reference of wine repository.</param>
        /// <param name="supplier">Reference of supplier repository.</param>
        /// <param name="region">Reference of region repository.</param>
        public ListingLogic(IWineRepository wine, ISupplierRepository supplier, IRegionRepository region)
        {
            this.wine = wine;
            this.supplier = supplier;
            this.region = region;
        }

        /// <summary>
        /// Gets all the regions.
        /// </summary>
        /// <returns>Returns a list of all the regions.</returns>
        public IList<Region> GetAllRegions()
        {
            return this.region.GetAll().ToList();
        }

        /// <summary>
        /// Gets all the suppliers.
        /// </summary>
        /// <returns>Returns a list of all the suppliers.</returns>
        public IList<Supplier> GetAllSuppliers()
        {
            return this.supplier.GetAll().ToList();
        }

        /// <summary>
        /// Gets all the wines.
        /// </summary>
        /// <returns>Returns a list of all the wines.</returns>
        public IList<Wine> GetAllWines()
        {
            return this.wine.GetAll().ToList();
        }

        /// <summary>
        /// Gets a region by its id.
        /// </summary>
        /// <param name="id">ID of the wanted region.</param>
        /// <returns>Returns a region entity.</returns>
        public Region GetRegion(int id)
        {
            return this.region.GetAll().SingleOrDefault(region => region.Id == id);
        }

        /// <summary>
        /// Gets a supplier by its id.
        /// </summary>
        /// <param name="id">ID of the wanted supplier.</param>
        /// <returns>Returns a supplier entity.</returns>
        public Supplier GetSupplier(int id)
        {
            return this.supplier.GetAll().SingleOrDefault(supplier => supplier.Id == id);
        }

        /// <summary>
        /// Gets the suppliers of a region.
        /// </summary>
        /// <param name="regionid">ID of the region where the suppliers live we want to get.</param>
        /// <returns>Returns a list of the suppliers of the region.</returns>
        public IList<Supplier> GetSuppliers(int regionid)
        {
            return this.region.GetSuppliers(regionid).ToList();
        }

        /// <summary>
        /// Gets a wine by its id.
        /// </summary>
        /// <param name="id">ID of the wanted wine.</param>
        /// <returns>Returns a wine entity.</returns>
        public Wine GetWine(int id)
        {
            return this.wine.GetAll().SingleOrDefault(wine => wine.Id == id);
        }

        /// <summary>
        /// Gets the wines of a specified supplier.
        /// </summary>
        /// <param name="supplierid">ID of the supplier whose wines we want to get.</param>
        /// <returns>Returns a list of all the wines.</returns>
        public IList<Wine> GetWines(int supplierid)
        {
            return this.supplier.GetWines(supplierid).ToList();
        }

        /// <summary>
        /// Calculates the sum of the wines of the suppliers.
        /// </summary>
        /// /// <param name="supplier">The supplier object whose wine prices we want to sum.</param>
        public void WinePriceSum(Supplier supplier)
        {
            this.supplier.CalculateWinePrice(supplier);
        }
    }
}
