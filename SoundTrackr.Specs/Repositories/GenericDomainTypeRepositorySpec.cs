using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoundTrackr.Common.UnitOfWork;
using Moq;
using SoundTrackr.Repository.Repositories;
using SoundTrackr.Common.Domain;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using SoundTrackr.Repository.Context;
using SoundTrackr.Repository.DatabaseModels;
using System.Data.Entity;
using Machine.Specifications;

namespace SoundTrackr.Specs.Repositories
{
    public class When_inserting_domain_entity : GenericDomainTypeRepositorySpec
    {
        Establish context = () =>
        {

        };

        Because of = () => sut.Insert(entity);

        Machine.Specifications.It should_add_the_entity_to_the_unit_of_work = () =>
        {

        };

        private static TestEntity entity;
    }

    public class GenericDomainTypeRepositorySpec : BaseRepoSpec
    {
        Establish context = () =>
        {
            sut = _fixture.Create<GenericDomainTypeRepository<TestEntity, TestEntityDb, int>>();
        };

        protected static GenericDomainTypeRepository<TestEntity, TestEntityDb, int> sut;
    }

    public class TestEntity : EntityBase<int>, IAggregateRoot 
    {
        protected override void Validate()
        {
        }
    }

    // TODO: Actually implement this
    public class TestEntityDb : GenericDb<int, TestEntity>, IAggregateRoot
    {
        public override TestEntity ConvertToDomain()
        {
            return new TestEntity();
        }
    }

    public class TestGenericRepo : GenericDomainTypeRepository<TestEntity, TestEntityDb, int> 
    {
        public TestGenericRepo(IUnitOfWork unitOfWork, IDbContextFactory dbContextFactory) : base(unitOfWork, dbContextFactory) { }

        // TODO: Implement a real test version of this
        public override TestEntity FindById(int id)
        {
            return new TestEntity();
        }
    }

    [TestClass]
    public class GenericDomainTypeRepositorySpec_Old
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
