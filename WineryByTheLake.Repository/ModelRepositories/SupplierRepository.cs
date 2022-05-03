// <copyright file="SupplierRepository.cs" company="PlaceholderCompany">
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
    /// Contains methods specified to suppliers.
    /// </summary>
    public class SupplierRepository : BasicRepository<Supplier>, ISupplierRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SupplierRepository"/> class.
        /// </summary>
        /// <param name="ctx">Reference of database.</param>
        public SupplierRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// Returns a supplier by its ID.
        /// </summary>
        /// <param name="id">The ID of the wanted supplier.</param>
        /// <returns>Returns a supplier entity specified by the ID.</returns>
        public override Supplier GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Returns an ID by the name of the supplier.
        /// </summary>
        /// <param name="name">The name of the supplier with the wanted ID.</param>
        /// <returns>Returns an ID.</returns>
        public override int GetOnesId(string name)
        {
            return this.Ctx.Set<Supplier>().SingleOrDefault(x => x.Name == name).Id;
        }

        /// <summary>
        /// Insert a supplier to the right table.
        /// </summary>
        /// <param name="entity">The supplier entity which needs to be inserted.</param>
        public override void Insert(Supplier entity)
        {
            if (entity != null)
            {
                this.Ctx.Set<Supplier>().Add(entity);
                this.Ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Changes a specified supplier.
        /// </summary>
        /// <param name="entity">The supplier we want to change.</param>
        public void Update(Supplier entity)
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
        /// Returns the wines which the supplier has.
        /// </summary>
        /// <param name="supplierid">The ID of the Supplier whose wines we want to get.</param>
        /// <returns>Returns the wines of a single supplier.</returns>
        public IQueryable<Wine> GetWines(int supplierid)
        {
            return this.Ctx.Set<Wine>().Where(x => x.SupplierID == supplierid);
        }

        /// <summary>
        /// Calculates the sum of the prices of the wines of a single supplier.
        /// </summary>
        /// <param name="supplier">The Supplier whose wines we want to sum.</param>
        public void CalculateWinePrice(Supplier supplier)
        {
            if (supplier != null)
            {
                int price = 0;
                if (supplier.Wines != null)
                {
                    foreach (var item in supplier.Wines)
                    {
                        price += item.Price;
                    }
                }

                supplier.WinePriceSum = price;
                this.Ctx.SaveChanges();
            }
        }
    }
}
