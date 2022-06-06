using System;
using System.Collections.Generic;
using System.Text;

namespace Inlämningsuppgift
{
    class CourseLitterature : Book
    {
        private string subject;
        private string edition;
        public CourseLitterature(int bookid, string title, string author, int year, string status, string subject, string edition) : base (bookid, title, author, year, status)
        {
            this.subject = subject;
            this.edition = edition;
        }

        public string GetSubject()
        {
            return subject;
        }

        public string GetEdition()
        {
            return edition;
        }

    }
}
