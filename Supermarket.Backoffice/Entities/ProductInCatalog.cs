using System.Collections.Generic;

namespace Supermarket.Backoffice.Entities
{
    /// <summary>
    /// Represents an item like Apples, Bananas, etc in the Catalog
    /// </summary>
    public class ProductInCatalog : ProductInfo
    {
        /// <summary>
        /// Quantity of this product that is in stock
        /// </summary>
        public int QuantityInStock { get; set; }

        /// <summary>
        /// Current Promotions (Ids) applicable to this product
        /// </summary>
        public List<string> PromotionsIds { get; set; }
    }
}