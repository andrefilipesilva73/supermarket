using System.Collections.Generic;
using System.Linq;

namespace Supermarket.Backoffice.Entities
{
    /// <summary>
    /// Represents the list of products available in a Supermarket location
    /// </summary>
    public class Catalog
    {
        /// <summary>
        /// Represents the list of products available
        /// </summary>
        public List<ProductInCatalog> Products { get; set; }

        /// <summary>
        /// Represents the list of Promotions available
        /// </summary>
        public List<Promotion> Promotions { get; set; }

        /// <summary>
        /// Search for a Product Information by Barcode
        /// (Simulates an Database Access)
        /// </summary>
        /// <param name="productBarcode">Product Barcode to Look for</param>
        /// <returns>Product Info found for the barcode</returns>
        public ProductInfo GetProductInfoByBarcode(string productBarcode)
        {
            //Search and remove catalog information by Cast to Parent Class
            return this.GetProductInCatalogByBarcode(productBarcode);
        }

        /// <summary>
        /// Search for a Product In Catalog by Barcode
        /// (Simulates an Database Access)
        /// </summary>
        /// <param name="productBarcode">Product Barcode to Look for</param>
        /// <returns>Product Info found for the barcode</returns>
        public ProductInCatalog GetProductInCatalogByBarcode(string productBarcode)
        {
            //Build a Lookup by Barcode
            var lookup = this.Products.ToLookup(nd => nd.Barcode.ToLowerInvariant());

            //Search on created Lookup
            return lookup[productBarcode.ToLowerInvariant()].FirstOrDefault();
        }

        /// <summary>
        /// Search for a Promotion In Catalog by Id
        /// (Simulates an Database Access)
        /// </summary>
        /// <param name="promotionId">Promotion to Look for</param>
        /// <returns>Promotion in Catalog</returns>
        public Promotion GetPromotionById(string promotionId)
        {
            //Build a Lookup by Id
            var lookup = this.Promotions.ToLookup(nd => nd.Id);

            //Search on created Lookup
            return lookup[promotionId].FirstOrDefault();
        }
    }
}