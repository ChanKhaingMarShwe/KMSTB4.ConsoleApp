
List<Book> books = new List<Book>();
Start:
Console.WriteLine("Choose one option :");
Console.WriteLine("1. Add Book");
Console.WriteLine("2. View Books");
Console.WriteLine("3. Edit Book");
Console.WriteLine("4. Delete Book");
Console.WriteLine("5. Exit");
Console.Write("Enter your option:");
int option = Convert.ToInt32(Console.ReadLine());

switch(option)
{
    case 1:
        AddBook();
        goto Start;
        break;
    case 2:
        ViewBooks();
        goto Start;
        break;
    case 3:
        EditBook();
        goto Start;
        break;
    case 4:
        DeleteBook();
        goto Start;
        break;
    case 5:       
    default:
        break;
}

void AddBook()
{
    Console.Write("Enter Book Title: ");
    string title = Console.ReadLine();

    Console.Write("Enter Author Name: ");
    string author = Console.ReadLine();

    Console.Write("Enter Price: ");
    decimal price = Convert.ToDecimal(Console.ReadLine());

    Console.Write("Enter Quantity: ");
    int quantity = Convert.ToInt32(Console.ReadLine());

    int no = books.Any() ? books.Max(x => x.Id) + 1 : 1;
    Book book = new Book(no, title, author, price, quantity);

    books.Add(book);
    Console.WriteLine("----------------------------------------");

}

void ViewBooks()
{
   
    Console.WriteLine($"Book Count : {books.Count}");
    Console.WriteLine("---Book List---");
    foreach (var book in books)
    {
        Console.WriteLine($"{book.Id}. Title: {book.Title}, Author: {book.Author}, Price: {book.Price}, Quantity: {book.Quantity}");
        Console.WriteLine("------------------------------------------");
    }
}

void EditBook()
{
    Console.Write("Enter Book Id to Edit: ");
    int id = Convert.ToInt32(Console.ReadLine());
    var book = books.FirstOrDefault(b => b.Id == id);
    if(book is null)
    {
        Console.WriteLine("Book not found!");
        return;
    }

    Console.WriteLine($"{book.Id}. Title: {book.Title}, Author: {book.Author}, Price: {book.Price}, Quantity: {book.Quantity}");
    Console.WriteLine("------------------------------------------");

    Console.Write("Enter New Title: ");
    string title= Console.ReadLine();
    if(!string.IsNullOrEmpty(title))
    {
        book.Title = title;
    }

    Console.Write("Enter New Author: ");
    string author= Console.ReadLine();
    if(!string.IsNullOrEmpty(author))
    {
        book.Author = author;
    }
   

    Console.Write("Enter New Price: ");
    string str=Console.ReadLine();
    decimal price = 0;
    if (!string.IsNullOrEmpty(str))
    {
        book.Price = price;
    }
    else
    {
        price = Convert.ToDecimal(str);
    }


    Console.Write("Enter New Quantity :");
    str = Console.ReadLine();
    int quantity=0;
    if (!string.IsNullOrEmpty(str))
    {
        book.Quantity = quantity;
    }
    else
    {
        quantity = Convert.ToInt32(str);
    }

    Console.WriteLine("Book Updated !");
    Console.WriteLine("----------------------------------------");

}

void DeleteBook()
{
    Console.Write("Enter Book Id to Delete: ");
    int id = Convert.ToInt32(Console.ReadLine());

    Console.Write("Are you sure you want to delete? (Y/N) :");
    string confirm = Console.ReadLine();
    if(confirm.ToUpper() != "Y")
    {
        return;
    }
    var book = books.FirstOrDefault(b => b.Id == id);
    if (book is null)
    {
        Console.WriteLine("Book not found!");
        return;
    }
    books.Remove(book);
    Console.WriteLine("Book Deleted !");
    Console.WriteLine("----------------------------------------");
}

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public Book(int id, string title, string author, decimal price, int quantity)
    {
        Id = id;
        Title = title;
        Author = author;
        Price = price;
        Quantity = quantity;
    }
}
