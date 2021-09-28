using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer
{
    public class Developer
    {
        //Constructors
        public Developer() { }

        public Developer(string name, int idNumber, bool pluralsight)
        {
            Name = name;
            IdNumber = idNumber;
            Pluralsight = pluralsight;
        }

        //Properties
        public string Name { get; set; }
        public int IdNumber { get; set; }
        public bool Pluralsight { get; set; }
    }


    
}
