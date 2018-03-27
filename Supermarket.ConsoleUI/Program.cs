using System;
using Supermarket.Backoffice.Controllers;
using Supermarket.Backoffice.Entities;

namespace Supermarket.ConsoleUI
{
    public class Program
    {
        private static Basket CurrentBasket { get; set; }

        private static Checkout CurrentCheckout { get; set; }

        public static void Main(string[] args)
        {
            //Run new Basket
            NewBasket();
        }

        private static void NewBasket()
        {
            //Init Basket
            CurrentBasket = new Basket();

            //Clear Console
            Console.Clear();

            //Write Presention
            WritePresentation();

            //Write Add To Basket Instructions
            WriteAddToBasketInstructions();

            //Run Add to Basket
            RunAddToBasket();
        }

        private static void WritePresentation()
        {
            Console.WriteLine("-----SUPERMARKET-----");
            Console.WriteLine("   By André Filipe Silva");
            Console.WriteLine("----------------------------");
        }

        private static void WriteAddToBasketInstructions()
        {
            Console.WriteLine("Please insert:");
            Console.WriteLine(" -> The barcode (product name) to add a product to the basket");
            Console.WriteLine(" -> 'checkout' to checkout your products");
            Console.WriteLine(" -> 'exit' to terminate");
            Console.WriteLine("----------------------------");
        }

        private static void WriteCheckoutInstructions()
        {
            Console.WriteLine("Please insert:");
            Console.WriteLine(" -> 'new' to create a new Basket");
            Console.WriteLine(" -> 'exit' to terminate");
            Console.WriteLine("----------------------------");
        }

        private static void RunAddToBasket()
        {
            //Init current command
            string currentCommand = Console.ReadLine().Trim();

            //While the user does not exit the program
            while (currentCommand != "exit")
            {
                //Checkout?
                if (currentCommand == "checkout")
                {
                    //Go to Checkout
                    bool wentToCheckout = CheckoutBasket();

                    //Check If user went to Checkout
                    if (wentToCheckout)
                    {
                        //Break cycle
                        break;
                    }
                }
                else
                {
                    //Try to get the product by barcode
                    ReadBarcode(currentCommand);
                }

                //Read Next Line
                currentCommand = Console.ReadLine().Trim();
            }
        }

        private static void ReadBarcode(string barcode)
        {
            //Get a Product
            ProductInfo product = CatalogController.GetProductByBarcode(barcode);

            //Eval is it is a valid barcode
            if (product != null)
            {
                //Product is valid, add it to the basket
                CurrentBasket.AddProduct(product, 1);

                //Inform user (the bip on the machine)
                Console.Beep();
            }
            else
            {
                //Product was not found
                Console.WriteLine(string.Format("Product with barcode '{0}' not found", barcode));
            }
        }

        private static bool CheckoutBasket()
        {
            //If there is something to checkout
            if (CurrentBasket.Lines.Count != 0)
            {
                //Create Checkout
                CurrentCheckout = CheckoutController.CreateCheckout(CurrentBasket);

                //Print
                PrintCurrentCheckout();

                //Stop Execution
                return true;
            }
            else
            {
                //There is nothing to checkout, tell to the user
                Console.WriteLine("There is nothing to Checkout. Please add a Product to the Basket");

                //Continue execution
                return false;
            }
        }

        private static void PrintCurrentCheckout()
        {
            //Clear Console
            Console.Clear();

            //Write Presention
            WritePresentation();

            //Write Instructions
            WriteCheckoutInstructions();

            //Print Basket
            Console.WriteLine("Products:");
            foreach (BasketLine line in CurrentCheckout.Basket.Lines)
            {
                Console.WriteLine(string.Format("{0} | Quantity: {1} x {2} = {3}", line.Product.Description, line.Quantity, line.Product.PricePerUnit, line.Quantity * line.Product.PricePerUnit));
            }
            Console.WriteLine();

            //Print Promotions
            if (CurrentCheckout.InformationAboutPromotionsApplied != null && CurrentCheckout.InformationAboutPromotionsApplied.Count > 0)
            {
                Console.WriteLine("Promotions:");

                foreach (string info in CurrentCheckout.InformationAboutPromotionsApplied)
                {
                    Console.WriteLine(info);
                }

                Console.WriteLine();
            }

            //Print Total discount
            Console.WriteLine(string.Format("Total Discount: {0}", CurrentCheckout.TotalDiscountOfPromotionsApplied));
            Console.WriteLine();

            //Print Total to Pay
            Console.WriteLine(string.Format("Total To Pay: {0}", CurrentCheckout.TotalToPay));
            Console.WriteLine();

            //Read User command
            string command = Console.ReadLine().Trim();

            //Eval command
            if (command == "new")
            {
                //Run new Basket
                NewBasket();
            }
            //else let execution terminate
        }
    }
}