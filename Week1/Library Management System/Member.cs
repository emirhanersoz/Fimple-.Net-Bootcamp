using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    internal class Member
    {
        internal string FirstName { get; set; }
        internal string LastName { get; set; }
        internal int MemberID { get; set; }
        internal List<WrittenWork> BorrowedWorks { get; set; }

        private static int _memberCounter = 1;

        internal Member()
        {
            MemberID = _memberCounter++;
            BorrowedWorks = new List<WrittenWork>();
        }
    }
}
