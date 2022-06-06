using System;

namespace Inlämningsuppgift
{
    class Program
    {
        static void Main(string[] args)
        {

            LibrarySystem library = new LibrarySystem();
            Database database = new Database();

            /*
            string title = "ventures";
            database.SearchTitle(title);
            string author = "Jane";
            database.SearchAuthor(author);
            string titleorauthor = "Jane";
            database.SearchBoth(titleorauthor);           
            library.AddUser("johndoe3", "userpassword3", "John Doe", "johndoestreet 6", "12345678", "johndoe3@email.com", new Account(0, 0, 0));
            library.AddUser("johndoe4", "userpassword4", new Account(0, 0, 0));           
            Book testbook = database.GetBook(3);
            Console.WriteLine(testbook.GetTitle());
            
            */



            Greetings(library, database);


        }





        public static void Greetings(LibrarySystem library, Database database)
        {
            string input;

            do
            {
                Console.WriteLine("");
                Console.WriteLine("Welcome to " + library.GetLibraryname() + "." + " Address:" + library.GetLibraryAddress());
                Console.WriteLine("");
                Console.WriteLine("Type \"L\" - to log in");
                Console.WriteLine("Type \"reg\" - to register new user");
                Console.WriteLine("Type \"admin\" - to log in as admin");
                Console.WriteLine("Type \"quit\" - to exit application");


                input = Console.ReadLine().ToUpper();

                switch (input)
                {
                    case "L":
                        Login(library, database);
                        break;

                    case "REG":
                        Register(library, database);
                        break;

                    case "ADMIN":
                        AdminLogin(library, database);
                        break;
                }
            } while (input != "QUIT");
        }

        public static void Login(LibrarySystem library, Database database)
        {
            bool loggin = false;

            do
            {
                Console.WriteLine("");
                Console.WriteLine("Please write your username and password to log in:");


                Console.Write("Username:");
                string usernameinput = Console.ReadLine();
                Console.Write("Password:");
                string passwordinput = Console.ReadLine();


                if (library.ConfirmUser(usernameinput, passwordinput))
                {
                    loggin = true;
                    Console.WriteLine("");
                    Console.WriteLine("Log in successfull");
                    Console.WriteLine("Welcome " + library.GetCurrentUserName());
                    LoggedIn(library, database);
                    break;
                }


                Console.WriteLine("Log in failed");
                Console.WriteLine("Would you like to try again? y/n");
                if (Console.ReadLine().ToUpper() == "N")
                {
                    loggin = true;
                }


            } while (loggin == false);
        }

        public static void AdminLogin(LibrarySystem library, Database database)
        {
            bool loggin = false;

            do
            {
                Console.WriteLine("");
                Console.Write("Adminusername: ");
                string adminusername = Console.ReadLine();
                Console.Write("Adminpassword: ");
                string adminpassword = Console.ReadLine();

                if (library.ConfirmAdmin(adminusername, adminpassword))
                {
                    loggin = true;
                    Console.WriteLine("");
                    Console.WriteLine("Welcome administrator");
                    AdminLoggedIn(library, database);
                    break;
                }


                Console.WriteLine("Log in failed");
                Console.WriteLine("Would you like to try again? y/n");
                if (Console.ReadLine().ToUpper() == "N")
                {
                    loggin = true;
                }


            } while (loggin == false);
        }


        public static void LoggedIn(LibrarySystem library, Database database)
        {
            string input;
            Console.WriteLine("");
            Console.WriteLine("Type \"View\" - to see all the books in the library");
            Console.WriteLine("Type \"Search\" - to search for specific books.");
            Console.WriteLine("Type \"Reserve\" - to reserve a book");
            Console.WriteLine("Type \"Acc\" - to see your account information");
            Console.WriteLine("Type \"Log out\" - to log out");

            do
            {

                input = Console.ReadLine().ToUpper();
                int inputnumber;

                if (input == "SEARCH" || input == "VIEW" || input == "RESERVE" || input == "ACC" || input == "LOG OUT")
                {

                    switch (input)
                    {
                        case "SEARCH":
                            Console.Write("Search: ");
                            database.SearchBoth(Console.ReadLine());
                            Console.WriteLine("");
                            break;

                        case "VIEW":
                            Console.WriteLine("");
                            database.View();
                            break;

                        case "RESERVE":
                            Console.WriteLine("");
                            Console.WriteLine("Type the BookID number of the book you wish to reserve");

                            input = (Console.ReadLine());
                            inputnumber = CheckifNumber(input);
                            if (inputnumber != -1)
                            {

                                Console.WriteLine("");

                                if (database.CheckValid(inputnumber) == 1)
                                {
                                    Book book = database.GetBook(inputnumber);

                                    database.Reserve(inputnumber);
                                    library.ReserveBook(book);
                                }

                            }
                            else { Console.WriteLine("Invalid number"); }
                            break;

                        case "ACC":
                            Console.WriteLine("");
                            library.CheckAccount();
                            break;

                    }
                }
                else { Console.WriteLine("Invlaid Command");
                    Console.WriteLine("View, Search, Reserve, Acc or Log out");
                }
            } while (input != "LOG OUT");


        }

