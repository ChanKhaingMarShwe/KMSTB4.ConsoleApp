List<Product> products = new List<Product>();

Start:
Console.WriteLine("Choose one option :");
Console.WriteLine("1. Add Product");
Console.WriteLine("2. View Products");
Console.WriteLine("3. Edit Product");
Console.WriteLine("4. Delete Product");
Console.WriteLine("5. Exit");
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
    case 3:
        EditProduct();
        goto Start;
        break;
    case 4:
        DeleteProduct();
        goto Start;
        break;
    case 5:       
    default:
        break;
}

void AddProduct()
{
    Console.Write("Enter Product Name: ");
    string productName = Console.ReadLine();

    Console.Write("Enter Price: ");
    decimal price = Convert.ToDecimal(Console.ReadLine());

    Console.Write("Enter Quantity: ");
    int quantity = Convert.ToInt32(Console.ReadLine());

    int no = products.Any() ? products.Max(x => x.Id) + 1 : 1;
    Product product = new Product(no, productName, price, quantity);
    products.Add(product);

    Console.WriteLine("----------------------------------------");
}
void ViewProducts()
{
    Console.WriteLine($"Product Count : {products.Count}");
    Console.WriteLine("---Product List---");
    foreach (var product in products)
    {
        Console.WriteLine($"{product.Id}. Name: {product.ProductName}, Price: {product.Price}, Quantity: {product.Quantity}");
        Console.WriteLine("------------------------------------------");
    }
}

void EditProduct()
{
    Console.Write("Enter your Id :");

    int id = Convert.ToInt32(Console.ReadLine());

    var product = products.Where(x => x.Id == id).FirstOrDefault();
    if (product is null)
    {
        Console.WriteLine("No data found.");
        return;
    }
    Console.WriteLine($"{product.Id}. Name: {product.ProductName}, Price: {product.Price}, Quantity: {product.Quantity}");
    Console.WriteLine("------------------------------------------");

    Console.Write("Enter New Product Name: ");
    string productName = Console.ReadLine();
    if (string.IsNullOrEmpty(productName))
    {
        productName = product.ProductName;
    }

    Console.Write("Enter New Price: ");
    string str = Console.ReadLine();
    decimal price = 0;
    if (string.IsNullOrEmpty(str))
    {
        price = product.Price;
    }
    else {
        price = Convert.ToDecimal(str);
    }

    Console.Write("Enter New Quantity: ");
    str = Console.ReadLine();
    int quantity = 0;
    if (string.IsNullOrEmpty(str))
    {
        quantity = product.Quantity;
    }
    else
    {
        quantity = Convert.ToInt32(str);
    }

    int index = products.FindIndex(x => x.Id == id);
    products[index].ProductName = productName;
    products[index].Price = price;
    products[index].Quantity = quantity;

    Console.WriteLine("Product Updated !");
    Console.WriteLine("------------------------------------------");

}
void DeleteProduct()
{
    Console.Write("Enter Id You want to delete:");
    int id = Convert.ToInt32(Console.ReadLine());

    Console.Write("Are you sure to delete? (Y/N) :");
    string confirm=Console.ReadLine();
    if(confirm.ToUpper() != "Y")
    {
        return;
    }
    var product = products.Where(x => x.Id == id).FirstOrDefault();
    if(product is null)
    {
        Console.WriteLine("No data found !");
        return;
    }

    products.Remove(product);
    Console.WriteLine("Product deleted successfully !");
    Console.WriteLine("------------------------------------------");
}

public class Product
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public Product(int id,string productName, decimal price, int quantity)
    {
        Id = id;
        ProductName = productName;
        Price = price;
        Quantity = quantity;
}

}


