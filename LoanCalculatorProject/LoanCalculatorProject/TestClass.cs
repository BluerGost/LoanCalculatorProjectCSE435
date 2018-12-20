using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LoanCalculatorProject
{
    [TestFixture]
    public class TestClass
    {
        //Deposit Page Tests
        WebForm1 objDeposit = new WebForm1();

        [Test]
        public void TestDepositEmpty()
        {
            Assert.AreEqual("Balance or Deposit Amount Can't Be Empty", objDeposit.save("100",""));
        }

        [Test]
        public void TestDepositNegative()
        {
            Assert.AreEqual("Balance or Deposit Amount Can't Be Negative", objDeposit.save("10000", "-500"));
        }

        [Test]
        public void TestDepositValid()
        {
            Assert.AreEqual("1100", objDeposit.save("1000", "100"));
        }

        //Transfer Page Tests
        WebForm2 objTran = new WebForm2();

        [Test]
        public void TestTransferEmpty()
        {
            Assert.AreEqual("Balance or Transfer Amount Can't Be Empty", objTran.save("100", ""));
        }

        [Test]
        public void TestTransferNegative()
        {
            Assert.AreEqual("Balance or Transfer Amount Can't Be Negative", objTran.save("-1000", "-100"));
        }

        [Test]
        public void TestTransferNotEnoughBalance()
        {
            Assert.AreEqual("Not Enough Balance", objTran.save("100", "500"));
        }
        [Test]
        public void TestTransferValid()
        {
            Assert.AreEqual("900", objTran.save("1000", "100"));
        }


        //Interest Page Tests
        WebForm4 objInt = new WebForm4();

        [Test]
        public void TestInterestEmpty()
        {
            Assert.AreEqual("Loan Amount or Installment Number or Interest Rate Can't Be Empty", objInt.save("1000", "",""));
        }

        [Test]
        public void TestInterestNegative()
        {
            Assert.AreEqual("Loan Amount or Installment Number or Interest Rate Can't Be Negative", objInt.save("-10", "-100","-500"));
        }
     
        [Test]
        public void TestInterestValid()
        {
            Assert.AreEqual("750", objInt.save("500", "30","5"));
        }


        //Loan Page Tests
        WebForm3 objLoan = new WebForm3();

        [Test]
        public void TestLoanEmpty()
        {
            Assert.AreEqual("Loan Amount or Payment Per Installment Can't Be Empty", objLoan.save("", "1000"));
        }

        [Test]
        public void TestLoanNegative()
        {
            Assert.AreEqual("Loan Amount or Payment Per Installment Can't Be Negative or Zero", objLoan.save("-1000", "-100"));
        }
        public void TestLoanZero()
        {
            Assert.AreEqual("Loan Amount or Payment Per Installment Can't Be Negative or Zero", objLoan.save("1000", "0"));
        }

        //Loan Amount Should be Bigger than Installment Payment Check.
        public void TestLoanAmountMustBeGreater()
        {
            Assert.AreEqual("Loan Amount Must Be  More than Per Installment Payment Amount", objLoan.save("1000", "1500"));
        }
        [Test]
        public void TestLoanValid()
        {
            Assert.AreEqual("1034", objLoan.save("15510", "15"));
        }
    }
}