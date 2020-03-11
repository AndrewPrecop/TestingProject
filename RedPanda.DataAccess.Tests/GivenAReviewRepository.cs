using Microsoft.VisualStudio.TestTools.UnitTesting;
using RedPanda.DataAccess.Context;
using RedPanda.DataAccess.Entities;
using RedPanda.DataAccess.Repository;
using System.Linq;

namespace RedPanda.DataAccess.Tests
{
    [TestClass]
    public class GivenAReviewRepository
    {

        RedPandaContext context;
        ISaveRepository<Review> _sut;

        [TestInitialize]
        public void TestInit()
        {
            context = new RedPandaContext();
            _sut = new RedPandaSaveRepository<Review>(context);
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
            _sut.Add(new Review { Rating = 500, Comment = "good" });

            context.SaveChanges();

            //assert
            Assert.AreEqual(1, context.Reviews.Where(x => x.Rating == 500).ToList().Count());
        }

        [TestMethod]
        public void ItShouldSave()
        {
            //arrange
            var expectedCount = 1;

            //act
            context.Reviews.Add(new Review { Rating = 500, Comment = "good" });

            _sut.SaveChanges();

            //assert
            Assert.AreEqual(expectedCount, context.Reviews.Where(x => x.Rating == 500).ToList().Count());
        }

        [TestMethod]
        public void ItShouldDelete()
        {
            //arrange
            var expectedCount = 0;
            var review = new Review { Rating = 500 };

            //act
            context.Reviews.Add(review);
            _sut.Delete(review);

            //assert
            Assert.AreEqual(expectedCount, context.Reviews.Where(x => x.Rating == 500).ToList().Count());
        }


    }
    }
