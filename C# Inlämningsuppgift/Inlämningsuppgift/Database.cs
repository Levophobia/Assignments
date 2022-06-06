using System;
using System.Collections.Generic;
using System.Text;

namespace Inlämningsuppgift
{
    class Database
    {
        List<Book> databaseBooks = new List<Book>();
        List<CourseLitterature> databaseCourseLitterature = new List<CourseLitterature>();
        List<Journal> databaseJournals = new List<Journal>();
        List<Magazine> databaseMagazines = new List<Magazine>();

        public Database()
        {
            AddBook(1,"Adventures of Huckelberry Finn", "Mark Twain", 1884, "RESERVED");
            AddBook(2,"Don Quijote", "Miguel Cervantes", 1615, "AVAILABLE");
            AddBook(3,"Pride and Prejudice", "Jane Austen", 1813, "AVAILABLE");
            AddBook(4,"Sense and Sensibility", "Jane Austen", 1811, "AVAILABLE");
            AddBook(5,"The Hobbit", "J.R.R. Tolkien", 1937, "ON LOAN");
            AddBook(6,"A Storm of Swords", "Geoge R.R. Martin", 2000, "RESERVED");
            AddBook(7,"A Feast for Crows", "George R.R. Martin", 2005, "ON LOAN");
            AddCourseLitterature(8, "Science of Mind and Behaviour", "Nigel Holt", 2019, "AVAILABLE", "Psychology", "4th");
            AddCourseLitterature(9, "Algebra och diskret matematik", "Johan Jonasson & Stefan Lemurell", 2013, "AVAILABLE", "Math", "2nd");
            AddMagazine(10, "PC Gamer", "Evan Lahti", 2021, "AVAILABLE", "Gaming", 364, "November");
            AddMagazine(11, "PC Gamer", "Evan Lahti", 2021, "AVAILABLE", "Gaming", 363, "October");
            AddJournal(12, "Annual Review of Psychology", "Susan T Fiske", 2021, "AVAILABLE", 72);
            AddJournal(13, "Research in Engineering Design", "Yoram Reich", 2021, "AVAILABLE", 32);
            


        }
        public void Update(int number)
        {
            int numberoftimes = 0;
            for (int i = 0; i < databaseBooks.Count; i++)
            {
                if(number == databaseBooks[i].GetBookId())
                {
                    Console.WriteLine("What would you like to change the status of this book to??");
                    Console.WriteLine("Type \"On Loan\" - to change status to On Loan");
                    Console.WriteLine("Type \"Available\" - to change status to available");
                    string input = Console.ReadLine().ToUpper();

                    if (input != "AVAILABLE" && input != "ON LOAN")
                    {
                        Console.WriteLine("Invalid command");
                        numberoftimes++;
                        break;
                    }

                    if (input == databaseBooks[i].GetStatus())
                    {
                        Console.WriteLine("Status of that book is already " + input);
                        numberoftimes++;
                        break;
                    }

                    if (input != databaseBooks[i].GetStatus()) {
                        
                        

                        switch (input)
                        {
                            case "AVAILABLE":                               
                                databaseBooks[i].SetStatus(input);
                                numberoftimes++;
                                break;

                            case "ON LOAN":                              
                                databaseBooks[i].SetStatus(input);
                                numberoftimes++;
                                break;
                        }
                    }
                   
                    }


                }
            
            for (int i = 0; i < databaseCourseLitterature.Count; i++)
            {
                if (number == databaseCourseLitterature[i].GetBookId())
                {
                    Console.WriteLine("What would you like to change the status of this book to???");
                    Console.WriteLine("Type \"On Loan\" - to change status to On Loan");
                    Console.WriteLine("Type \"Available\" - to change status to available");
                    string input = Console.ReadLine().ToUpper();

                    if (input != "AVAILABLE" && input != "ON LOAN")
                    {
                        Console.WriteLine("Invalid command");
                        numberoftimes++;
                        break;
                    }


                    if (input == databaseCourseLitterature[i].GetStatus())
                    {
                        Console.WriteLine("Status of that book is already " + input);
                        numberoftimes++;
                        break;
                    }

                    if (input != databaseCourseLitterature[i].GetStatus())
                    
                    {
                        
                        
                        switch (input)
                        {
                            case "AVAILABLE":                                                                
                                databaseCourseLitterature[i].SetStatus(input);
                                numberoftimes++;
                                break;

                            case "ON LOAN":                                                               
                                databaseCourseLitterature[i].SetStatus(input);
                                numberoftimes++;
                                break;
                        }
                    }                                      
                }
            }
            if (numberoftimes == 0)
            {
                Console.WriteLine("That id either does not exist or the status of that book id can not be changed, try to change on a Book or a CourseLitterature instead");
            }

        }

