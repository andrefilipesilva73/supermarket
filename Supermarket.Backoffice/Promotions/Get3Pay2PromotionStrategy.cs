using System;
using Supermarket.Backoffice.Entities;

namespace Supermarket.Backoffice.Promotions
{
    public class Get3Pay2PromotionStrategy : PromotionStrategy
    {
        public decimal CalculateDiscount(ProductInCatalog product, Basket basket)
        {
            //Search product on basket
            foreach (BasketLine line in basket.Lines)
            {
                //If it is the product
                if (product.Barcode == line.Product.Barcode)
                {
                    //Calculate total offers
                    int totalOffers = (int)Math.Floor(line.Quantity / 3);

                    //Calculate and return discount
                    return totalOffers * product.PricePerUnit;
                }
            }

            //Not expected to reach this line
            throw new Exception(string.Format("Calculate Discount failed to Product Barcode {0}", product.Barcode));
        }
    }
}