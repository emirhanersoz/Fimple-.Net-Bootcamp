using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp
{
    internal class PhoneBook
    {
        private List<Contact> contacts = new List<Contact>();

        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
            Console.WriteLine("Kişi başarıyla eklendi.");
        }

        public void RemoveContact(string searchTerm)
        {
            Contact contactToRemove = FindContact(searchTerm);

            if (contactToRemove == null)
            {
                Console.WriteLine("Aranan kriterlere uygun kişi bulunamadı.");
                return;
            }

            Console.WriteLine($"{contactToRemove.ToString()} rehberden silinmek üzere, onaylıyor musunuz? (y/n)");

            if (Console.ReadLine().ToLower() == "y")
            {
                contacts.Remove(contactToRemove);
                Console.WriteLine("Kişi başarıyla silindi.");
            }
            else
            {
                Console.WriteLine("Silme işlemi iptal edildi.");
            }
        }

        public void UpdateContact(string searchTerm)
        {
            Contact contactToUpdate = FindContact(searchTerm);

            if (contactToUpdate == null)
            {
                Console.WriteLine("Aranan kriterlere uygun kişi bulunamadı.");
                return;
            }

            Console.WriteLine($"{contactToUpdate.ToString()} güncellenmek üzere, onaylıyor musunuz? (y/n)");

            if (Console.ReadLine().ToLower() == "y")
            {
                Console.WriteLine("Lütfen yeni ismi giriniz:");
                contactToUpdate.FirstName = Console.ReadLine();

                Console.WriteLine("Lütfen yeni soyismi giriniz:");
                contactToUpdate.LastName = Console.ReadLine();

                Console.WriteLine("Lütfen yeni telefon numarasını giriniz:");
                contactToUpdate.PhoneNumber = Console.ReadLine();

                Console.WriteLine("Kişi başarıyla güncellendi.");
            }
            else
            {
                Console.WriteLine("Güncelleme işlemi iptal edildi.");
            }
        }

        public void ListContacts(bool ascendingOrder)
        {
            contacts.Sort((a, b) => ascendingOrder ? a.FirstName.CompareTo(b.FirstName) : b.FirstName.CompareTo(a.FirstName));

            Console.WriteLine("Telefon Rehberi");
            Console.WriteLine("**********************************************");

            foreach (var contact in contacts)
            {
                Console.WriteLine(contact.ToString());
            }
        }

        public void SearchContacts(string searchTerm, int searchType)
        {
            List<Contact> searchResults = new List<Contact>();

            if (searchType == 1)
            {
                searchResults = contacts.FindAll(contact => contact.FirstName.Contains(searchTerm) || contact.LastName.Contains(searchTerm));
            }
            else if (searchType == 2)
            {
                searchResults = contacts.FindAll(contact => contact.PhoneNumber.Contains(searchTerm));
            }

            Console.WriteLine("Arama Sonuçlarınız:");
            Console.WriteLine("**********************************************");

            foreach (var contact in searchResults)
            {
                Console.WriteLine(contact.ToString());
            }
        }

        public Contact FindContact(string searchTerm)
        {
            return contacts.Find(contact => contact.FirstName.Contains(searchTerm) || contact.LastName.Contains(searchTerm));
        }
    }
}
