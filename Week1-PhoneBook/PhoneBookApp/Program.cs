using PhoneBookApp;
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        PhoneBook phoneBook = new PhoneBook();
        phoneBook.AddContact(new Contact { FirstName = "John", LastName = "Doe", PhoneNumber = "1234567890" });
        phoneBook.AddContact(new Contact { FirstName = "Alice", LastName = "Smith", PhoneNumber = "9876543210" });
        phoneBook.AddContact(new Contact { FirstName = "Bob", LastName = "Johnson", PhoneNumber = "5555555555" });
        phoneBook.AddContact(new Contact { FirstName = "Eva", LastName = "Davis", PhoneNumber = "3333333333" });
        phoneBook.AddContact(new Contact { FirstName = "Michael", LastName = "Wilson", PhoneNumber = "9999999999" });

        while (true)
        {
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz:");
            Console.WriteLine("(1) Yeni Numara Kaydetmek");
            Console.WriteLine("(2) Var olan Numarayı Silmek");
            Console.WriteLine("(3) Varolan Numarayı Güncelleme");
            Console.WriteLine("(4) Rehberi Listelemek");
            Console.WriteLine("(5) Rehberde Arama Yapmak");
            Console.WriteLine("(6) Çıkış");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        ContactManager.AddNewContact(phoneBook);
                        break;
                    case 2:
                        ContactManager.RemoveContact(phoneBook);
                        break;
                    case 3:
                        ContactManager.UpdateContact(phoneBook);
                        break;
                    case 4:
                        ContactManager.ListContacts(phoneBook);
                        break;
                    case 5:
                        ContactManager.SearchContacts(phoneBook);
                        break;
                    case 6:
                        Console.WriteLine("Uygulamadan çıkılıyor.");
                        return;
                    default:
                        Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Geçersiz giriş. Lütfen bir sayı girin.");
            }
        }
    }
}