using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject2
{
    public class Product
    {
        public Product() {}
        public Product(string category, string name, int price)
        {
            Category = category;
            Name = name;
            Price = price;
        }

        public string Category { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
    class ProductList : List<Product>  // ProductList derived from class List
    {
        public void EnterNewProduct()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("To enter a new product - follow the steps | To quit - enter: \"Q\"");
                Console.ResetColor();
                Console.Write("Enter a Category: ");
                string quitChoice = Console.ReadLine().Trim().ToUpper();
                if (quitChoice == "Q") break;
                Product Myproduct = new Product();
                Myproduct.Category = quitChoice;
                Console.Write("Enter a product Name: ");
                Myproduct.Name = Console.ReadLine();
                while (Myproduct.Price == 0) // Error handling - Price needs to be a numeric value
                {
                    Console.Write("Enter a Price: ");
                    try
                    {
                        Myproduct.Price = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You need to input a whole number");
                        Console.ResetColor();
                    }
                }
                this.Add(Myproduct);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The product was successfully added");
                Console.ResetColor();
                Console.WriteLine("----------------------------------------------------------------------------------------");
            }
            this.ShowAllProducts();
        }
        
        public void ShowAllProducts() 
        {
            Console.WriteLine("----------------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Category".PadRight(30) + "Name".PadRight(40) + "Price");
            Console.ResetColor();
            List<Product> sortedProducts = this.OrderBy(item => item.Price).ToList(); // Create a local sorted list
            foreach (Product product in sortedProducts) 
            {
              Console.WriteLine(product.Category.PadRight(30) + product.Name.PadRight(40) + product.Price);
            }
            Console.WriteLine("\n" + " ".PadRight(30) + "Total amount: ".PadRight(40) + this.Sum(Product => Product.Price)); // Get Total
        }
        public void SearchProducts()
        {
            Console.WriteLine("----------------------------------------------------------------------------------------");
            Console.Write("Enter a Product Name: ");
            string mySearchName = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Category".PadRight(30) + "Name".PadRight(40) + "Price");
            Console.ResetColor();
            foreach (var item in this)
            {
                if (item.Name == mySearchName) 
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(item.Category.PadRight(30) + item.Name.PadRight(40) + item.Price);
                    Console.ResetColor();
                } 
                else Console.WriteLine(item.Category.PadRight(30) + item.Name.PadRight(40) + item.Price);
            }
           
        }

    }
}
