// <copyright file="ModifyLogicTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WineryByTheLake.Logic.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Moq;
    using NUnit.Framework;
    using WineryByTheLake.Models;
    using WineryByTheLake.Repository;

    /// <summary>
    /// Testing class of the modify logic class.
    /// </summary>
    [TestFixture]
    public class ModifyLogicTest
    {
        /// <summary>
        /// Test of the RemoveWine (by Id) method.
        /// </summary>
        [Test]
        public void TestRemoveWine()
        {
            MockedRepos repos = new MockedRepos();

            Supplier testSupplier = new Supplier { Name = "Varga József" };
            Wine testWine = new Wine { Name = "LaFiesta édes élmény", Id = 1, SupplierID = 2 };

            repos.MockedWineRepository.Setup(repo => repo.GetOne(1)).Returns(testWine);
            repos.MockedWineRepository.Setup(repo => repo.RemoveById(1)).Returns(true);
            repos.MockedSupplierRepository.Setup(repo => repo.GetOne(2)).Returns(testSupplier);
            repos.MockedSupplierRepository.Setup(repo => repo.CalculateWinePrice(testSupplier));

            ModifyLogic logic = new ModifyLogic(repos.MockedWineRepository.Object, repos.MockedSupplierRepository.Object, repos.MockedRegionRepository.Object);
            var expectedResult = logic.RemoveWine(1);

            repos.MockedWineRepository.Verify(repo => repo.RemoveById(1), Times.Once);
            repos.MockedWineRepository.Verify(repo => repo.RemoveById(It.IsAny<int>()), Times.Once);
            repos.MockedWineRepository.Verify(repo => repo.GetOne(It.IsAny<int>()), Times.Once);
            repos.MockedWineRepository.Verify(repo => repo.GetOne(1), Times.Once);
            repos.MockedSupplierRepository.Verify(repo => repo.CalculateWinePrice(testSupplier), Times.Once);
            repos.MockedSupplierRepository.Verify(repo => repo.CalculateWinePrice(It.IsAny<Supplier>()), Times.Once);
            repos.MockedSupplierRepository.Verify(repo => repo.GetOne(It.IsAny<int>()), Times.Once);
            repos.MockedSupplierRepository.Verify(repo => repo.GetOne(2), Times.Once);
        }

        /// <summary>
        /// Test of the InsertRegion method.
        /// </summary>
        [Test]
        public void TestInsertRegion()
        {
            MockedRepos repos = new MockedRepos();

            Region testRegion = new Region { Name = "testRegion", Id = 1 };

            repos.MockedRegionRepository.Setup(repo => repo.GetOne(1)).Returns(testRegion);
            repos.MockedRegionRepository.Setup(repo => repo.Insert(testRegion));

            ModifyLogic logic = new ModifyLogic(repos.MockedWineRepository.Object, repos.MockedSupplierRepository.Object, repos.MockedRegionRepository.Object);
            logic.InsertRegion(testRegion);

            repos.MockedRegionRepository.Verify(repo => repo.Insert(testRegion), Times.Once);
            repos.MockedRegionRepository.Verify(repo => repo.Insert(It.IsAny<Region>()), Times.Once);
        }

        /// <summary>
        /// Test of the ChangeWinePrice method.
        /// </summary>
        [Test]
        public void TestChangeWinePrice()
        {
            MockedRepos repos = new MockedRepos();

            List<Wine> wines = new List<Wine>()
            {
                new Wine() { Name = "testWine1", Id = 1, Price = 10 },
                new Wine() { Name = "testWine2", Id = 2, Price = 20 },
                new Wine() { Name = "testWine3", Id = 3, Price = 20 },
                new Wine() { Name = "testWine3", Id = 4, Price = 40 },
            };

            repos.MockedWineRepository.Setup(repo => repo.GetAll()).Returns(wines.AsQueryable);
            repos.MockedWineRepository.Setup(repo => repo.GetOne(1)).Returns(wines[0]);
            repos.MockedWineRepository.Setup(repo => repo.ChangePrice(1, 25));

            ModifyLogic logic = new ModifyLogic(repos.MockedWineRepository.Object, repos.MockedSupplierRepository.Object, repos.MockedRegionRepository.Object);
            logic.ChangeWinePrice(1, 25);

            repos.MockedWineRepository.Verify(repo => repo.GetAll(), Times.Never);
            repos.MockedWineRepository.Verify(repo => repo.ChangePrice(1, 25), Times.Once);
        }
    }
}
