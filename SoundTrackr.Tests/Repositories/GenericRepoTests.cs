using System;
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
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;

namespace SoundTrackr.Web.Tests.Repositories
{
    public class TestEntity : EntityBase<int>, IAggregateRoot 
    {
        protected override void Validate()
        {
        }
    }

    public class TestEntityDb : EntityBase<int>, IAggregateRoot
    {
        protected override void Validate()
        {
        }
    }

    public class TestGenericRepo : GenericDomainTypeRepository<TestEntity, TestEntityDb, int> 
    {
        public TestGenericRepo(IUnitOfWork unitOfWork, IDbContextFactory dbContextFactory) : base(unitOfWork, dbContextFactory) { }
    }

    [TestClass]
    public class GenericRepoTests
    {
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private Mock<IDbContextFactory> _mockDbContextFactory;
        private IFixture _fixture;

        [TestInitialize]
        public void TestInitialize()
        {
            //_mockUnitOfWork = new Mock<IUnitOfWork>();
            //_mockDbContextFactory = new Mock<IDbContextFactory>();
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
            _mockUnitOfWork = _fixture.Freeze<Mock<IUnitOfWork>>();
            _mockDbContextFactory = _fixture.Freeze<Mock<IDbContextFactory>>();

        }

        [TestCleanup]
        public void TestCleanup()
        {
            _mockUnitOfWork.VerifyAll();
            _mockDbContextFactory.VerifyAll();
        }

        [TestMethod]
        public void GenericRepo_FindById_ExistingID_ObjectIsReturned()
        {
            var data = _fixture.CreateMany<TestEntity>().AsQueryable<TestEntity>();
            var mockSet = new Mock<DbSet<TestEntity>>();
            mockSet.As<IQueryable<TestEntity>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<TestEntity>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<TestEntity>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<TestEntity>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<DbContext>();
            mockContext.Setup(c => c.Set<TestEntity>()).Returns(mockSet.Object);

            _mockDbContextFactory.Setup(x => x.Create()).Returns(mockContext.Object);

            var sut = _fixture.Create<TestGenericRepo>();

            var expectedModel = data.ToList().FirstOrDefault();
            var actualModel = sut.FindById(expectedModel.Id);

            Assert.AreEqual(expectedModel.Id, actualModel.Id);
        }

        [TestMethod]
        public void GenericRepo_FindById_NonExistantId_NullIsReturned()
        {
            var data = _fixture.CreateMany<TestEntity>().AsQueryable<TestEntity>();
            var mockSet = new Mock<DbSet<TestEntity>>();
            mockSet.As<IQueryable<TestEntity>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<TestEntity>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<TestEntity>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<TestEntity>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<DbContext>();
            mockContext.Setup(c => c.Set<TestEntity>()).Returns(mockSet.Object);

            _mockDbContextFactory.Setup(x => x.Create()).Returns(mockContext.Object);

            var sut = _fixture.Create<TestGenericRepo>();

            var actualModel = sut.FindById(0);

            Assert.IsNull(actualModel);
        }
    }
}
