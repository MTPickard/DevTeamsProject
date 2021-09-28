using DeveloperPart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeam
{
    public class DeveloperTeam
    {
        //Constructors
        public DeveloperTeam() { }

        public DeveloperTeam(string nameOfTeam, int teamID, List<Developer> teamMember) 
        {
            NameOfTeam = nameOfTeam;
            TeamID = teamID;
            TeamMember = teamMember;
        }

        //Properties
        public string NameOfTeam { get; set; }
        public int TeamID { get; set; }
        public List<Developer> TeamMember { get; set; } = new List<Developer>();
    }

}   
