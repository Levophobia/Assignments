using System;
using System.Collections.Generic;
using System.Text;

namespace Inlämningsuppgift
{
    class User
    {
        static int nextUserId = 1;
        private int userid;
        private string username;
        private string password;
        private string name;
        private string address;
        private string phone;
        private string email;
        private Account account;

        public User(string username, string password, string name, string address, string phone, string email, Account account)
        {
            userid = nextUserId;
            this.username = username;
            this.password = password;
            this.name = name;
            this.address = address;
            this.phone = phone;
            this.email = email;
            this.account = account;
            nextUserId++;
        }

        public User(string username, string password, Account account)
        {
            userid = nextUserId;
            this.username = username;
            this.password = password;
            this.account = account;
            nextUserId++;
            
        }

        public string GetUserName()
        {
            return username;
        }

        public string GetUserPassword()
        {
            return password;
        }

        /*public void GetAccountInfo()
        {
            List<Book> listofreservedbooks = account.GetReservedBooks();
            for (int i = 0; i < listofreservedbooks.Count; i++)
            {
                Console.WriteLine("Books that you have reserved");
                Console.WriteLine("Title: " + listofreservedbooks[i].GetTitle());
            }
        }*/

        public void ReserveBook(Book book)
        {
            account.AddReservedBook(book);
        }

        public void BorrowedBook(Book book)
        {
            account.AddCurrentlyBorrowed(book);
        }

        public void GA()
        {
            account.Getinfo();
        }
    }
}
