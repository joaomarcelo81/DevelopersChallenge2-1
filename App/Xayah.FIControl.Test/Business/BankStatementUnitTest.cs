using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xayah.FIControl.DataContext;
using Xayah.FIControl.Domain.Domain.Interfaces.Repositories;
using Xayah.FIControl.Domain.Enitties;

namespace Xayah.FIControl.Test.Business
{
    public class BankStatementUnitTest
    {

        public TestContext TestContext { get; set; }

        /// <summary>
        /// Our Mock BankStatements Repository for use in testing
        /// </summary>
        public IBankStatementRepository MockBankStatementsRepository;

        private Guid BankStatmentId { get; set; }


        [SetUp]
        public void Setup()
        {

            Mock<IBankStatementRepository> _mockBankStatementRepository;
            Mock<XayahFIControlDataContext> mockContext;


            BankStatmentId = Guid.NewGuid();
            var listBank = new List<BankStatement>() {
            new BankStatement() { BankStatementId = BankStatmentId, Acctid = "1" },
            new BankStatement() { BankStatementId = Guid.NewGuid(), Acctid = "1" },
            new BankStatement() { BankStatementId = Guid.NewGuid(), Acctid = "1" }
            };

            _mockBankStatementRepository = new Mock<IBankStatementRepository>();
            mockContext = new Mock<XayahFIControlDataContext>();
            _mockBankStatementRepository.Setup(x => x.GetAll()).Returns(listBank);
            _mockBankStatementRepository.Setup(x => x.Get(
              It.IsAny<Guid>())).Returns((Guid i) => listBank.Where(
              x => x.BankStatementId == i).Single());

            this.MockBankStatementsRepository = _mockBankStatementRepository.Object;
        }

        [Test]
        public void CanBankStatementGetAll()
        {
            var ret = this.MockBankStatementsRepository.GetAll();

            Assert.IsTrue(ret.Count() > 0);

        }
        [Test]
        public void CanBankStatementGetById()
        {
            var ret = this.MockBankStatementsRepository.Get(BankStatmentId);

            Assert.IsNotNull(ret);
        }
    }
}
