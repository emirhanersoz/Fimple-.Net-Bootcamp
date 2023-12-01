using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    internal class WrittenWork
    {
        internal string Title { get; set; }
        internal string Author { get; set; }
        internal int PublicationYear { get; set; }
        internal int WorkID { get; set; }

        private static int _workCounter = 1;

        public WrittenWork() => WorkID = _workCounter++;
    }
}
