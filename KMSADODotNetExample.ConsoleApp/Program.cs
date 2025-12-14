using KMSADODotNetExample.ConsoleApp;

ADODotNetExample adx= new ADODotNetExample();
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
        adx.AddProduct();
        goto Start;
        break;
    case 2:
        adx.Read();
        goto Start;
        break;
    case 3:
        adx.Edit();
        goto Start;
        break;
    case 4:
        adx.Update();
        goto Start;
        break;
    case 5:
        adx.Delete();
        goto Start;
        break;
     case 6:
    default:
        break;
}

Console.ReadLine();