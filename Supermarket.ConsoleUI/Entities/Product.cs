namespace Supermarket.ConsoleUI.Entities
{
    /// <summary>
    /// Represents an item like Apples, Bananas, etc
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Unique identifier of the Product
        /// </summary>
        public string Barcode { get; set; }

        /// <summary>
        /// Product Description/Name
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Price for unit of Product
        /// </summary>
        public float PricePerUnit { get; set; }
    }
}