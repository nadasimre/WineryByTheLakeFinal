// <copyright file="IModify.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WineryByTheLake.Logic
{
    using System.Collections.Generic;
    using WineryByTheLake.Models;

    /// <summary>
    /// Specifies the modification methods.
    /// </summary>
    public interface IModify
    {
        /// <summary>
        /// We can insert a wine with this method.
        /// </summary>
        /// <param name="wine">The wine, which will be insterted.</param>
        void InsertWine(Wine wine);

        /// <summary>
        /// We can remove a wine with this method.
        /// </summary>
        /// <param name="wine">The wine, which will be removed.</param>
        /// <returns>Returns true if the removal was succesful, or false if it wasnt.</returns>
        bool RemoveWine(Wine wine);

        /// <summary>
        /// We can remove a wine with this method.
        /// </summary>
        /// <param name="id">The ID of the wine, which will be removed.</param>
        /// <returns>Returns true if the removal was succesful, or false if it wasnt.</returns>
        bool RemoveWine(int id);

        /// <summary>
        /// We can change the price of a wine with this method.
        /// </summary>
        /// <param name="wineId">The ID of the wine, which price will be changed.</param>
        /// <param name="newPrice">The new price of the wine.</param>
        void ChangeWinePrice(int wineId, int newPrice);

        /// <summary>
        /// We can change a wine with this method.
        /// </summary>
        /// <param name="entity">The wine, which will be changed.</param>
        void UpdateWine(Wine entity);

        /// <summary>
        /// We can change a supplier with this method.
        /// </summary>
        /// <param name="entity">The supplier, which will be changed.</param>
        void UpdateSupplier(Supplier entity);

        /// <summary>
        /// We can change a region with this method.
        /// </summary>
        /// <param name="entity">The region, which will be changed.</param>
        void UpdateRegion(Region entity);

        /// <summary>
        /// We can insert a supplier with this method.
        /// </summary>
        /// <param name="supplier">The supplier, which will be insterted.</param>
        void InsertSupplier(Supplier supplier);

        /// <summary>
        /// We can remove a supplier with this method.
        /// </summary>
        /// <param name="supplier">The supplier, which will be removed.</param>
        /// <returns>Returns true if the removal was succesful, or false if it wasnt.</returns>
        bool RemoveSupplier(Supplier supplier);

        /// <summary>
        /// We can remove a supplier with this method.
        /// </summary>
        /// <param name="id">The ID of the supplier, which will be removed.</param>
        /// <returns>Returns true if the removal was succesful, or false if it wasnt.</returns>
        bool RemoveSupplier(int id);

        /// <summary>
        /// We can insert a region with this method.
        /// </summary>
        /// <param name="region">The region, which will be insterted.</param>
        void InsertRegion(Region region);

        /// <summary>
        /// We can remove a region with this method.
        /// </summary>
        /// <param name="region">The region, which will be removed.</param>
        /// <returns>Returns true if the removal was succesful, or false if it wasnt.</returns>
        bool RemoveRegion(Region region);

        /// <summary>
        /// We can remove a region with this method.
        /// </summary>
        /// <param name="id">The ID of the region, which will be removed.</param>
        /// <returns>Returns true if the removal was succesful, or false if it wasnt.</returns>
        bool RemoveRegion(int id);
    }
}
