using Microsoft.VisualStudio.TestTools.UnitTesting;
using RedPanda.DataAccess.Context;
using RedPanda.DataAccess.Entities;
using System.Linq;

namespace RedPanda.DataAccess.Tests {

    [TestClass]
    public class GivenARedPandaContext {

        RedPandaContext sut;

        [TestInitialize]
        public void TestInit() {
            sut = new RedPandaContext();
            sut.Database.BeginTransaction();
        }

        [TestCleanup]
        public void TestCleanup() {
            sut.Database.CurrentTransaction.Rollback();
            sut.Dispose();
        }

        [TestMethod]
        public void ITShouldSave() {
            //arrange

            //act
            sut.Books.Add(new Book { Title = "Ion" });
            sut.SaveChanges();

            //assert
            Assert.AreEqual(sut.Books.Where(x => x.Title == "Ion").ToList().Count(), 1);
        }
    }
}
