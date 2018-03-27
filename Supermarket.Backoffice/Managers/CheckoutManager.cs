using System;
using System.Collections.Generic;
using Supermarket.Backoffice.Entities;
using Supermarket.Backoffice.Promotions;

namespace Supermarket.Backoffice.Managers
{
    public class CheckoutManager
    {
        /// <summary>
        /// Calculates the total price and applicable promotions
        /// </summary>
        /// <param name="currentCatalog">Current Catalog in Use</param>
        /// <param name="basket">Basket of Products bought by the client</param>
        /// <returns>Checkout information</returns>
        public static Checkout CreateCheckout(Catalog currentCatalog, Basket basket)
        {
            //Create Checkout
            Checkout result = new Checkout()
            {
                Basket = basket,
                InformationAboutPromotionsApplied = new List<string>()
            };

            //Calculate Promotions to Apply
            CalculateDiscounts(result, currentCatalog, basket);

            //Update TotalToPay
            result.TotalToPay = result.Basket.GetTotalToPay() - result.TotalDiscountOfPromotionsApplied;

            //return created checkout
            return result;
        }

        /// <summary>
        /// Calculate Discounts for a Basket of a Checkout
        /// </summary>
        /// <param name="result">Created Checkout</param>
        /// <param name="currentCatalog">Current Catalog in Use</param>
        /// <param name="basket">Basket of Products bought by the client</param>
        private static void CalculateDiscounts(Checkout result, Catalog currentCatalog, Basket basket)
        {
            //For each Product in Basket
            foreach (BasketLine basketLine in basket.Lines)
            {
                //Get Product from catalog
                ProductInCatalog productInCatalog = currentCatalog.GetProductInCatalogByBarcode(basketLine.Product.Barcode);

                //Calculate Applicable Promotions (promotionId, discount applied)
                Dictionary<Promotion, decimal> applicablePromotions = CalculateApplicablePromotions(productInCatalog, currentCatalog, basket);

                //Pick best discount only
                Promotion bestDiscountPromotion = null;
                decimal bestDiscount = 0;

                //Run All applicablePromotions
                foreach (Promotion promotion in applicablePromotions.Keys)
                {
                    //Test if it's the best promotion or not
                    if (applicablePromotions[promotion] > bestDiscount)
                    {
                        //It is, update best discount
                        bestDiscount = applicablePromotions[promotion];

                        //Update Best discount Promotion
                        bestDiscountPromotion = promotion;
                    }
                }

                //If A discount was found
                if (bestDiscountPromotion != null)
                {
                    //Apply discount
                    result.TotalDiscountOfPromotionsApplied += bestDiscount;

                    //Inform user
                    result.InformationAboutPromotionsApplied.Add(string.Format("{0} | {1} | {2}", productInCatalog.Description, bestDiscountPromotion.Description, bestDiscount));
                }
            }
        }

        /// <summary>
        /// Calculate Applicable Promotions
        /// </summary>
        /// <param name="productInCatalog">Product to verify Promotions</param>
        /// <param name="currentCatalog">Current Catalog in Use</param>
        /// <param name="basket">Basket of Products bought by the client</param>
        /// <returns>Promotions Applied and Discount for each one</returns>
        private static Dictionary<Promotion, decimal> CalculateApplicablePromotions(ProductInCatalog productInCatalog, Catalog currentCatalog, Basket basket)
        {
            //Create result
            Dictionary<Promotion, decimal> applicablePromotions = new Dictionary<Promotion, decimal>();

            //The product has any promotion?
            if (productInCatalog.PromotionsIds != null)
            {
                //For each Promotion of the Product
                foreach (string promotionId in productInCatalog.PromotionsIds)
                {
                    //Get Promotion from Catalog
                    Promotion promotion = currentCatalog.GetPromotionById(promotionId);

                    //Get Promotion Strategy Type Name
                    string typeName = String.Format("Supermarket.Backoffice.Promotions.{0}PromotionStrategy", promotionId);

                    //Invoke Strategy
                    PromotionStrategy promotionStrategy = (PromotionStrategy)Activator.CreateInstance(Type.GetType(typeName));

                    //Calculate Discount
                    decimal discount = promotionStrategy.CalculateDiscount(productInCatalog, basket);

                    //Add value to applicablePromotions
                    applicablePromotions.Add(promotion, discount);
                }
            }

            //return result
            return applicablePromotions;
        }
    }
}