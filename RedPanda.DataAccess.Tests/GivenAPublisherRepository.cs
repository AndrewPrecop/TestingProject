using Microsoft.VisualStudio.TestTools.UnitTesting;
using RedPanda.DataAccess.Context;
using RedPanda.DataAccess.Entities;
using RedPanda.DataAccess.Repository;
using System.Linq;

namespace RedPanda.DataAccess.Tests
{
    
        [TestClass]
        public class GivenAPublisherRepository
        {

            RedPandaContext context;
            ISaveRepository<Publisher> _sut;

            [TestInitialize]
            public void TestInit()
            {
                context = new RedPandaContext();
                _sut = new RedPandaSaveRepository<Publisher>(context);
                context.Database.BeginTransaction();
            }

            [TestCleanup]
            public void TestCleanup()
            {
                context.Database.CurrentTransaction.Rollback();
                context.Dispose();
            }

            [TestMethod]
            public void ItShouldAdd()
            {
                //arrange

                //act
                _sut.Add(new Publisher { Name = "Pop", Code = "00BV" });

                context.SaveChanges();

                //assert
                Assert.AreEqual(1, context.Publishers.Where(x => x.Code == "00BV").ToList().Count());
            }

            [TestMethod]
            public void ItShouldSave()
            {
                //arrange
                var expectedCount = 1;

                //act
                context.Publishers.Add(new Publisher { Name = "Pop", Code="00BV"});

                _sut.SaveChanges();

                //assert
                Assert.AreEqual(expectedCount, context.Publishers.Where(x => x.Code == "00BV").ToList().Count());
            }

            [TestMethod]
            public void ItShouldDelete()
            {
                //arrange
                var expectedCount = 0;
                var publisher = new Publisher { Name = "Pop" };

                //act
                context.Publishers.Add(publisher);
                _sut.Delete(publisher);

                //assert
                Assert.AreEqual(expectedCount, context.Publishers.Where(x => x.Code == "00BV").ToList().Count());
            }
        }

    
}
