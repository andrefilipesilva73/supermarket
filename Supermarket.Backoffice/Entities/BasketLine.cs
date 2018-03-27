namespace Supermarket.Backoffice.Entities
{
    public class BasketLine
    {
        /// <summary>
        /// Product of this Line
        /// </summary>
        public ProductInfo Product { get; set; }

        /// <summary>
        /// Quantity added by the client
        /// It can be int or decimal, depending of the nature of the product
        /// </summary>
        public decimal Quantity { get; set; }
    }
}