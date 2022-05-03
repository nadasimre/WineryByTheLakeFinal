// <copyright file="ProductLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WineryByTheLake.Logic
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using WineryByTheLake.Models;
    using WineryByTheLake.Repository;

    /// <summary>
    /// Implements the methods required to track the properties of the products.
    /// </summary>
    public class ProductLogic : IProduct
    {
        private IWineRepository wines;
        private ISupplierRepository suppliers;
        private IRegionRepository regions;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductLogic"/> class.
        /// </summary>
        /// <param name="wine">Reference of wine repository.</param>
        /// <param name="supplier">Reference of supplier repository.</param>
        /// <param name="region">Reference of region repository.</param>
        public ProductLogic(IWineRepository wine, ISupplierRepository supplier, IRegionRepository region)
        {
            this.wines = wine;
            this.suppliers = supplier;
            this.regions = region;
        }

        /// <summary>
        /// Returns the average of the prices of the wines by suppliers.
        /// </summary>
        /// <returns>Returns a list of wine price averages distributed by suppliers.</returns>
        public ICollection<AverageWinePrice> AverageWinePriceBySupplier()
        {
            var q1 = from wine in this.wines.GetAll()
                    join supplier in this.suppliers.GetAll() on wine.SupplierID equals supplier.Id
                    let winesBySuppliers = new { Name = supplier.Name, Price = wine.Price }
                    group winesBySuppliers by winesBySuppliers.Name into grp
                    select new AverageWinePrice
                    {
                        Name = grp.Key,
                        Value = grp.Average(x => x.Price),
                    };
            return q1.ToList();
        }

        /// <summary>
        /// Async version of the method AverageWinePriceBySupplier.
        /// </summary>
        /// <returns>A task object.</returns>
        public Task<ICollection<AverageWinePrice>> AverageWinePriceBySupplierAsync()
        {
            return Task.Run(() => this.AverageWinePriceBySupplier());
        }

        /// <summary>
        /// Returns the average of the prices of the wines by region.
        /// </summary>
        /// <returns>Returns a list of wine price averages distributed by regions.</returns>
        public ICollection<AverageWinePrice> AverageWinePriceByRegion()
        {
            var q2 = from wine in this.wines.GetAll()
                     join supplier in this.suppliers.GetAll() on wine.SupplierID equals supplier.Id
                     join region in this.regions.GetAll() on supplier.RegionID equals region.Id
                     let winesByRegions = new { Name = region.Name, Price = wine.Price }
                     group winesByRegions by winesByRegions.Name into grp
                     select new AverageWinePrice
                     {
                         Name = grp.Key,
                         Value = grp.Average(x => x.Price),
                     };
            return q2.ToList();
        }

        /// <summary>
        /// Async version of the method AverageWinePriceByRegion.
        /// </summary>
        /// <returns>A task object.</returns>
        public Task<ICollection<AverageWinePrice>> AverageWinePriceByRegionAsync()
        {
            return Task.Run(() => this.AverageWinePriceByRegion());
        }

        /// <summary>
        /// Returns the average value of the stocks the suppliers have.
        /// </summary>
        /// <returns>Returns a list of stock price averages distributed by regions.</returns>
        public ICollection<AverageWinePrice> AverageSupplierStock()
        {
            var q3 = from suppliers in this.suppliers.GetAll()
                     join regions in this.regions.GetAll() on suppliers.RegionID equals regions.Id
                     let stocks = new { Name = regions.Name, Value = suppliers.WinePriceSum }
                     group stocks by stocks.Name into grp
                     select new AverageWinePrice
                     {
                         Name = grp.Key,
                         Value = grp.Average(stock => stock.Value),
                     };
            return q3.ToList();
        }

        /// <summary>
        /// Async version of the method AverageSupplierStock.
        /// </summary>
        /// <returns>A task object.</returns>
        public Task<ICollection<AverageWinePrice>> AverageSupplierStockAsync()
        {
            return Task.Run(() => this.AverageSupplierStock());
        }

        /// <summary>
        /// Returns the rose wines.
        /// </summary>
        /// <returns>Returns a list of wines which color is rose.</returns>
        public ICollection<Wine> Rose()
        {
            var q4 = from wine in this.wines.GetAll()
                     where wine.Color == ColorE.Rose
                     select wine;
            return q4.ToList();
        }

        /// <summary>
        /// Async version of the method Rose.
        /// </summary>
        /// <returns>A task object.</returns>
        public Task<ICollection<Wine>> RoseAsync()
        {
            return Task.Run(() => this.Rose());
        }

        /// <summary>
        /// Returns the red wines.
        /// </summary>
        /// <returns>Returns a list of wines which color is rose.</returns>
        public ICollection<Wine> Red()
        {
            var q5 = from wine in this.wines.GetAll()
                     where wine.Color == ColorE.Red
                     select wine;
            return q5.ToList();
        }

        /// <summary>
        /// Async version of the method Red.
        /// </summary>
        /// <returns>A task object.</returns>
        public Task<ICollection<Wine>> RedAsync()
        {
            return Task.Run(() => this.Red());
        }

        /// <summary>
        /// Returns the white wines.
        /// </summary>
        /// <returns>Returns a list of wines which color is rose.</returns>
        public ICollection<Wine> White()
        {
            var q6 = from wine in this.wines.GetAll()
                     where wine.Color == ColorE.White
                     select wine;
            return q6.ToList();
        }

        /// <summary>
        /// Async version of the method White.
        /// </summary>
        /// <returns>A task object.</returns>
        public Task<ICollection<Wine>> WhiteAsync()
        {
            return Task.Run(() => this.White());
        }
    }
}
