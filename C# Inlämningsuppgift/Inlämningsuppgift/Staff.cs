using System;
using System.Collections.Generic;
using System.Text;

namespace Inlämningsuppgift
{
    class Staff
    {
        static int nextstaffid = 1;
        private int staffid;
        private string staffname;
        private string password;
        

        public Staff(string staffname, string password)
        {
            staffid = nextstaffid;
            this.staffname = staffname;
            this.password = password;
            nextstaffid++;
            
            
        }

        public int GetStaffId()
        {
            return staffid;
        }

        public string GetName()
        {
            return staffname;
        }

        public string GetPassword()
        {
            return password;
        }
    }
}
