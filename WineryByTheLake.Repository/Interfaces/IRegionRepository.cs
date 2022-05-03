// <copyright file="IRegionRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WineryByTheLake.Repository
{
    using System.Linq;
    using WineryByTheLake.Models;

    /// <summary>
    /// Specifies all the methods the RegionRepository must implement.
    /// </summary>
    public interface IRegionRepository : IRepository<Region>
    {
        /// <summary>
        /// Changes a specified region.
        /// </summary>
        /// <param name="entity">The region we want to change.</param>
        void Update(Region entity);

        /// <summary>
        /// Returns the suppliers who live in the region.
        /// </summary>
        /// <param name="regionid">The ID of the Supplier whose wines we want to get.</param>
        /// <returns>Returns the suppliers of a single region.</returns>
        public IQueryable<Supplier> GetSuppliers(int regionid);
    }
}
