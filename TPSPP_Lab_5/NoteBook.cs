using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPSPP_Lab_5
{
    public class NoteBook
    {  
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateBorn { get; set; } 
        public string NumberPhone { get; set; }
        public string Email { get; set; }

        public NoteBook(string firstName, string lastName, DateTime dateBorn, string numberPhone, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            DateBorn = dateBorn;
            NumberPhone = numberPhone;
            Email = email;
        }
        public NoteBook(int i)
        {
            FirstName = "Unknown first name[" + i +"]";
            LastName = "Unknown last name[" + i + "]";
            DateBorn = DateTime.Now;
            NumberPhone = "+xxxxxxxxxxxx";
            Email = "YourEmail" + "[" + i +"]" + "@unknown"; 
        }
    }
}
