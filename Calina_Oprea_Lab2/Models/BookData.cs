using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class BookData
{
    public IEnumerable<Book> Books { get; set; }
    public IEnumerable<Category> Categories { get; set; }
    public IEnumerable<BookCategory> BookCategories { get; set; }
}
