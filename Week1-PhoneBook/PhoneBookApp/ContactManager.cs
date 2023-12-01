using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp
{
    internal class ContactManager
    {
        public static void AddNewContact(PhoneBook phoneBook)
        {
            Console.WriteLine("Lütfen isim, soyisim ve telefon numarasını sırasıyla giriniz (örneğin: John Doe 1234567890):");
            string[] input = Console.ReadLine().Split(' ');

            if (input.Length == 3)
            {
                phoneBook.AddContact(new Contact { FirstName = input[0], LastName = input[1], PhoneNumber = input[2] });
            }
            else
            {
                Console.WriteLine("Geçersiz giriş. Lütfen doğru formatta bilgi girin.");
            }
        }

        public static void RemoveContact(PhoneBook phoneBook)
        {
            Console.WriteLine("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz:");
            string searchTerm = Console.ReadLine();

            Contact contactToRemove = phoneBook.FindContact(searchTerm);

            if (contactToRemove == null)
            {
                Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine("* Silmeyi sonlandırmak için : (1)");
                Console.WriteLine("* Yeniden denemek için      : (2)");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Silme işlemi iptal edildi.");
                            return;
                        case 2:
                            RemoveContact(phoneBook); // Yeniden deneme
                            return;
                        default:
                            Console.WriteLine("Geçersiz seçim. Silme işlemi iptal edildi.");
                            return;
                    }
                }
                else
                {
                    Console.WriteLine("Geçersiz giriş. Silme işlemi iptal edildi.");
                    return;
                }
            }

            Console.WriteLine($"{contactToRemove.ToString()} rehberden silinmek üzere, onaylıyor musunuz? (y/n)");

            if (Console.ReadLine().ToLower() == "y")
            {
                phoneBook.RemoveContact(searchTerm);
                Console.WriteLine("Kişi başarıyla silindi.");
            }
            else
            {
                Console.WriteLine("Silme işlemi iptal edildi.");
            }
        }


        public static void UpdateContact(PhoneBook phoneBook)
        {
            Console.WriteLine("Lütfen numarasını güncellemek istediğiniz kişinin adını veya soyadını giriniz:");
            string searchTerm = Console.ReadLine();

            phoneBook.UpdateContact(searchTerm);
        }

        public static void ListContacts(PhoneBook phoneBook)
        {
            Console.WriteLine("Rehberi Listeleme Seçenekleri:");
            Console.WriteLine("(1) A-Z sıralı listele");
            Console.WriteLine("(2) Z-A sıralı listele");

            int orderChoice;
            if (int.TryParse(Console.ReadLine(), out orderChoice))
            {
                switch (orderChoice)
                {
                    case 1:
                        phoneBook.ListContacts(true);
                        break;
                    case 2:
                        phoneBook.ListContacts(false);
                        break;
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

        public static void SearchContacts(PhoneBook phoneBook)
        {
            Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz:");
            Console.WriteLine("(1) İsim veya soyisime göre arama yapmak");
            Console.WriteLine("(2) Telefon numarasına göre arama yapmak");

            int searchType;
            if (int.TryParse(Console.ReadLine(), out searchType))
            {
                switch (searchType)
                {
                    case 1:
                        SearchByName(phoneBook);
                        break;
                    case 2:
                        SearchByPhoneNumber(phoneBook);
                        break;
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

        public static void SearchByName(PhoneBook phoneBook)
        {
            Console.WriteLine("Lütfen isim veya soyisimi giriniz:");
            string searchTerm = Console.ReadLine();

            phoneBook.SearchContacts(searchTerm, 1);
        }

        public static void SearchByPhoneNumber(PhoneBook phoneBook)
        {
            Console.WriteLine("Lütfen telefon numarasını giriniz:");
            string searchTerm = Console.ReadLine();

            phoneBook.SearchContacts(searchTerm, 2);
        }
    }
}
