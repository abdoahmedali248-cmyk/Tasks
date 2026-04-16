namespace ShoppingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System_product.HandleMenu();


        }

        enum Option
        {

            AddProduct = 1,
            ViewCart = 2,
            RemoveItem = 3,
            Checkout = 4,
            Undo = 5,
            Exit = 6
        }
        class Product
        {

            public static List<string> itemcart = new List<string>();
            public static Dictionary<string, double> products = new Dictionary<string, double>((StringComparer.OrdinalIgnoreCase))

{
    { "Samsung Phone", 8500 },
    { "Bluetooth Headset", 450 },
    { "Power Bank", 600 },
    { "HP Laptop", 23500 },
    { "Wireless Mouse", 250 },
    { "Mechanical Keyboard", 900 },
    { "24 Inch Monitor", 4200 },
    { "Smart Watch", 1200 },
    { "64GB Flash Drive", 300 },
    { "WiFi Router", 1500 }
};
            public static Stack<string> Actions = new Stack<string>();

        }


        class System_product
        {


            private static void ShowMenu()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("===== SHOPPING MENU =====");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. View Cart");
                Console.WriteLine("3. Remove Item");
                Console.WriteLine("4. Checkout");
                Console.WriteLine("5. Undo");
                Console.WriteLine("6. Exit");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Choose option: ");
                Console.ResetColor();
            }


            public static void HandleMenu()
            {

                while (true)
                {
                    ShowMenu();

                    Console.WriteLine("Please enter a number 1 t0 6");

                    // int choice = int.Parse(Console.ReadLine());

                    string input = Console.ReadLine();
                    if (!int.TryParse(input, out int choice))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input! Please enter a number.");
                        Console.ResetColor();
                        continue;
                    }
                    if (choice > 0 && choice <= 6)
                    {
                        Option option = (Option)choice;

                        switch (option)
                        {
                            case Option.AddProduct:
                                AddProduct();
                                break;

                            case Option.ViewCart:
                                VeiwCartItem();
                                break;

                            case Option.RemoveItem:
                                RemoveItem();
                                break;

                            case Option.Checkout:
                                Checkout();
                                break;
                            case Option.Undo:
                                Undoaction();
                                break;
                            case Option.Exit:
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Goodbye ");
                                Console.ResetColor();
                                return;
                            default:
                                Console.WriteLine("Invalid choice");
                                break;
                        }
                    }
                    else
                    {
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Please enter a number between 1 and 6!");
                            Console.ResetColor();
                        }
                    }
                }
            }

            private static void AddProduct()
            {
                Console.WriteLine("Avalible items");
                foreach (var item in Product.products)
                {
                    Console.WriteLine($"item: {item.Key} price: {item.Value} EGP");
                }

                Console.WriteLine("please enter product name");
                string itemcart = Console.ReadLine().Trim();

                if (Product.products.ContainsKey(itemcart))
                {
                    Product.itemcart.Add(itemcart);
                    Product.Actions.Push("ADD|" + itemcart);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"item {itemcart} is added in cart");
                    Console.ResetColor();

                }
                else
                {
                    Console.WriteLine("item is out of stock )");
                }
            }

            private static void VeiwCartItem()
            {

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("item in cart is : ");
                Console.ResetColor();

                if (Product.itemcart.Any())
                {
                    var ItemPriceCollection = GetCartPrice();
                    foreach (var item in ItemPriceCollection)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"item : {item.Item1} Price : {item.Item2}");
                        Console.ResetColor();
                    }


                }
                else
                {
                    Console.WriteLine("The Cart Is Empty");
                }
            }

            private static IEnumerable<Tuple<string, double>> GetCartPrice()
            {
                var CartPrice = new List<Tuple<string, double>>();

                foreach (var item in Product.itemcart)
                {
                    double price = 0;
                    bool founditem = Product.products.TryGetValue(item, out price);
                    if (founditem)
                    {
                        Tuple<string, double> itemprice = new Tuple<string, double>(item, price);
                        CartPrice.Add(itemprice);
                    }

                }
                return CartPrice;
            }

            private static void RemoveItem()
            {
                VeiwCartItem();

                if (Product.itemcart.Any())
                {
                    Console.WriteLine("please slect item to remove");

                    string itemtoremove = Console.ReadLine();

                    if (Product.itemcart.Contains(itemtoremove))
                    {
                        Product.itemcart.Remove(itemtoremove);
                        Product.Actions.Push("REMOVE|" + itemtoremove);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"item {itemtoremove} is removed");
                        Console.ResetColor();

                    }
                    else
                    {
                        Console.WriteLine("item not exist in shoping  cart");
                    }

                }
            }


            private static void Checkout()
            {
                double totalprice = 0;
                if (Product.itemcart.Any())
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("yuor cart item are :");
                    Console.ResetColor();

                    var itemincart = GetCartPrice();
                    foreach (var item in itemincart)
                    {
                        totalprice += item.Item2;

                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(item.Item1 + " " + item.Item2);
                        Console.ResetColor();
                    }

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"total price is : {totalprice}");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("cart is empty");
                    Console.ResetColor();
                }
            }


            private static void Undoaction()
            {
                if (Product.Actions.Any())
                {
                    string lastaction = Product.Actions.Pop();

                    var actionarray = lastaction.Split('|');
                    string action = actionarray[0];
                    string item = actionarray[1];

                    if (action == "ADD")
                    {
                        Product.itemcart.Remove(item);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Undo: removed {item}");
                    }
                    else if (action == "REMOVE")
                    {
                        Product.itemcart.Add(item);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Undo: added {item}");

                    }
                    Console.ResetColor();

                }
                else
                {
                    Console.WriteLine("No actions to undo");
                }
            }

        }







    }
}