        public void DeleteBook(int number)
        {
            int numberoftimes = 0;
            for (int i = 0; i < databaseBooks.Count; i++)
            {
                if (number == databaseBooks[i].GetBookId())
                {
                    databaseBooks.RemoveAt(i);
                    Console.WriteLine("Deleted id: " + number);
                    numberoftimes++;
                    break;
                }
            }

            for (int i = 0; i < databaseJournals.Count; i++)
            {           
            if (number == databaseJournals[i].GetBookId())
            {
                databaseJournals.RemoveAt(i);
                Console.WriteLine("Deleted id: " + number);
                numberoftimes++;
                break;
            }
        }
            for (int i = 0; i < databaseMagazines.Count; i++)
            {
                if (number == databaseMagazines[i].GetBookId())
                {
                    databaseMagazines.RemoveAt(i);
                    Console.WriteLine("Deleted id: " + number);
                    numberoftimes++;
                    break;
                }
            }
            for (int i = 0; i < databaseMagazines.Count; i++)
            {
                if (number == databaseCourseLitterature[i].GetBookId())
                {
                    databaseCourseLitterature.RemoveAt(i);
                    Console.WriteLine("Deleted id: " + number);
                    numberoftimes++;
                    break;
                }
            }


            
            if (numberoftimes == 0)
            {
                Console.WriteLine("That bookid does not exist");
            }
            
        }

        public void AddBook(int bookid, string title, string author, int year, string status)
        {
            databaseBooks.Add(new Book(bookid, title, author, year, status));
        }

        public void AddCourseLitterature(int bookid, string title, string author, int year, string status, string subject, string edition)
        {
            databaseCourseLitterature.Add(new CourseLitterature(bookid, title, author, year, status, subject, edition));
        }

        public void AddMagazine(int bookid, string title, string author, int year, string status, string genre,int number, string month)
        {
            databaseMagazines.Add(new Magazine(bookid, title, author, year, status, genre, number, month));
        }
        
        public void AddJournal(int bookid, string title, string author, int year, string status, int volume)
        {
            databaseJournals.Add(new Journal(bookid, title, author, year, status, volume));
        }



        public void SearchBoth(string titleorauthor)
        {

            int number = 0;
            for (int i = 0; i < databaseBooks.Count; i++)
            {
                if (databaseBooks[i].GetAuthor().Contains(titleorauthor) || databaseBooks[i].GetTitle().Contains(titleorauthor))
                {
                    Console.WriteLine("Title: " + databaseBooks[i].GetTitle() + ", Author: " + databaseBooks[i].GetAuthor() + ", Published: " + databaseBooks[i].GetYear() + ", Book Id: " + databaseBooks[i].GetBookId() + ", Status: " + databaseBooks[i].GetStatus());
                    number++;
                }
            }

            for (int i = 0; i < databaseJournals.Count; i++)
            {
                if (databaseJournals[i].GetAuthor().Contains(titleorauthor) || databaseJournals[i].GetTitle().Contains(titleorauthor))
                {
                    Console.WriteLine("Journal: Title: " + databaseJournals[i].GetTitle() + ", Editor in Chief: " + databaseJournals[i].GetAuthor() + ", Published: " + databaseJournals[i].GetYear() + ", Book Id: " + databaseJournals[i].GetBookId() + "Volume: " + databaseJournals[i].GetVolume());
                    number++;
                }
            }


            for (int i = 0; i < databaseMagazines.Count; i++)
            {
                if (databaseMagazines[i].GetAuthor().Contains(titleorauthor) || databaseMagazines[i].GetTitle().Contains(titleorauthor))
                {
                    Console.WriteLine("Magazine: Title: " + databaseMagazines[i].GetTitle() + ", Author: " + databaseMagazines[i].GetAuthor() + ", Published: " + databaseMagazines[i].GetYear() + ", Book Id: " + databaseMagazines[i].GetBookId()  + "Genre: " + databaseMagazines[i].GetGenre() + "Month: " + databaseMagazines[i].GetMonth() + "Number: " + databaseMagazines[i].GetNumber());
                    number++;
                }
            }
            for (int i = 0; i < databaseCourseLitterature.Count; i++)
            {
                if (databaseCourseLitterature[i].GetAuthor().Contains(titleorauthor) || databaseCourseLitterature[i].GetTitle().Contains(titleorauthor))
                {
                    Console.WriteLine("Course Litterature: Title: " + databaseCourseLitterature[i].GetTitle() + ", Author: " + databaseCourseLitterature[i].GetAuthor() + ", Published: " + databaseCourseLitterature[i].GetYear() + ", Book Id: " + databaseCourseLitterature[i].GetBookId()  + "Subject: " + databaseCourseLitterature[i].GetSubject() + "Edition " + databaseCourseLitterature[i].GetEdition());
                    number++;                
                }

            }

            if (number == 0)
            {
                Console.WriteLine("No matching books");
            }



                
            
        }

