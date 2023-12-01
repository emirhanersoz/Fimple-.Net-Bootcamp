using Library_Management_System;
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Library library = new Library(new LongTermLoan());

        Book book1 = new Book("Book 1", "Author 1", 2020);
        Book book2 = new Book("Book 2", "Author 2", 2021);

        Member member1 = new Member() { FirstName = "Ahmet", LastName = "Yilmaz" };
        Member member2 = new Member() { FirstName = "Ayse", LastName = "Demir" };

        library.AddBook(book1);
        library.AddBook(book2);
        library.AddMember(member1);
        library.AddMember(member2);

        library.LoanBook(member1, book1);
        library.LoanBook(member2, book2);

        Console.WriteLine(library.ToString());

        library.ReturnBook(member1, book1);

        Console.WriteLine(library.ToString());
    }
}