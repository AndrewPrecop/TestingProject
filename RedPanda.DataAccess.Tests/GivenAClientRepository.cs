using Microsoft.VisualStudio.TestTools.UnitTesting;
using RedPanda.DataAccess.Context;
using RedPanda.DataAccess.Entities;
using RedPanda.DataAccess.Repository;
using System.Linq;

namespace RedPanda.DataAccess.Tests
{


    [TestClass]
    public class GivenAClientRepository
    {

        RedPandaContext context;
        ISaveRepository<Client> _sut;

        [TestInitialize]
        public void TestInit()
        {
            context = new RedPandaContext();
            _sut = new RedPandaSaveRepository<Client>(context);
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
            _sut.Add(new Client { Name = "Pop", Surname = "Andrew", Phone = 0744441111, Email = "pop.And@yahoo.com" });

            context.SaveChanges();

            //assert
            Assert.AreEqual(1, context.Clients.Where(x => x.Name == "Pop").ToList().Count());
        }

        [TestMethod]
        public void ItShouldSave()
        {
            //arrange
            var expectedCount = 1;

            //act
            context.Clients.Add(new Client { Name = "Pop", Surname = "Andrew", Phone = 0744441111, Email = "pop.And@yahoo.com" });

            _sut.SaveChanges();

            //assert
            Assert.AreEqual(expectedCount, context.Clients.Where(x => x.Name == "Pop").ToList().Count());
        }

        [TestMethod]
        public void ItShouldDelete()
        {
            //arrange
            var expectedCount = 0;
            var client = new Client { Name = "Pop" };

            //act
            context.Clients.Add(client);
            _sut.Delete(client);

            //assert
            Assert.AreEqual(expectedCount, context.Clients.Where(x => x.Name == "Pop").ToList().Count());
        }
    }

}

