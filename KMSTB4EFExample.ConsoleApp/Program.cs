
using KMSTB4EFExample.ConsoleApp;

//EFCoreSample eFCoreSample = new EFCoreSample();
EFCore2Sample eFCoreSample = new EFCore2Sample();
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
        eFCoreSample.Create();
        goto Start;
        break;
    case 2:
        eFCoreSample.Read();
        goto Start;
        break;
    case 3:
        eFCoreSample.Edit();
        goto Start;
        break;
    case 4:
        eFCoreSample.Update();
        goto Start;
        break;
    case 5:
        eFCoreSample.Delete();
        goto Start;
        break;
    case 6:
    default:
        break;
}

Console.ReadLine();