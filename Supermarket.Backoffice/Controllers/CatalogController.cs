using Supermarket.Backoffice.Entities;
using Supermarket.Backoffice.Managers;

namespace Supermarket.Backoffice.Controllers
{
    /// <summary>
    /// Simulates an API for Catalog Services
    /// </summary>
    public class CatalogController
    {
        /// <summary>
        /// Gets a product information by barcode
        /// </summary>
        /// <param name="productBarcode">Barcode of the Product to look for</param>
        /// <returns>Product Information found</returns>
        public static ProductInfo GetProductByBarcode(string productBarcode)
        {
            //Get Catalog
            Catalog currentCatalog = CatalogManager.GetCurrentCatalog();

            //Get Product from Catalog
            ProductInfo product = currentCatalog.GetProductInfoByBarcode(productBarcode);

            //Return product found
            return product;
        }
    }
}