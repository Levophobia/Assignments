using System;
using System.Collections.Generic;
using System.Text;

namespace Inlämningsuppgift
{
    class Account
    {
        private int numberofborrowedbooks;
        private int numberofreservedbooks;
        private int bookspastdue;
        List<Book> reservedbooks = new List<Book>();
        List<Book> currentlyborrowedbooks = new List<Book>();

        public Account(int numberofborrowedbooks, int numberofreservedbooks, int bookspastdue)
        {
            this.numberofborrowedbooks = numberofborrowedbooks;
            this.numberofreservedbooks = numberofreservedbooks;
            this.bookspastdue = bookspastdue;
        }

        public List<Book> GetReservedBooks()
        {
            return reservedbooks;
        }

        public void AddReservedBook(Book book)
        {
            reservedbooks.Add(book);
            numberofreservedbooks++;
            
        }

        public void AddCurrentlyBorrowed(Book book)
        {
            currentlyborrowedbooks.Add(book);
            numberofborrowedbooks++;
        }

        public void Getinfo()
        {
            Console.WriteLine("Books that you have reserved:");
            for (int i = 0; i < reservedbooks.Count; i++)
            {
                
                Console.WriteLine("Title: " + reservedbooks[i].GetTitle());
            }
            
            Console.WriteLine("Currently borrowed by you:");
            for (int i = 0; i < currentlyborrowedbooks.Count; i++)
            {
                
                Console.WriteLine("Title: " + currentlyborrowedbooks[i].GetTitle());
                  
            }


        }

    }
}
