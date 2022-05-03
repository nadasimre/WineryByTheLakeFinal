// <copyright file="RegionRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WineryByTheLake.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using WineryByTheLake.Models;

    /// <summary>
    /// Contains methods specified to regions.
    /// </summary>
    public class RegionRepository : BasicRepository<Region>, IRegionRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegionRepository"/> class.
        /// </summary>
        /// <param name="ctx">Reference of database.</param>
        public RegionRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// Returns a region by its ID.
        /// </summary>
        /// <param name="id">The ID of the wanted region.</param>
        /// <returns>Returns a region entity specified by the ID.</returns>
        public override Region GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Returns an ID by the name of the region.
        /// </summary>
        /// <param name="name">The name of the region with the wanted ID.</param>
        /// <returns>Returns an ID.</returns>
        public override int GetOnesId(string name)
        {
            return this.Ctx.Set<Region>().SingleOrDefault(x => x.Name == name).Id;
        }

        /// <summary>
        /// Insert a region to the right table.
        /// </summary>
        /// <param name="entity">The region entity which needs to be inserted.</param>
        public override void Insert(Region entity)
        {
            if (entity != null)
            {
                this.Ctx.Set<Region>().Add(entity);
                this.Ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Changes a specified region.
        /// </summary>
        /// <param name="entity">The region we want to change.</param>
        public void Update(Region entity)
        {
            var old = this.GetOne(entity.Id);
            if (old == null)
            {
                throw new ArgumentException("Item doesn't exist..");
            }

            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(entity));
                }
            }

            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// Returns the suppliers who live in the region.
        /// </summary>
        /// <param name="regionid">The ID of the Supplier whose wines we want to get.</param>
        /// <returns>Returns the suppliers of a single region.</returns>
        public IQueryable<Supplier> GetSuppliers(int regionid)
        {
            return this.Ctx.Set<Supplier>().Where(x => x.RegionID == regionid);
        }
    }
}
