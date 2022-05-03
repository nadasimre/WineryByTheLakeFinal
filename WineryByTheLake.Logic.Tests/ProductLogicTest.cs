// <copyright file="ProductLogicTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WineryByTheLake.Logic.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Moq;
    using NUnit.Framework;
    using WineryByTheLake.Models;

    /// <summary>
    /// Testing class of the product logic class.
    /// </summary>
    [TestFixture]
    public class ProductLogicTest
    {
        /// <summary>
        /// Test of the AverageWinePriceBySupplier method.
        /// </summary>
        [Test]
        public void TestAverageWinePriceBySupplier()
        {
            MockedRepos repos = new MockedRepos();

            List<Wine> wines = new List<Wine>()
            {
                new Wine() { Name = "testWine1", Id = 1, SupplierID = 1, Price = 10 },
                new Wine() { Name = "testWine2", Id = 2, SupplierID = 1, Price = 20 },
                new Wine() { Name = "testWine3", Id = 3, SupplierID = 2, Price = 20 },
                new Wine() { Name = "testWine3", Id = 4, SupplierID = 2, Price = 40 },
            };

            List<Supplier> suppliers = new List<Supplier>()
            {
                new Supplier() { Name = "testSupplier1", Id = 1 },
                new Supplier() { Name = "testSupplier2", Id = 2 },
            };

            List<AverageWinePrice> averageWinePrice = new List<AverageWinePrice>()
            {
                new AverageWinePrice() { Name = "testSupplier1", Value = 15 },
                new AverageWinePrice() { Name = "testSupplier2", Value = 30 },
            };

            repos.MockedWineRepository.Setup(repo => repo.GetAll()).Returns(wines.AsQueryable);
            repos.MockedSupplierRepository.Setup(repo => repo.GetAll()).Returns(suppliers.AsQueryable);
            repos.MockedWineRepository.Setup(repo => repo.GetOne(1)).Returns(wines[0]);

            ProductLogic logic = new ProductLogic(repos.MockedWineRepository.Object, repos.MockedSupplierRepository.Object, repos.MockedRegionRepository.Object);
            var result = logic.AverageWinePriceBySupplier();

            repos.MockedWineRepository.Verify(repo => repo.GetAll(), Times.Once);
            repos.MockedSupplierRepository.Verify(repo => repo.GetAll(), Times.Once);
            repos.MockedWineRepository.Verify(repo => repo.GetOne(It.IsAny<int>()), Times.Never);
            Assert.That(result, Is.EquivalentTo(averageWinePrice));
        }

        /// <summary>
        /// Test of the AverageWinePriceByRegion method.
        /// </summary>
        [Test]
        public void TestAverageWinePriceByRegion()
        {
            MockedRepos repos = new MockedRepos();

            List<Wine> wines = new List<Wine>()
            {
                new Wine() { Name = "testWine1", Id = 1, SupplierID = 1, Price = 10 },
                new Wine() { Name = "testWine2", Id = 2, SupplierID = 1, Price = 20 },
                new Wine() { Name = "testWine3", Id = 3, SupplierID = 2, Price = 20 },
                new Wine() { Name = "testWine3", Id = 4, SupplierID = 2, Price = 40 },
            };

            List<Supplier> suppliers = new List<Supplier>()
            {
                new Supplier() { Name = "testSupplier1", Id = 1, RegionID = 1 },
                new Supplier() { Name = "testSupplier2", Id = 2, RegionID = 2 },
            };

            List<Region> regions = new List<Region>()
            {
                new Region() { Name = "testRegion1", Id = 1 },
                new Region() { Name = "testRegion2", Id = 2 },
            };

            List<AverageWinePrice> averageWinePrice = new List<AverageWinePrice>()
            {
                new AverageWinePrice() { Name = "testRegion1", Value = 15 },
                new AverageWinePrice() { Name = "testRegion2", Value = 30 },
            };

            repos.MockedWineRepository.Setup(repo => repo.GetAll()).Returns(wines.AsQueryable);
            repos.MockedSupplierRepository.Setup(repo => repo.GetAll()).Returns(suppliers.AsQueryable);
            repos.MockedRegionRepository.Setup(repo => repo.GetAll()).Returns(regions.AsQueryable);
            repos.MockedWineRepository.Setup(repo => repo.GetOne(1)).Returns(wines[0]);

            ProductLogic logic = new ProductLogic(repos.MockedWineRepository.Object, repos.MockedSupplierRepository.Object, repos.MockedRegionRepository.Object);
            var result = logic.AverageWinePriceByRegion();

            repos.MockedWineRepository.Verify(repo => repo.GetAll(), Times.Once);
            repos.MockedSupplierRepository.Verify(repo => repo.GetAll(), Times.Once);
            repos.MockedRegionRepository.Verify(repo => repo.GetAll(), Times.Once);
            repos.MockedWineRepository.Verify(repo => repo.GetOne(It.IsAny<int>()), Times.Never);
            Assert.That(result, Is.EquivalentTo(averageWinePrice));
        }

        /// <summary>
        /// Test of the AverageSupplierStock method.
        /// </summary>
        [Test]
        public void TestAverageSupplierStock()
        {
            MockedRepos repos = new MockedRepos();

            List<Supplier> suppliers = new List<Supplier>()
            {
                new Supplier() { Name = "testSupplier1", Id = 1, RegionID = 1, WinePriceSum = 50 },
                new Supplier() { Name = "testSupplier2", Id = 2, RegionID = 1, WinePriceSum = 50 },
                new Supplier() { Name = "testSupplier3", Id = 3, RegionID = 2, WinePriceSum = 100 },
                new Supplier() { Name = "testSupplier4", Id = 4, RegionID = 2, WinePriceSum = 100 },
            };

            List<Region> regions = new List<Region>()
            {
                new Region() { Name = "testRegion1", Id = 1 },
                new Region() { Name = "testRegion2", Id = 2 },
            };

            List<AverageWinePrice> averageWinePrice = new List<AverageWinePrice>()
            {
                new AverageWinePrice() { Name = "testRegion1", Value = 50 },
                new AverageWinePrice() { Name = "testRegion2", Value = 100 },
            };

            repos.MockedSupplierRepository.Setup(repo => repo.GetAll()).Returns(suppliers.AsQueryable);
            repos.MockedRegionRepository.Setup(repo => repo.GetAll()).Returns(regions.AsQueryable);
            repos.MockedSupplierRepository.Setup(repo => repo.GetOne(1)).Returns(suppliers[0]);

            ProductLogic logic = new ProductLogic(repos.MockedWineRepository.Object, repos.MockedSupplierRepository.Object, repos.MockedRegionRepository.Object);
            var result = logic.AverageSupplierStock();

            repos.MockedSupplierRepository.Verify(repo => repo.GetAll(), Times.Once);
            repos.MockedRegionRepository.Verify(repo => repo.GetAll(), Times.Once);
            repos.MockedSupplierRepository.Verify(repo => repo.GetOne(It.IsAny<int>()), Times.Never);
            Assert.That(result, Is.EquivalentTo(averageWinePrice));
        }

        /// <summary>
        /// Test of the Rose method.
        /// </summary>
        [Test]
        public void TestRose()
        {
            MockedRepos repos = new MockedRepos();

            List<Wine> wines = new List<Wine>()
            {
                new Wine() { Name = "testWine1", Id = 1, Color = ColorE.Rose },
                new Wine() { Name = "testWine2", Id = 2, Color = ColorE.Rose },
                new Wine() { Name = "testWine3", Id = 3, Color = ColorE.White },
                new Wine() { Name = "testWine3", Id = 4, Color = ColorE.Red },
            };

            List<Wine> expectedResult = new List<Wine>()
            {
                new Wine() { Name = "testWine1", Id = 1, Color = ColorE.Rose },
                new Wine() { Name = "testWine2", Id = 2, Color = ColorE.Rose },
            };

            repos.MockedWineRepository.Setup(repo => repo.GetAll()).Returns(wines.AsQueryable);
            repos.MockedWineRepository.Setup(repo => repo.GetOne(1)).Returns(wines[0]);

            ProductLogic logic = new ProductLogic(repos.MockedWineRepository.Object, repos.MockedSupplierRepository.Object, repos.MockedRegionRepository.Object);
            var result = logic.Rose();

            repos.MockedWineRepository.Verify(repo => repo.GetAll(), Times.Once);
            repos.MockedWineRepository.Verify(repo => repo.GetOne(It.IsAny<int>()), Times.Never);
            Assert.That(result, Is.EquivalentTo(expectedResult));
        }
    }
}
