// <copyright file="MockedRepos.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using System;

[assembly: CLSCompliant(false)]

namespace WineryByTheLake.Logic.Tests
{
    using Moq;
    using WineryByTheLake.Repository;

    /// <summary>
    /// Creates the mocked repositories for the tests.
    /// </summary>
    internal class MockedRepos
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MockedRepos"/> class.
        /// </summary>
        public MockedRepos()
        {
            this.MockedWineRepository = new Mock<IWineRepository>();
            this.MockedSupplierRepository = new Mock<ISupplierRepository>();
            this.MockedRegionRepository = new Mock<IRegionRepository>();
        }

        /// <summary>
        /// Gets the wine repository property.
        /// </summary>
        public Mock<IWineRepository> MockedWineRepository { get; }

        /// <summary>
        /// Gets the wine repository property.
        /// </summary>
        public Mock<ISupplierRepository> MockedSupplierRepository { get; }

        /// <summary>
        /// Gets the wine repository property.
        /// </summary>
        public Mock<IRegionRepository> MockedRegionRepository { get; }
    }
}
