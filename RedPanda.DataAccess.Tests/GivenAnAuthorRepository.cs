using Microsoft.VisualStudio.TestTools.UnitTesting;
using RedPanda.DataAccess.Context;
using RedPanda.DataAccess.Entities;
using RedPanda.DataAccess.Repository;
using System.Linq;

namespace RedPanda.DataAccess.Tests
{
    class GivenAnAuthorRepository
    {

        RedPandaContext context;
        ISaveRepository<Author> _sut;

        [TestInitialize]
        public void TestInit()
        {
            context = new RedPandaContext();
            _sut = new RedPandaSaveRepository<Author>(context);
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
            _sut.Add(new Author { Name = "Pop" });

            context.SaveChanges();

            //assert
            Assert.AreEqual(1, context.Authors.Where(x => x.Name == "Pop").ToList().Count());
        }

        [TestMethod]
        public void ItShouldSave()
        {
            //arrange
            var expectedCount = 1;

            //act
            context.Authors.Add(new Author { Name = "Pop" });

            _sut.SaveChanges();

            //assert
            Assert.AreEqual(expectedCount, context.Authors.Where(x => x.Name == "Pop").ToList().Count());
        }

        [TestMethod]
        public void ItShouldDelete()
        {
            //arrange
            var expectedCount = 0;
            var author = new Author { Name = "Pop" };

            //act
            context.Authors.Add(author);
            _sut.Delete(author);

            //assert
            Assert.AreEqual(expectedCount, context.Authors.Where(x => x.Name == "Pop").ToList().Count());
        }
    }



}
