using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;

namespace Acme.BizTests
{
    [TestClass]
    public class ProudctTest
    {
        [TestMethod]
        public void SayHellotest()
        {
            var currentProduct = new Product();
            currentProduct.ProductName = "Saw";
            currentProduct.ProductId = 1;
            currentProduct.Description = "12-inch steel";
            currentProduct.ProductVendor.CompanyName = "ABC Corp";
            var expected = "Hello Saw(1): 12-inch steel" + "Available on: ";
            var actual = currentProduct.SayHello();
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void SayHello_ParameterizedConstrucor()
        {
            var currentProduct = new Product(1,"Saw","12-inch steel");
            var expected = "Hello Saw(1): 12-inch steel" + "Available on: ";
            var actual = currentProduct.SayHello();
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void Product_Null()
        {
            Product currentProduct = null;
            var companyName = currentProduct?.ProductVendor?.CompanyName;
            string expected = null;
            var actual = companyName;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ConvertMetersToInchesTest()
        {
            var expected = 78.74;
            var actual = 2 * Product.InchesPerMeter;
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void MinimumPriceTest_Defult()
        {
            var currentProduct = new Product();
            var expected = .96m;
            var actual = currentProduct.MinimumPrice;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void MinimumPriceTest_Bulk()
        {
            var currentProduct = new Product(1, "Bulk Tools", "");
            var expected = 9.99m;
            var actual = currentProduct.MinimumPrice;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ProductName_Format()
        {
            var currentProduct = new Product();
            currentProduct.ProductName = " steel Hammer ";
            var expected = "steel Hammer";
            var actual = currentProduct.ProductName;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProductName_TooShort()
        {
            var currentProduct = new Product();
            currentProduct.ProductName = "aw";
            string expected = null;
            string expectedMessage = "Product Name must be at least 3 characters";
            var actual = currentProduct.ProductName;
            var actualMessage = currentProduct.ValidationMessage;
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedMessage, actualMessage);
        }
        [TestMethod]
        public void ProductName_TooLong()
        {
            var currentProduct = new Product();
            currentProduct.ProductName = "steel bladed hand saw";
            string expected = null;
            string expectedMessage = "Product Name cannot be more than 20 characters";
            var actual = currentProduct.ProductName;
            var actualMessage = currentProduct.ValidationMessage;
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedMessage, actualMessage);
        }
        [TestMethod]
        public void ProductName_JustRight()
        {
            var currentProduct = new Product();
            currentProduct.ProductName = "saw";
            string expected = "saw";
            string expectedMessage = null;
            var actual = currentProduct.ProductName;
            var actualMessage = currentProduct.ValidationMessage;
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedMessage, actualMessage);
        }
        [TestMethod]
        public void Sequenc_DefualtValue()
        {
            var currentProduct = new Product();
            var expected = 1;
            var actual = currentProduct.SequenceNumber;
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void Sequenc_NewValue()
        {
            var currentProduct = new Product();
            currentProduct.SequenceNumber = 5;
            var expected =5;
            var actual = currentProduct.SequenceNumber;
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void Category_DefualtValue()
        {
            var currentProduct = new Product();
            var expected = "Tool";
            var actual = currentProduct.Category;
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void Category_NewValue()
        {
            var currentProduct = new Product();
            currentProduct.Category = "Garden";
            var expected = "Garden";
            var actual = currentProduct.Category;
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void ProductCode()
        {
            var currnetProduct = new Product();
            currnetProduct.SequenceNumber = 55;
            currnetProduct.Category = "chicken";
            var expected = "chicken-00055";
            var actual = currnetProduct.ProductCode;
            Assert.AreEqual(expected, actual);

        }
    }
}
