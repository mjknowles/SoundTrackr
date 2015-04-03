﻿using System;
using System.Linq;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoundTrackr.Common.UnitOfWork;
using Moq;
using SoundTrackr.Repository;
using SoundTrackr.Repository.Repositories;
using System.Collections.Generic;
using SoundTrackr.Common.Domain;
using SoundTrackr.Domain.Entities.Track;

namespace SoundTrackr.Web.Tests.Repositories
{
    public class TestEntity : EntityBase<int>, IAggregateRoot 
    {
        protected override void Validate()
        {
        }
    }

    public class TestGenericRepo : GenericDomainTypeRepository<TestEntity, int> 
    {
        public TestGenericRepo(IUnitOfWork unitOfWork, IDbContextFactory dbContextFactory) : base(unitOfWork, dbContextFactory) { }
    }

    [TestClass]
    public class GenericRepoTests
    {
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private Mock<IDbContextFactory> _mockDbContextFactory;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockDbContextFactory = new Mock<IDbContextFactory>();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _mockUnitOfWork.VerifyAll();
            _mockDbContextFactory.VerifyAll();
        }

        [TestMethod]
        public void GenericRepo_FindById()
        {
            var data = new List<TestEntity> 
            { 
                new TestEntity { Id = 0 }, 
                new TestEntity { Id = 1 }, 
                new TestEntity { Id = 2 }, 
            }.AsQueryable();
            
            
            var mockSet = new Mock<DbSet<TestEntity>>();
            mockSet.As<IQueryable<TestEntity>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<TestEntity>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<TestEntity>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<TestEntity>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<DbContext>();
            mockContext.Setup(c => c.Set<TestEntity>()).Returns(mockSet.Object);

            _mockDbContextFactory.Setup(x => x.Create()).Returns(mockContext.Object);

            TestGenericRepo testRepo = new TestGenericRepo(_mockUnitOfWork.Object, _mockDbContextFactory.Object);

            var expectedModel = new Track { Id = 1 };
            var actualModel = testRepo.FindById(1);

            Assert.AreEqual(expectedModel.Id, actualModel.Id);
        }
    }
}