        public void View()
        {
            for (int i = 0; i < databaseBooks.Count; i++)
            {
                Console.WriteLine("Title: " + databaseBooks[i].GetTitle() + ", Author: " + databaseBooks[i].GetAuthor() + ", Published: " + databaseBooks[i].GetYear() + ", Book Id: " + databaseBooks[i].GetBookId()  + ", Status: " + databaseBooks[i].GetStatus());
            }

            for (int i = 0; i < databaseJournals.Count; i++)
            {
                Console.WriteLine("Journal: Title: " + databaseJournals[i].GetTitle() + ", Editor in Chief: " + databaseJournals[i].GetAuthor() + ", Published: " + databaseJournals[i].GetYear() + ", Book Id: " + databaseJournals[i].GetBookId() + ", Volume: " + databaseJournals[i].GetVolume());
            }
        

            for (int i = 0; i < databaseCourseLitterature.Count; i++)
            {
                Console.WriteLine("Course Litterature: Title: " + databaseCourseLitterature[i].GetTitle() + ", Author: " + databaseCourseLitterature[i].GetAuthor() + ", Published: " + databaseCourseLitterature[i].GetYear() + ", Book Id: " + databaseCourseLitterature[i].GetBookId() + ", Subject: " + databaseCourseLitterature[i].GetSubject() + ", Edition: " + databaseCourseLitterature[i].GetEdition());
            }

            for (int i = 0; i < databaseMagazines.Count; i++)
            {
                Console.WriteLine("Magazine: Title: " + databaseMagazines[i].GetTitle() + ", Author: " + databaseMagazines[i].GetAuthor() + ", Published: " + databaseMagazines[i].GetYear() + ", Book Id: " + databaseMagazines[i].GetBookId()  + ", Genre: " + databaseMagazines[i].GetGenre() + ", Month: " + databaseMagazines[i].GetMonth() + ", Number: " + databaseMagazines[i].GetNumber());
            }

            

            
        }

        public void Reserve(int number)
        {
            
                for (int i = 0; i < databaseBooks.Count; i++)
                {
                    if (number == databaseBooks[i].GetBookId())
                    {
                        if (databaseBooks[i].GetStatus() == "RESERVED")
                        {
                            Console.WriteLine("That book is already reserved!");
                            break;
                        }
                        else
                        {
                            databaseBooks[i].SetStatus("RESERVED");
                            Console.WriteLine("You have reserved " + databaseBooks[i].GetTitle() + ".");
                            break;
                        }
                    }
                }
               
            
            
        }

        public Book GetBook(int number)
        {
            for (int i = 0; i < databaseBooks.Count; i++)
            {
                if (number == databaseBooks[i].GetBookId())
                {
                    return databaseBooks[i];                   
                }
            }
            return null;
            
        }

        public int CheckValid(int number)
        {
            if (number <= databaseBooks.Count && number > 0)
            {
                for (int i = 0; i < databaseBooks.Count; i++)
                {
                    if (number == databaseBooks[i].GetBookId())
                    {
                        if (databaseBooks[i].GetStatus() == "RESERVED")
                        {
                            Console.WriteLine("That book is already reserved.");
                            Console.WriteLine("Make sure you tried to reserve a book");
                            return -1;
                            
                        }
                    }                    
                }
                return 1;
            }
            else
            {
                Console.WriteLine("Book id does not exist.");
                return -1;
            }
        }

        public int CheckBookId(int number)
        {
            for (int i = 0; i < databaseBooks.Count; i++)
            {
                if (databaseBooks[i].GetBookId() == number)
                {
                    Console.WriteLine("That book id already exists, try another");
                    return -1;
                }
            }
            return 1;
        }
    }
}
