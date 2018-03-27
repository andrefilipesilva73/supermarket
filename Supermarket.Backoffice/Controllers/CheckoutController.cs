using Supermarket.Backoffice.Entities;
using Supermarket.Backoffice.Managers;

namespace Supermarket.Backoffice.Controllers
{
    /// <summary>
    /// Simulates an API for Checkout Services
    /// </summary>
    public class CheckoutController
    {
        /// <summary>
        /// Calculates the total price and applicable promotions
        /// </summary>
        /// <param name="basket">Basket of Products bought by the client</param>
        /// <returns>Checkout information</returns>
        public static Checkout CreateCheckout(Basket basket)
        {
            //Get Catalog
            Catalog currentCatalog = CatalogManager.GetCurrentCatalog();

            //Create Checkout
            Checkout checkout = CheckoutManager.CreateCheckout(currentCatalog, basket);

            //Return Created Checkout
            return checkout;
        }
    }
}