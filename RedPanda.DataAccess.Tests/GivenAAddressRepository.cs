using Microsoft.VisualStudio.TestTools.UnitTesting;
using RedPanda.DataAccess.Context;
using RedPanda.DataAccess.Entities;
using RedPanda.DataAccess.Repository;
using System.Linq;

namespace RedPanda.DataAccess.Tests
{
    class GivenAAddressRepository
    {

        [TestClass]
        public class GivenAAdressRepository
        {

            RedPandaContext context;
            ISaveRepository<Address> _sut;

            [TestInitialize]
            public void TestInit()
            {
                context = new RedPandaContext();
                _sut = new RedPandaSaveRepository<Address>(context);
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
                _sut.Add(new Address { City = "Iasi",Street="Strada porumbeilor",PostalCode="720214" });

                context.SaveChanges();

                //assert
                Assert.AreEqual(1, context.Addresses.Where(x => x.City == "Iasi").ToList().Count());
            }

            [TestMethod]
            public void ItShouldSave()
            {
                //arrange
                var expectedCount = 1;

                //act
                context.Addresses.Add(new Address { City = "Iasi", Street = "Strada porumbeilor", PostalCode = "720214" });

                _sut.SaveChanges();

                //assert
                Assert.AreEqual(expectedCount, context.Addresses.Where(x => x.City == "Iasi").ToList().Count());
            }

            [TestMethod]
            public void ItShouldDelete()
            {
                //arrange
                var expectedCount = 0;
                var adress = new Address { City = "Iasi" };

                //act
                context.Addresses.Add(adress);
                _sut.Delete(adress);

                //assert
                Assert.AreEqual(expectedCount, context.Addresses.Where(x => x.City == "Iasi").ToList().Count());
            }
        }

    }
}
