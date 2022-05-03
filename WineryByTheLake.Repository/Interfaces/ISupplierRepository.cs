// <copyright file="ISupplierRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WineryByTheLake.Repository
{
    using System.Linq;
    using WineryByTheLake.Models;

    /// <summary>
    /// Specifies all the methods the SupplierRepository must implement.
    /// </summary>
    public interface ISupplierRepository : IRepository<Supplier>
    {
        /// <summary>
        /// Changes a specified supplier.
        /// </summary>
        /// <param name="entity">The supplier we want to change.</param>
        void Update(Supplier entity);

        /// <summary>
        /// Returns the wines which the supplier has.
        /// </summary>
        /// <param name="supplierid">The ID of the Supplier whose wines we want to get.</param>
        /// <returns>Returns the wines of a single supplier.</returns>
        public IQueryable<Wine> GetWines(int supplierid);

        /// <summary>
        /// Calculates the sum of the prices of the wines of a single supplier.
        /// </summary>
        /// <param name="supplier">The Supplier whose wines we want to sum.</param>
        public void CalculateWinePrice(Supplier supplier);
    }
}
