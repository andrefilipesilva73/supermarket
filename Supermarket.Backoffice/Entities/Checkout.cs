using System.Collections.Generic;

namespace Supermarket.Backoffice.Entities
{
    public class Checkout
    {
        /// <summary>
        /// Represents the list of products bought
        /// </summary>
        public Basket Basket { get; set; }

        /// <summary>
        /// Information About Promotions Applied
        /// </summary>
        public List<string> InformationAboutPromotionsApplied { get; set; }

        /// <summary>
        /// Total value of discounts applied
        /// </summary>
        public decimal TotalDiscountOfPromotionsApplied { get; set; }

        /// <summary>
        /// Total value to Pay by the client
        /// </summary>
        public decimal TotalToPay { get; set; }
    }
}