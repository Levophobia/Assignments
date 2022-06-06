using System;
using System.Collections.Generic;
using System.Text;

namespace Inlämningsuppgift
{
    class Journal : Book
    {
        private int volume;

        public Journal(int bookid, string title, string author, int year, string status, int volume) : base (bookid, title, author, year, status)
        {
            this.volume = volume;
        } 

        public int GetVolume()
        {
            return volume;
        }
    }
}
