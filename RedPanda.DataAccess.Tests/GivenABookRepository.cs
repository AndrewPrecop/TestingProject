using Microsoft.VisualStudio.TestTools.UnitTesting;
using RedPanda.DataAccess.Context;
using RedPanda.DataAccess.Entities;
using RedPanda.DataAccess.Repository;
using System.Linq;

namespace RedPanda.DataAccess.Tests {

    [TestClass]
    public class GivenABookRepository {

        RedPandaContext context;
        ISaveRepository<Book> _sut;

        [TestInitialize]
        public void TestInit() {
            context = new RedPandaContext();
            _sut = new RedPandaSaveRepository<Book>(context);
            context.Database.BeginTransaction();
        }

        [TestCleanup]
        public void TestCleanup() {
            context.Database.CurrentTransaction.Rollback();
            context.Dispose();
        }

        [TestMethod]
        public void ItShouldAdd() {
            //arrange

            //act
            _sut.Add(new Book { Title = "1984" });

            context.SaveChanges();

            //assert
            Assert.AreEqual(1, context.Books.Where(x => x.Title == "1984").ToList().Count());
        }

        [TestMethod]
        public void ItShouldSave() {
            //arrange
            var expectedCount = 1;

            //act
            context.Books.Add(new Book { Title = "1984" });

            _sut.SaveChanges();

            //assert
            Assert.AreEqual(expectedCount, context.Books.Where(x => x.Title == "1984").ToList().Count());
        }

        [TestMethod]
        public void ItShouldDelete()
        {
            //arrange
            var expectedCount = 0;
            var book = new Book { Title = "1984" };

            //act
            context.Books.Add(book);
            _sut.Delete(book);

            //assert
            Assert.AreEqual(expectedCount, context.Books.Where(x => x.Title == "1984").ToList().Count());
        }
    }
}
