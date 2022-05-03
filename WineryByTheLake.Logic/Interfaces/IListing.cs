// <copyright file="IListing.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WineryByTheLake.Logic
{
    using System.Collections.Generic;
    using WineryByTheLake.Models;

    /// <summary>
    /// Specifies the listing methods.
    /// </summary>
    public interface IListing
    {
        /// <summary>
        /// Gets a wine by its id.
        /// </summary>
        /// <param name="id">ID of the wanted wine.</param>
        /// <returns>Returns a wine entity.</returns>
        Wine GetWine(int id);

        /// <summary>
        /// Gets all the wines.
        /// </summary>
        /// <returns>Returns a list of all the wines.</returns>
        IList<Wine> GetAllWines();

        /// <summary>
        /// Gets the wines of a specified supplier.
        /// </summary>
        /// <param name="supplierid">ID of the supplier whose wines we want to get.</param>
        /// <returns>Returns a list of all the wines.</returns>
        IList<Wine> GetWines(int supplierid);

        /// <summary>
        /// Gets a supplier by its id.
        /// </summary>
        /// <param name="id">ID of the wanted supplier.</param>
        /// <returns>Returns a supplier entity.</returns>
        Supplier GetSupplier(int id);

        /// <summary>
        /// Gets all the suppliers.
        /// </summary>
        /// <returns>Returns a list of all the suppliers.</returns>
        IList<Supplier> GetAllSuppliers();

        /// <summary>
        /// Gets the suppliers of a region.
        /// </summary>
        /// <param name="regionid">ID of the region where the suppliers live we want to get.</param>
        /// <returns>Returns a list of the suppliers of the region.</returns>
        IList<Supplier> GetSuppliers(int regionid);

        /// <summary>
        /// Gets a region by its id.
        /// </summary>
        /// <param name="id">ID of the wanted region.</param>
        /// <returns>Returns a region entity.</returns>
        Region GetRegion(int id);

        /// <summary>
        /// Gets all the regions.
        /// </summary>
        /// <returns>Returns a list of all the regions.</returns>
        IList<Region> GetAllRegions();

        /// <summary>
        /// Calculates the sum of the wines of the suppliers.
        /// </summary>
        /// /// <param name="supplier">The supplier object whose wine prices we want to sum.</param>
        void WinePriceSum(Supplier supplier);
    }
}
