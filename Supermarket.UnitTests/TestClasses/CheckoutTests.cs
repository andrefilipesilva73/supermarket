using Microsoft.VisualStudio.TestTools.UnitTesting;
using Supermarket.Backoffice.Controllers;
using Supermarket.Backoffice.Entities;

namespace Supermarket.UnitTests.TestClasses
{
    [TestClass]
    public class CheckoutTests
    {
        [TestMethod]
        public void CheckoutBananas()
        {
            //Init basket
            Basket basket = new Basket();

            //Get Info
            ProductInfo bananasProductInfo = CatalogController.GetProductByBarcode("Banana");

            //Quantity
            int quantity = 3;

            //Add Bananas
            basket.AddProduct(bananasProductInfo, quantity);

            //Checkout
            Checkout checkout = CheckoutController.CreateCheckout(basket);

            //Assert Number of Lines
            Assert.AreEqual(1, basket.Lines.Count);

            //Assert No discount expected
            Assert.AreEqual(0, checkout.TotalDiscountOfPromotionsApplied);

            //Assert expected to pay for the quantity of bananas
            Assert.AreEqual((decimal)(quantity * bananasProductInfo.PricePerUnit), checkout.TotalToPay);
        }

        [TestMethod]
        public void CheckoutPapayas()
        {
            //Init basket
            Basket basket = new Basket();

            //Get Info
            ProductInfo papayasProductInfo = CatalogController.GetProductByBarcode("Papaya");

            //Quantity
            int quantity = 6;

            //Add Papayas
            basket.AddProduct(papayasProductInfo, quantity);

            //Checkout
            Checkout checkout = CheckoutController.CreateCheckout(basket);

            //Expected Offer
            int offer = quantity - 4;

            //Assert Number of Lines
            Assert.AreEqual(1, basket.Lines.Count);

            //Assert expected discount
            Assert.AreEqual(offer * papayasProductInfo.PricePerUnit, checkout.TotalDiscountOfPromotionsApplied);

            //Assert expected to pay for the quantity of papayas
            Assert.AreEqual((decimal)((quantity - offer) * papayasProductInfo.PricePerUnit), checkout.TotalToPay);
        }

        [TestMethod]
        public void SimulateExercise()
        {
            //Init basket
            Basket basket = new Basket();

            //Create list of barcodes
            string[] barcodes = new string[]
            {
                "Apple",
                "Apple",
                "Orange",
                "Apple",
                "Papaya",
                "Banana",
                "Papaya",
                "Papaya"
            };

            //Run each barcode
            foreach (string barcode in barcodes)
            {
                //Get Product
                ProductInfo productInfo = CatalogController.GetProductByBarcode(barcode);

                //Add to the basket
                basket.AddProduct(productInfo, 1);
            }

            //Checkout
            Checkout checkout = CheckoutController.CreateCheckout(basket);

            //Assert expected discount of the papayas
            Assert.AreEqual((decimal)0.50, checkout.TotalDiscountOfPromotionsApplied);

            //Assert expected to pay
            Assert.AreEqual((decimal)2.20, checkout.TotalToPay);
        }
    }
}