        public static void Register(LibrarySystem library, Database database)
        {
            bool accountcreated = false;
            do
            {
                Console.WriteLine("");
                Console.WriteLine("Please type your desired username");
                Console.WriteLine("Type \"b\" - to go back to the main menu");

                string registerusername = Console.ReadLine();
                if (registerusername.ToUpper() == "B")
                {
                    break;
                }
                if (library.ConfirmUniqueUsername(registerusername))
                {
                    Console.WriteLine("Please type your desiered password");

                    string registerpassword = Console.ReadLine();
                    library.AddUser(registerusername, registerpassword, new Account(0, 0, 0));
                    accountcreated = true;
                    Console.WriteLine("Account " + registerusername + " created.");

                }
                else
                {
                    Console.WriteLine("That username already exists. Please try another one");
                }
            } while (accountcreated == false);

        }

        

        public static void AdminLoggedIn(LibrarySystem library, Database database)
        {
            string input;
            Console.WriteLine("");
            Console.WriteLine("Type View - to see all the books in the library");
            Console.WriteLine("Type Search - to search for specific books");
            Console.WriteLine("Type Update - to update ´the status of a book in the library");
            Console.WriteLine("Type Add - to add a book to the library");
            Console.WriteLine("Type Delete - to remove a book from the library");
            Console.WriteLine("Type \"Log out\" - to log out");

            do
            {
                input = Console.ReadLine().ToUpper();
                int inputyear;
                int inputbookid;
                int number;

                if (input == "VIEW" || input == "SEARCH" || input == "UPDATE" || input == "ADD" || input == "DELETE" || input == "LOG OUT")
                {

                    switch (input)
                    {
                        case "SEARCH":
                            Console.WriteLine("");
                            Console.Write("Search: ");
                            database.SearchBoth(Console.ReadLine());
                            Console.WriteLine("");
                            break;

                        case "VIEW":
                            Console.WriteLine("");
                            database.View();

                            break;

                        case "UPDATE":
                            Console.WriteLine("");
                            Console.WriteLine("Type in the Book id of the book that you wish to update");
                            input = (Console.ReadLine());
                            number = CheckifNumber(input);
                            if (number != -1)
                            {
                                Console.WriteLine("");
                                database.Update(number);
                            }
                            else { Console.WriteLine("Invalid number"); }
                            break;

                        case "ADD":
                            Console.WriteLine("");
                            Console.WriteLine("Type in the following information of the book you wish to add:");
                            Console.Write("Title: ");
                            string title = Console.ReadLine();
                            Console.Write("Author: ");
                            string author = Console.ReadLine();
                            Console.Write("Year: ");
                            string year = (Console.ReadLine());
                            inputyear = CheckifNumber(year);
                            if (inputyear != -1)
                            {
                                Console.Write("Book id: ");
                                string bookid;
                                do
                                {
                                    bookid = (Console.ReadLine());
                                    inputbookid = CheckifNumber(bookid);
                                    if (inputbookid == -1)
                                    {
                                        Console.WriteLine("Invalid number");
                                        break;
                                    }


                                } while (database.CheckBookId(inputbookid) == -1);
                                string status = "AVAILABLE";
                                database.AddBook(inputbookid, title, author, inputyear, status);
                                Console.WriteLine(title + " was added to the library");
                            }
                            else { Console.WriteLine("Invalid year"); }
                            break;

                        case "DELETE":
                            Console.WriteLine("");
                            Console.WriteLine("Type in the Book id of the book that you wish to delete");
                            input = (Console.ReadLine());
                            number = CheckifNumber(input);
                            if (number != -1)
                            {
                                database.DeleteBook(number);
                            }
                            else { Console.WriteLine("Invalid number"); }
                            break;
                    }


                }
                else { Console.WriteLine("Invalid command");
                    Console.WriteLine("View, Search, Update, Add, Delete or Log out");
                }
                } while (input != "LOG OUT") ;
            

        }

        public static int CheckifNumber(string input)
        {
            try
            {
                return Int32.Parse(input);
            }
            catch (Exception e)
            {
                return -1;
            }

        }
    }
    


}


            
            
                

            
           
           




            

        
    

