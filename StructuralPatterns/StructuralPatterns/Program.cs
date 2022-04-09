// See https://aka.ms/new-console-template for more information
using StructuralPatterns.DecoratorPattern;
using StructuralPatterns.FacadePattern;
using StructuralPatterns.ProxyPattern;

Console.WriteLine("Hello, World!");
RetrieveDataProxy retrieveDataProxy = new RetrieveDataProxy();
var books = retrieveDataProxy.GetBooks();
foreach (var b in books)
{
    Console.WriteLine(b.Title+" "+b.OtherOption);
}

var book = books[0];
book.Display();
OtherOptionDecorator ebook = new OtherOptionDecorator(book);
ebook.ChangeOption("ebook");
ebook.Display();
OtherOptionDecorator audiobook = new OtherOptionDecorator(book);
audiobook.ChangeOption("audiobook");
audiobook.Display();

var facade = new BooksExportFacade();
facade.ExportBooksInfo();