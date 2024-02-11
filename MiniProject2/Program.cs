using MiniProject2;

ProductList MyProductList = new ProductList();
MyProductList.EnterNewProduct(); // Initial input here

while (true) // now start input iteration
{
    Console.WriteLine("----------------------------------------------------------------------------------------");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("To enter a new product - enter: \"P\" | To search for a product - enter: \"S\" | To quit - enter: \"Q\"");
    Console.ResetColor();
    string mChoice = Console.ReadLine().Trim().ToUpper();
    if (mChoice == "Q") break;
    switch (mChoice)

    {
        case "P":
            MyProductList.EnterNewProduct(); // Call class method to simplyfy our menu
             break;
        case "S":
            MyProductList.SearchProducts(); // Call class method to simplyfy our menu
            break;
    }
    
}

