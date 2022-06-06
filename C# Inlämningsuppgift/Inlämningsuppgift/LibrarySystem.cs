using System;
using System.Collections.Generic;
using System.Text;

namespace Inlämningsuppgift
{
    class LibrarySystem
    {
        List<User> users = new List<User>();
        Staff[] staff = new Staff[2];
        private string Libraryname = "Christoffer's Library";
        private string address = "Biblioteksgatan 32";
        Database db = new Database();
        
        static int currentuser;
        static int currentadmin;


        public LibrarySystem()
        {
            Account account1 = new Account(0, 0, 0);
            Account account2 = new Account(0, 0, 0);
            Book book1 = db.GetBook(5);
            Book book2 = db.GetBook(7);
            account1.AddCurrentlyBorrowed(book1);
            account1.AddCurrentlyBorrowed(book2);
            
            AddUser("johndoe1", "userpassword1", "John Doe", "johndoestreet 4", "12345678", "johndoe1@email.com", account1);
            AddUser("johndoe2", "userpassword2", "John Doe", "johndoestreet 5", "23456789", "johndoe2@email.com", account2);
            staff[0] = new Staff("christoffersahlin", "123456");
            staff[1] = new Staff("nickilindqvist", "123456");
            
        }

        

        public bool ConfirmUser(string name, string password)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (name == users[i].GetUserName())
                {
                    if (password == users[i].GetUserPassword())
                    {
                        currentuser = i;
                        return true;
                        

                    }
                }
            }
            return false;
        }

        public bool ConfirmAdmin(string name, string password)
        {
            for (int i = 0; i < staff.Length; i++)
            {
                if (name == staff[i].GetName())
                {
                    if (password == staff[i].GetPassword())
                    {
                        currentadmin = i;
                        return true;
                    }
                }
            }
            return false;
        }

        public bool ConfirmUniqueUsername(string name)
        {
            for (int i = 0; i < users.Count; i++)
            {

                if (name == users[i].GetUserName())
                {
                    return false;
                }
            }
            return true;
        }


        public string GetCurrentUserName()
        {
            return users[currentuser].GetUserName();
        }
        
        public void AddUser(string username, string password, string name, string address, string phone, string email, Account account)
        {
            users.Add(new User(username, password, name, address, phone, email, account));
        }

        public void AddUser(string username, string password, Account account)
        {
            users.Add(new User(username, password, account));
        }
       

        public string GetLibraryname()
        {
            return Libraryname;
        }

        public string GetLibraryAddress()
        {
            return address;
        }

        public void CheckAccount() 
        {
            users[currentuser].GA();
        }

        public void ReserveBook(Book book)
        {
            users[currentuser].ReserveBook(book);
            
        }

        


    }
}
