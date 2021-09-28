using DeveloperPart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeam
{
    public class DevTeam_Repository
    {
        //Field
        private List<DeveloperTeam> _developerTeam = new List<DeveloperTeam>();
        private List<DeveloperTeam> _membersOfTeams = new List<DeveloperTeam>();
        

        //CREATE
        public bool AddMemberToTeam(Developer member, DeveloperTeam developerTeam)
        {
            int startingCount = developerTeam.TeamMember.Count;
            developerTeam.TeamMember.Add(member);
            bool wasAdded = (developerTeam.TeamMember.Count > startingCount);
            if (wasAdded)
            {
                Console.WriteLine("Successfully added!");
            }
            return wasAdded;
        }

        public bool AddTeamToDirectory(DeveloperTeam team)
        {
            int startingCount = _developerTeam.Count;
            _developerTeam.Add(team);
            bool wasAdded = (_developerTeam.Count> startingCount);
            if (wasAdded)
            {
                Console.WriteLine("Successfully added team!\n");
            }
            return wasAdded;
        }


        //READ

        public List<DeveloperTeam> ViewAllTeams()
        {
            return _developerTeam;
        }

        public DeveloperTeam FindTeamByID(int teamID)
        {
            foreach (DeveloperTeam ID in _developerTeam)
            {
                if (ID.TeamID == teamID)
                {
                    return ID;
                }
            }
            return null;
        }






    }
}
