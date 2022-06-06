using System;
using System.Collections.Generic;
using System.Text;

namespace Inlämningsuppgift
{
    class Magazine : Book
    {
        private string genre;
        private string month;
        private int number;

        public Magazine (int bookid, string title, string author, int year, string status, string genre, int number, string month) : base (bookid, title, author, year, status)
        {
            this.genre = genre;
            this.month = month;
            this.number = number;

        }

        public string GetGenre()
        {
            return genre;
        }

        public string GetMonth()
        {
            return month;
        }

        public int GetNumber()
        {
            return number;
        }
    }


}
