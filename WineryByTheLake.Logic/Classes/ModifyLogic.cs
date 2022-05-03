// <copyright file="ModifyLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WineryByTheLake.Logic
{
    using System;
    using WineryByTheLake.Models;
    using WineryByTheLake.Repository;

    /// <summary>
    /// Implements the modification methods.
    /// </summary>
    public class ModifyLogic : IModify
    {
        private IWineRepository wine;
        private ISupplierRepository supplier;
        private IRegionRepository region;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModifyLogic"/> class.
        /// </summary>
        /// <param name="wine">Reference of wine repository.</param>
        /// <param name="supplier">Reference of supplier repository.</param>
        /// <param name="region">Reference of region repository.</param>
        public ModifyLogic(IWineRepository wine, ISupplierRepository supplier, IRegionRepository region)
        {
            this.wine = wine;
            this.supplier = supplier;
            this.region = region;
        }

        /// <summary>
        /// We can change the price of a wine with this method.
        /// </summary>
        /// <param name="wineId">The ID of the wine, which price will be changed.</param>
        /// <param name="newPrice">The new price of the wine.</param>
        public void ChangeWinePrice(int wineId, int newPrice)
        {
            this.wine.ChangePrice(wineId, newPrice);
        }

        /// <summary>
        /// We can insert a region with this method.
        /// </summary>
        /// <param name="region">The region, which will be insterted.</param>
        public void InsertRegion(Region region)
        {
            this.region.Insert(region);
        }

        /// <summary>
        /// We can insert a supplier with this method.
        /// </summary>
        /// <param name="supplier">The supplier, which will be insterted.</param>
        public void InsertSupplier(Supplier supplier)
        {
            this.supplier.Insert(supplier);
        }

        /// <summary>
        /// We can insert a wine with this method.
        /// </summary>
        /// <param name="wine">The wine, which will be insterted.</param>
        public void InsertWine(Wine wine)
        {
            if (wine != null)
            {
                this.wine.Insert(wine);
                this.supplier.CalculateWinePrice(this.supplier.GetOne(wine.SupplierID)); // Recalculating the sum of the prices of the wines the supplier of the removed wine has
            }
        }

        /// <summary>
        /// We can change a wine with this method.
        /// </summary>
        /// <param name="entity">The wine, which will be changed.</param>
        public void UpdateWine(Wine entity)
        {
            this.wine.Update(entity);
        }

        /// <summary>
        /// We can change a supplier with this method.
        /// </summary>
        /// <param name="entity">The supplier, which will be changed.</param>
        public void UpdateSupplier(Supplier entity)
        {
            this.supplier.Update(entity);
        }

        /// <summary>
        /// We can change a region with this method.
        /// </summary>
        /// <param name="entity">The region, which will be changed.</param>
        public void UpdateRegion(Region entity)
        {
            this.region.Update(entity);
        }

        /// <summary>
        /// We can remove a region with this method.
        /// </summary>
        /// <param name="region">The region, which will be removed.</param>
        /// <returns>Returns true if the removal was succesful, or false if it wasnt.</returns>
        public bool RemoveRegion(Region region)
        {
            return this.region.RemoveByObject(region);
        }

        /// <summary>
        /// We can remove a region with this method.
        /// </summary>
        /// <param name="id">The ID of the region, which will be removed.</param>
        /// <returns>Returns true if the removal was succesful, or false if it wasnt.</returns>
        public bool RemoveRegion(int id)
        {
            return this.region.RemoveById(id);
        }

        /// <summary>
        /// We can remove a supplier with this method.
        /// </summary>
        /// <param name="supplier">The supplier, which will be removed.</param>
        /// <returns>Returns true if the removal was succesful, or false if it wasnt.</returns>
        public bool RemoveSupplier(Supplier supplier)
        {
            return this.supplier.RemoveByObject(supplier);
        }

        /// <summary>
        /// We can remove a supplier with this method.
        /// </summary>
        /// <param name="id">The ID of the supplier, which will be removed.</param>
        /// <returns>Returns true if the removal was succesful, or false if it wasnt.</returns>
        public bool RemoveSupplier(int id)
        {
            return this.supplier.RemoveById(id);
        }

        /// <summary>
        /// We can remove a wine with this method.
        /// </summary>
        /// <param name="wine">The wine, which will be removed.</param>
        /// <returns>Returns true if the removal was succesful, or false if it wasnt.</returns>
        public bool RemoveWine(Wine wine)
        {
            if (wine != null)
            {
                int supplierid = wine.SupplierID;
                bool success = this.wine.RemoveByObject(wine);
                this.supplier.CalculateWinePrice(this.supplier.GetOne(supplierid)); // Recalculating the sum of the prices of the wines the supplier of the removed wine has
                return success;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// We can remove a wine with this method.
        /// </summary>
        /// <param name="id">The ID of the wine, which will be removed.</param>
        /// <returns>Returns true if the removal was succesful, or false if it wasnt.</returns>
        public bool RemoveWine(int id)
        {
            int supplierid = this.wine.GetOne(id).SupplierID;
            bool success = this.wine.RemoveById(id);
            this.supplier.CalculateWinePrice(this.supplier.GetOne(supplierid)); // Recalculating the sum of the prices of the wines the supplier of the removed wine has
            return success;
        }
    }
}
