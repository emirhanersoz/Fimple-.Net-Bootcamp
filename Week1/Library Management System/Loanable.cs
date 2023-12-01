using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    abstract class Loanable
    {
        public void LoanBook(Member member, WrittenWork work)
        {
            Console.WriteLine($"Loanable policy applied: {work.Title} work is loaned to {member.FirstName} {member.LastName}.");
            ApplyLoanPolicy(member, work);
        }

        public void ReturnBook(Member member, WrittenWork work)
        {
            Console.WriteLine($"Loanable policy applied: {work.Title} work is returned by {member.FirstName} {member.LastName}.");
            ApplyReturnPolicy(member, work);
        }

        protected abstract void ApplyLoanPolicy(Member member, WrittenWork work);
        protected abstract void ApplyReturnPolicy(Member member, WrittenWork work);
    }

    class ShortTermLoan : Loanable
    {
        protected override void ApplyLoanPolicy(Member member, WrittenWork work)
        {
            Console.WriteLine($"Short-term loan policy applied for: {work.Title}.");
        }

        protected override void ApplyReturnPolicy(Member member, WrittenWork work)
        {
            Console.WriteLine($"Short-term loan policy applied for return: {work.Title}.");
        }
    }

    class LongTermLoan : Loanable
    {
        protected override void ApplyLoanPolicy(Member member, WrittenWork work)
        {
            Console.WriteLine($"Long-term loan policy applied for: {work.Title}.");
        }

        protected override void ApplyReturnPolicy(Member member, WrittenWork work)
        {
            Console.WriteLine($"Long-term loan policy applied for return: {work.Title}.");
        }
    }
}
