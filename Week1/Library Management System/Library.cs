using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    internal class Library : IPrintable
    {
        private List<Book> Books { get; set; }
        private List<Member> Members { get; set; }
        private Loanable LoanPolicy { get; set; }

        public Library(Loanable loanPolicy)
        {
            Books = new List<Book>();
            Members = new List<Member>();
            LoanPolicy = loanPolicy;
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public void AddMember(Member member)
        {
            Members.Add(member);
        }

        public void LoanBook(Member member, WrittenWork work)
        {
            if (Books.Contains((Book)work) && Members.Contains(member))
            {
                member.BorrowedWorks.Add(work);
                Books.Remove((Book)work);
                Console.WriteLine($"{work.Title} work is loaned to {member.FirstName} {member.LastName}.");
                LoanPolicy.LoanBook(member, work);
            }
            else
            {
                Console.WriteLine("Work or member not found.");
            }
        }

        public void ReturnBook(Member member, WrittenWork work)
        {
            if (member.BorrowedWorks.Contains(work))
            {
                member.BorrowedWorks.Remove(work);
                Books.Add((Book)work);
                Console.WriteLine($"{work.Title} work is returned by {member.FirstName} {member.LastName}.");
                LoanPolicy.ReturnBook(member, work);
            }
            else
            {
                Console.WriteLine("The specified member has not borrowed this work.");
            }
        }

        public void Print()
        {
            Console.WriteLine("Library Status:");
            Console.WriteLine("Books:");
            foreach (var book in Books)
            {
                Console.WriteLine($"ID: {book.WorkID}, Title: {book.Title}, Author: {book.Author}, Publication Year: {book.PublicationYear}");
            }

            Console.WriteLine("\nMembers:");
            foreach (var member in Members)
            {
                Console.WriteLine($"Member ID: {member.MemberID}, First Name: {member.FirstName}, Last Name: {member.LastName}");
                Console.WriteLine("Borrowed Works:");
                foreach (var borrowedWork in member.BorrowedWorks)
                {
                    Console.WriteLine($"  - {borrowedWork.Title}");
                }
            }
        }
    }
}
