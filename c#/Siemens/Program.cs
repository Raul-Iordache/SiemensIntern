// See https://aka.ms/new-console-template for more information
using Siemens;


string divider = "".PadRight(10, '-');

Console.WriteLine("Welcome in Borrowing system!");


PopulateSystem();

ShowBooks();

ShowPatrons();


while (true)
{

    Console.Write("Type your command: ");
    var userCommand = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(userCommand))
    {
        Console.WriteLine("Please insert a valid command!");
        continue;
    }

    try
    {
        switch (userCommand.ToLower())
        {
            case "books":
                ShowBooks();
                break;
            case "patrons":
                ShowPatrons();
                break;
            case "status":
                ShowBorrows();
                break;
            case "borrow":
                Console.Write("Insert please book ISBN: ");
                var isbn = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(isbn))
                {
                    Console.WriteLine("Invalid ISBN!");
                    continue;
                }
                Console.Write("Insert please Patron Id: ");
                var patronId = Console.ReadLine();

                var isOk = int.TryParse(patronId, out int validId);
                if (validId == 0)
                {
                    Console.WriteLine("Invalid PatronId!");
                    continue;
                }
                BorrowingSystem.Borrow(validId, isbn);
                break;
            case "return":
                Console.Write("Please insert BorrowId : ");
                var borrowId = Console.ReadLine();

                int.TryParse(borrowId, out int validBorrowId);
                if (validBorrowId == 0)
                {
                    Console.WriteLine("Invalid BorrowId!");
                    continue;
                }
                BorrowingSystem.ReturnBook(validBorrowId);
                break;
            case "quit":
            case "exit":
                goto Exit;
            default:
                Console.WriteLine("Please insert a valid command!");
                break;

        }

    }
    catch (Exception ex)
    {
        Console.WriteLine($"S-a produs exceptia : {ex.Message}");
        Console.WriteLine(string.Empty);
    }

}

Exit:

Console.WriteLine("Thank you for your time. Bye!");




void PopulateSystem()
{
    var books = new List<Book>();
    books.Add(new Book { Isbn = "0-1", Author = "Camil Petrescu", Title = "Noaptea dupa inserate", Quantity = 3 });
    books.Add(new Book { Isbn = "0-2", Author = "Ion Creanga", Title = "Amintiri din copilarie", Quantity = 2 });
    books.Add(new Book { Isbn = "0-3", Author = "Mihail Sadoveanu", Title = "Neamul Soimarestilor", Quantity = 5 });

    BorrowingSystem.Books = books;

    var patrons = new List<Patron>();
    patrons.Add(new Patron { Id = 1, Name = "Raul Iordache", ContactInfo = "Badon, str. Principala nr 117E, jud. Salaj" });
    patrons.Add(new Patron { Id = 2, Name = "Mihai Crisan", ContactInfo = "Zalau, str. Plopilor nr. 122, jud. Salaj" });
    patrons.Add(new Patron { Id = 3, Name = "Cornel Ivascau", ContactInfo = "Zalau, str. Tudor Vladimirescu bl. l3, jud. Salaj" }); 
    patrons.Add(new Patron { Id = 4, Name = "Alex Pop", ContactInfo = "Zalau, str. Simion Barnutiu bl. A28, jud. Salaj" });
    BorrowingSystem.Patrons = patrons;

}  

void ShowBooks()
{
    var books = BorrowingSystem.Books;
    Console.WriteLine(divider);
    Console.WriteLine("List of books: ");
    foreach (Book book in books)
        Console.WriteLine($" * ISBN: {book.Isbn}, Autor: {book.Author}, Title: {book.Title}, Available: {book.Quantity - book.CurrentBorrowsCount}");

    Console.WriteLine("");
}
void ShowPatrons()
{
    var patrons = BorrowingSystem.Patrons;
    Console.WriteLine(divider);
    Console.WriteLine("List of patrons: ");
    foreach (Patron patron in patrons)
        Console.WriteLine($" * Id: {patron.Id}, Name: {patron.Name}, Info: {patron.ContactInfo}");

    Console.WriteLine("");
}

void ShowBorrows()
{
    var borrows = BorrowingSystem.Borrows;
    Console.WriteLine(divider);
    Console.WriteLine("List of borrows: ");
    foreach (Borrow borrow in borrows)
        Console.WriteLine($" * Id: {borrow.BorrowId}, Book: {borrow.BookIsbn}, Patron: {borrow.PatronId}, Returned: {borrow.Returned}");

    Console.WriteLine("");
}

