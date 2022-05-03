// <copyright file="BasicRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using System;

[assembly: CLSCompliant(false)]

namespace WineryByTheLake.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Contains general methods.
    /// </summary>
    /// <typeparam name="T">Generic type.</typeparam>
    public abstract class BasicRepository<T> : IRepository<T>
        where T : class
    {
        private DbContext ctx;

        /// <summary>
        /// Initializes a new instance of the <see cref="BasicRepository{T}"/> class.
        /// </summary>
        /// <param name="ctx">Reference of database.</param>
        protected BasicRepository(DbContext ctx)
        {
            this.ctx = ctx;
        }

        /// <summary>
        /// Gets or sets the database entity.
        /// </summary>
        protected DbContext Ctx
        {
            get
            {
                return this.ctx;
            }

            set
            {
                this.ctx = value;
            }
        }

        /// <summary>
        /// Returns all the elements of a table.
        /// </summary>
        /// /// <returns>All the entities from a table specified by the generic type.</returns>
        public IQueryable<T> GetAll()
        {
            return this.Ctx.Set<T>();
        }

        /// <summary>
        /// Returns an entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the wanted entity.</param>
        /// <returns>Returns an entity specified by the generic type.</returns>
        public abstract T GetOne(int id);

        /// <summary>
        /// Returns an ID by the name of the entity.
        /// </summary>
        /// <param name="name">The name of the entity with the wanted ID.</param>
        /// <returns>Returns an ID.</returns>
        public abstract int GetOnesId(string name);

        /// <summary>
        /// Insert an entity to the right table.
        /// </summary>
        /// <param name="entity">The entity which needs to be inserted.</param>
        public abstract void Insert(T entity);

        /// <summary>
        /// Removes an entity, the input is the ID of the entity we want to remove.
        /// </summary>
        /// <param name="id">The if of the entity which will be removed.</param>
        /// <returns>Returns true if it was succesful, returns false if not.</returns>
        public bool RemoveById(int id)
        {
            T tobedeleted = this.GetOne(id);
            if (this.ctx.Set<T>().Contains(tobedeleted))
            {
                this.ctx.Set<T>().Remove(tobedeleted);
                this.ctx.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Removes an entity, the input is the entity we want to remove.
        /// </summary>
        /// <param name="tobedeleted">The entity which will be removed.</param>
        /// <returns>Returns true if it was succesful, returns false if not.</returns>
        public bool RemoveByObject(T tobedeleted)
        {
            if (this.ctx.Set<T>().Contains(tobedeleted))
            {
                this.ctx.Set<T>().Remove(tobedeleted);
                this.ctx.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
