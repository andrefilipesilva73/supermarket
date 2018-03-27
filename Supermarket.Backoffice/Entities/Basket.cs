using System.Collections.Generic;

namespace Supermarket.Backoffice.Entities
{
    public class Basket
    {
        /// <summary>
        /// Represents the list of products bought
        /// </summary>
        public List<BasketLine> Lines { get; set; }

        public Basket()
        {
            this.Lines = new List<BasketLine>();
        }

        /// <summary>
        /// Sum all the prices of the Basket Lines
        /// </summary>
        /// <returns>Total to Pay for this Basket</returns>
        public decimal GetTotalToPay()
        {
            //Init result
            decimal result = 0;

            //Run all Lines
            foreach (BasketLine line in this.Lines)
            {
                //Add quantity x price per unit
                result += line.Quantity * line.Product.PricePerUnit;
            }

            //return calculation
            return result;
        }

        public BasketLine AddProduct(ProductInfo productInfo, decimal quantity)
        {
            //Search for existent BasketLine for this product
            foreach (BasketLine line in this.Lines)
            {
                //This line corresponds to the product?
                if (line.Product.Barcode == productInfo.Barcode)
                {
                    //Increase Quantity
                    line.Quantity += quantity;

                    //Return this line
                    return line;
                }
            }

            //Line was not found, so create a new BasketLine
            BasketLine newLine = new BasketLine()
            {
                Product = productInfo,
                Quantity = quantity
            };

            //Add it to this basket
            this.Lines.Add(newLine);

            //return created line
            return newLine;
        }
    }
}