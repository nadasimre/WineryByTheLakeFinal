// <copyright file="IRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WineryByTheLake.Repository
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Specifies all the methods every class in the Repository layer must implement.
    /// </summary>
    /// <typeparam name="T">Generic type.</typeparam>
    public interface IRepository<T>
        where T : class
    {
        /// <summary>
        /// Returns an entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the wanted entity.</param>
        /// <returns>Returns an entity.</returns>
        T GetOne(int id);

        /// <summary>
        /// Returns an ID by the name of the entity.
        /// </summary>
        /// <param name="name">The name of the entity with the wanted ID.</param>
        /// <returns>Returns an ID.</returns>
        int GetOnesId(string name);

        /// <summary>
        /// Returns all entities.
        /// </summary>
        /// <returns>Returns all the entities which have the specified generic type.</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Insert an entity to the right table.
        /// </summary>
        /// <param name="entity">The entity which needs to be inserted.</param>
        void Insert(T entity);

        /// <summary>
        /// Removes an entity, the input is the entity we want to remove.
        /// </summary>
        /// <param name="tobedeleted">The entity which will be removed.</param>
        /// <returns>Returns true if it was succesful, returns false if not.</returns>
        bool RemoveByObject(T tobedeleted);

        /// <summary>
        /// Removes an entity, the input is the ID of the entity we want to remove.
        /// </summary>
        /// <param name="id">The if of the entity which will be removed.</param>
        /// <returns>Returns true if it was succesful, returns false if not.</returns>
        bool RemoveById(int id);
    }
}
