// <copyright file="WineRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WineryByTheLake.Repository
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using WineryByTheLake.Models;

    /// <summary>
    /// Contains methods specified to wines.
    /// </summary>
    public class WineRepository : BasicRepository<Wine>, IWineRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WineRepository"/> class.
        /// </summary>
        /// <param name="ctx">Reference of database.</param>
        public WineRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// Returns a wine by its ID.
        /// </summary>
        /// <param name="id">The ID of the wanted wine.</param>
        /// <returns>Returns a wine entity specified by the ID.</returns>
        public override Wine GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Returns an ID by the name of the wine.
        /// </summary>
        /// <param name="name">The name of the wine with the wanted ID.</param>
        /// <returns>Returns an ID.</returns>
        public override int GetOnesId(string name)
        {
            return this.Ctx.Set<Wine>().SingleOrDefault(x => x.Name == name).Id;
        }

        /// <summary>
        /// Insert a wine to the right table.
        /// </summary>
        /// <param name="entity">The wine entity which needs to be inserted.</param>
        public override void Insert(Wine entity)
        {
            if (entity != null)
            {
                this.Ctx.Set<Wine>().Add(entity);
                this.Ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Changes a specified wine.
        /// </summary>
        /// <param name="entity">The wine we want to change.</param>
        public void Update(Wine entity)
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
        /// Changes the price of a specified wine.
        /// </summary>
        /// <param name="id">The ID of the wine we want to change the price of.</param>
        /// <param name="newprice">The new price of the wine.</param>
        public void ChangePrice(int id, int newprice)
        {
            var wine = this.GetOne(id);
            if (wine == null)
            {
                throw new InvalidOperationException("not found");
            }

            wine.Price = newprice;
            this.Ctx.SaveChanges();
        }

        /// <summary>
        ///  Changes the sweetness of a specified wine.
        /// </summary>
        /// <param name="id">The ID of the wine we want to change the sweetness of.</param>
        /// <param name="newsweetness">The new sweetness of the wine.</param>
        public void ChangeSweetness(int id, string newsweetness)
        {
            var wine = this.GetOne(id);
            if (wine == null)
            {
                throw new InvalidOperationException("not found");
            }

            wine.Sweetness = newsweetness;
            this.Ctx.SaveChanges();
        }
    }
}
