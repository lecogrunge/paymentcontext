using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
    [TestClass]
    public class DocumentTests
    {
        [TestMethod]
        public void ReturnErrorWhenCNPJIsInvalid()
        {
            Document doc = new Document("000", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Invalid);
        }

         [TestMethod]
        public void ReturnSuccessWhenCNPJIsvalid()
        {
            Document doc = new Document("00000000000000", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Valid);
        }

        // [TestMethod]
        // public void ShouldReturnErrorWhenCPFIsInvalid()
        // {
        //     Document doc = new Document("000", EDocumentType.CPF);
        //     Assert.IsTrue(doc.Invalid);
        // }

        //  [TestMethod]
        // public void ShouldReturnSuccessWhenCPFIsValid()
        // {
        //     Document doc = new Document("09319308632", EDocumentType.CPF);
        //     Assert.IsTrue(doc.Valid);
        // }
    }
}
