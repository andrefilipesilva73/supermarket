using Microsoft.VisualStudio.TestTools.UnitTesting;
using Supermarket.Backoffice.Controllers;
using Supermarket.Backoffice.Entities;

namespace Supermarket.UnitTests.TestClasses
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void GetAppleProductInfo()
        {
            //Get Info
            ProductInfo productInfo = CatalogController.GetProductByBarcode("Apple");

            //Assert Info
            Assert.AreEqual("Apple", productInfo.Barcode);
            Assert.AreEqual((decimal)0.25, productInfo.PricePerUnit);
        }

        [TestMethod]
        public void GetOrangeProductInfo()
        {
            //Get Info
            ProductInfo productInfo = CatalogController.GetProductByBarcode("Orange");

            //Assert Info
            Assert.AreEqual("Orange", productInfo.Barcode);
            Assert.AreEqual((decimal)0.30, productInfo.PricePerUnit);
        }

        [TestMethod]
        public void GetBananaProductInfo()
        {
            //Get Info
            ProductInfo productInfo = CatalogController.GetProductByBarcode("Banana");

            //Assert Info
            Assert.AreEqual("Banana", productInfo.Barcode);
            Assert.AreEqual((decimal)0.15, productInfo.PricePerUnit);
        }

        [TestMethod]
        public void GetPapayaProductInfo()
        {
            //Get Info
            ProductInfo productInfo = CatalogController.GetProductByBarcode("Papaya");

            //Assert Info
            Assert.AreEqual("Papaya", productInfo.Barcode);
            Assert.AreEqual((decimal)0.50, productInfo.PricePerUnit);
        }
    }
}