// <copyright file="IProduct.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WineryByTheLake.Logic
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using WineryByTheLake.Models;

    /// <summary>
    /// Specifies the methods required to track the properties of the products.
    /// </summary>
    public interface IProduct
    {
        /// <summary>
        /// Returns the average of the prices of the wines by supplier.
        /// </summary>
        /// <returns>Returns a list of wine price averages distributed by suppliers.</returns>
        ICollection<AverageWinePrice> AverageWinePriceBySupplier();

        /// <summary>
        /// Async version of the method AverageWinePriceBySupplier.
        /// </summary>
        /// <returns>A task object.</returns>
        Task<ICollection<AverageWinePrice>> AverageWinePriceBySupplierAsync();

        /// <summary>
        /// Returns the average of the prices of the wines by region.
        /// </summary>
        /// <returns>Returns a list of wine price averages distributed by regions.</returns>
        ICollection<AverageWinePrice> AverageWinePriceByRegion();

        /// <summary>
        /// Async version of the method AverageWinePriceByRegion.
        /// </summary>
        /// <returns>A task object.</returns>
        Task<ICollection<AverageWinePrice>> AverageWinePriceByRegionAsync();

        /// <summary>
        /// Returns the average value of the stocks the suppliers have.
        /// </summary>
        /// <returns>Returns a list of stock price averages.</returns>
        ICollection<AverageWinePrice> AverageSupplierStock();

        /// <summary>
        /// Returns the rose wines.
        /// </summary>
        /// <returns>Returns a list of wines which color is rose.</returns>
        ICollection<Wine> Rose();

        /// <summary>
        /// Async version of the method Rose.
        /// </summary>
        /// <returns>A task object.</returns>
        Task<ICollection<Wine>> RoseAsync();

        /// <summary>
        /// Returns the red wines.
        /// </summary>
        /// <returns>Returns a list of wines which color is rose.</returns>
        ICollection<Wine> Red();

        /// <summary>
        /// Async version of the method Red.
        /// </summary>
        /// <returns>A task object.</returns>
        Task<ICollection<Wine>> RedAsync();

        /// <summary>
        /// Returns the white wines.
        /// </summary>
        /// <returns>Returns a list of wines which color is rose.</returns>
        ICollection<Wine> White();

        /// <summary>
        /// Async version of the method White.
        /// </summary>
        /// <returns>A task object.</returns>
        Task<ICollection<Wine>> WhiteAsync();
    }
}
