
using KMSDapperExample.ConsoleApp;

DapperExample dp = new DapperExample();
Start:
Console.WriteLine("Choose one option :");
Console.WriteLine("1. Add Product");
Console.WriteLine("2. View Products");
Console.WriteLine("3. Edit Product");
Console.WriteLine("4. Update Product");
Console.WriteLine("5. Delete Product");
Console.WriteLine("6. Exit");
Console.Write("Enter your option:");

int option = Convert.ToInt32(Console.ReadLine());

switch (option)
{
    case 1:
        dp.AddProduct();
        goto Start;
        break;
    case 2:
        dp.Read();
        goto Start;
        break;
    case 3:
        dp.Edit();
        goto Start;
        break;
    case 4:
        dp.Update();
        goto Start;
        break;
    case 5:
        dp.Delete();
        goto Start;
        break;
    case 6:
    default:
        break;
}

Console.ReadLine();