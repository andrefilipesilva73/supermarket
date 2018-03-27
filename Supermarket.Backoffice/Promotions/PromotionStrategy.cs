using Supermarket.Backoffice.Entities;

namespace Supermarket.Backoffice.Promotions
{
    public interface PromotionStrategy
    {
        decimal CalculateDiscount(ProductInCatalog product, Basket basket);
    }
}