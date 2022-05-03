// <copyright file="ListingLogicTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WineryByTheLake.Logic.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Moq;
    using NUnit.Framework;
    using WineryByTheLake.Models;
    using WineryByTheLake.Repository;

    /// <summary>
    /// Testing class of the listing logic class.
    /// </summary>
    [TestFixture]
    public class ListingLogicTest
    {
        /// <summary>
        /// Test of the GetWine method.
        /// </summary>
        [Test]
        public void TestGetWine()
        {
            MockedRepos repos = new MockedRepos();

            List<Wine> wines = new List<Wine>()
            {
                new Wine() { Name = "testWine1", Id = 1 },
                new Wine() { Name = "testWine2", Id = 2 },
                new Wine() { Name = "testWine3", Id = 3 },
            };

            repos.MockedWineRepository.Setup(repo => repo.GetOne(3)).Returns(wines[2]);
            repos.MockedWineRepository.Setup(repo => repo.GetAll()).Returns(wines.AsQueryable);

            ListingLogic logic = new ListingLogic(repos.MockedWineRepository.Object, repos.MockedSupplierRepository.Object, repos.MockedRegionRepository.Object);
            var expectedResult = logic.GetWine(3);

            repos.MockedWineRepository.Verify(repo => repo.GetAll(), Times.Once);
            repos.MockedWineRepository.Verify(repo => repo.GetOne(It.IsAny<int>()), Times.Never);
        }

        /// <summary>
        /// Test of the GetAllSuppliers method.
        /// </summary>
        [Test]
        public void TestGetAllSuppliers()
        {
            MockedRepos repos = new MockedRepos();

            List<Supplier> suppliers = new List<Supplier>()
            {
                new Supplier() { Name = "testSupplier1" },
                new Supplier() { Name = "testSupplier2" },
                new Supplier() { Name = "testSupplier3" },
            };

            repos.MockedSupplierRepository.Setup(repo => repo.GetOne(3)).Returns(suppliers[2]);
            repos.MockedSupplierRepository.Setup(repo => repo.GetAll()).Returns(suppliers.AsQueryable());

            ListingLogic logic = new ListingLogic(repos.MockedWineRepository.Object, repos.MockedSupplierRepository.Object, repos.MockedRegionRepository.Object);
            var expectedResult = logic.GetAllSuppliers();

            repos.MockedSupplierRepository.Verify(repo => repo.GetAll(), Times.Once);
            repos.MockedSupplierRepository.Verify(repo => repo.GetOne(It.IsAny<int>()), Times.Never);
        }

        /// <summary>
        /// Test of the GetRegion method.
        /// </summary>
        [Test]
        public void TestGetRegion()
        {
            MockedRepos repos = new MockedRepos();

            List<Region> wines = new List<Region>()
            {
                new Region() { Name = "testRegion1", Id = 1 },
                new Region() { Name = "testRegion2", Id = 2 },
                new Region() { Name = "testRegion3", Id = 3 },
            };

            repos.MockedRegionRepository.Setup(repo => repo.GetOne(3)).Returns(wines[2]);
            repos.MockedRegionRepository.Setup(repo => repo.GetAll()).Returns(wines.AsQueryable);

            ListingLogic logic = new ListingLogic(repos.MockedWineRepository.Object, repos.MockedSupplierRepository.Object, repos.MockedRegionRepository.Object);
            var expectedResult = logic.GetRegion(3);

            repos.MockedRegionRepository.Verify(repo => repo.GetAll(), Times.Once);
            repos.MockedRegionRepository.Verify(repo => repo.GetOne(It.IsAny<int>()), Times.Never);
        }
    }
}
