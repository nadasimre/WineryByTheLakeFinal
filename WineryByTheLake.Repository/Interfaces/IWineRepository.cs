// <copyright file="IWineRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WineryByTheLake.Repository
{
    using WineryByTheLake.Models;

    /// <summary>
    /// Specifies all the methods the WineRepository must implement.
    /// </summary>
    public interface IWineRepository : IRepository<Wine>
    {
        /// <summary>
        /// Changes a specified wine.
        /// </summary>
        /// <param name="entity">The wine we want to change.</param>
        void Update(Wine entity);

        /// <summary>
        /// Changes the price of a specified wine.
        /// </summary>
        /// <param name="id">The ID of the wine we want to change the price of.</param>
        /// <param name="newprice">The new price of the wine.</param>
        void ChangePrice(int id, int newprice);

        /// <summary>
        ///  Changes the sweetness of a specified wine.
        /// </summary>
        /// <param name="id">The ID of the wine we want to change the sweetness of.</param>
        /// <param name="newsweetness">The new sweetness of the wine.</param>
        void ChangeSweetness(int id, string newsweetness);
    }
}
