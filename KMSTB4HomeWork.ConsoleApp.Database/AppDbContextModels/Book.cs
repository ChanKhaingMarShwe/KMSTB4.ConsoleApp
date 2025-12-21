using System;
using System.Collections.Generic;

namespace KMSTB4HomeWork.ConsoleApp.Database.AppDbContextModels;

public partial class Book
{
    public int BookId { get; set; }

    public string Title { get; set; } = null!;

    public string Author { get; set; } = null!;

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool IsDelete { get; set; }
}
