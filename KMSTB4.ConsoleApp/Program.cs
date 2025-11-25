List<Product> products = new List<Product>();

Start:
Console.WriteLine("Choose one option :");
Console.WriteLine("1. Add Product");
Console.WriteLine("2. View Products");
Console.WriteLine("3. Exit");
Console.Write("Enter your option:");
int option = Convert.ToInt32(Console.ReadLine());

switch(option)
{
    case 1:
        AddProduct();
        goto Start;
        break;
    case 2:
        ViewProducts();
        goto Start;
        break;    
    default:
        break;
}

void ViewProducts()
{
    Console.WriteLine($"Product Count : {products.Count}");
    Console.WriteLine("---Product List---");
    foreach(var product in products)
    {
        Console.WriteLine($"Name: {product.ProductName}, Price: {product.Price}, Quantity: {product.Quantity}");
        Console.WriteLine("------------------------------------------");
    }
}

void AddProduct()
{
    Console.Write("Enter Product Name: ");
    string productName = Console.ReadLine();
    Console.Write("Enter Price: ");
    decimal price = Convert.ToDecimal(Console.ReadLine());
    Console.Write("Enter Quantity: ");
    int quantity = Convert.ToInt32(Console.ReadLine());
    Product product = new Product(productName, price, quantity);
    products.Add(product);

    Console.WriteLine("----------------------------------------");
}


public class Product
{
    public string ProductName { get; set; }
    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public Product(string productName, decimal price, int quantity)
    {
        ProductName = productName;
        Price = price;
        Quantity = quantity;
}

}


