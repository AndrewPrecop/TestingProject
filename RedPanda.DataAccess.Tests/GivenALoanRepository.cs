using Microsoft.VisualStudio.TestTools.UnitTesting;
using RedPanda.DataAccess.Context;
using RedPanda.DataAccess.Entities;
using RedPanda.DataAccess.Repository;
using System;
using System.Linq;

namespace RedPanda.DataAccess.Tests
{
    [TestClass]
    public class GivenALoanRepository
    {

        RedPandaContext context;
        ISaveRepository<Loan> _sut;

        [TestInitialize]
        public void TestInit()
        {
            context = new RedPandaContext();
            _sut = new RedPandaSaveRepository<Loan>(context);
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
            _sut.Add(new Loan {LoanDate=DateTime.Now,Tax=100,DelayPenalty=500 });

            context.SaveChanges();

            //assert
            Assert.AreEqual(1, context.Loans.Where(x => x.Tax == 100).ToList().Count());
        }

        [TestMethod]
        public void ItShouldSave()
        {
            //arrange
            var expectedCount = 1;

            //act
            context.Loans.Add(new Loan { LoanDate = DateTime.Now, Tax = 100, DelayPenalty = 500 });

            _sut.SaveChanges();

            //assert
            Assert.AreEqual(expectedCount, context.Loans.Where(x => x.Tax==100).ToList().Count());
        }

        [TestMethod]
        public void ItShouldDelete()
        {
            //arrange
            var expectedCount = 0;
            var loan = new Loan { Tax=100 };

            //act
            context.Loans.Add(loan);
            _sut.Delete(loan);

            //assert
            Assert.AreEqual(expectedCount, context.Loans.Where(x => x.Tax == 100).ToList().Count());
        }
    }
}
