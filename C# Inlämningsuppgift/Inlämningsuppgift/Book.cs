using System;
using System.Collections.Generic;
using System.Text;

namespace Inlämningsuppgift
{
    class Book
    {
        static int nextBookId = 1;
        private int BookId;
        private string title;
        private string author;
        private int year;
        private string status;

        public Book(int bookid, string title, string author, int year, string status)
        {
            this.BookId = bookid;
            this.title = title;
            this.author = author;
            this.year = year;
            this.status = status;
            nextBookId++;
        }

        public string GetTitle()
        {
            return title;
        }

        public string GetAuthor()
        {
            return author;
        }

        public int GetYear()
        {
            return year;
        }

        public int GetBookId()
        {
            return BookId;
        }

        public string GetStatus()
        {
            return status;
        }

        public void SetStatus(string b)
        {
            if (b == "RESERVED" || b == "AVAILABLE" || b == "ON LOAN")
            {
                Console.WriteLine("Status of Book id: " + GetBookId() + " changed to " + b + ".");
                status = b;
            }

            else { Console.WriteLine("Invalid command."); }
        }




    }
}
