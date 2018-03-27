using System;
using System.Collections.Generic;

namespace Supermarket.ConsoleUI.Entities
{
    /// <summary>
    /// Represents the list of Products that the client wants to buy in a checkout
    /// </summary>
    public class Basket
    {
        /// <summary>
        /// List of Products to buy
        /// </summary>
        public List<Product> ProductsToBuy { get; set; }

        /// <summary>
        /// Moment when the shopping started for promotions reference
        /// </summary>
        public DateTime CreationDateTime { get; set; }
    }
}