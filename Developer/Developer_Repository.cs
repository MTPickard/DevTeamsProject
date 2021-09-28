using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPart
{
    public class Developer_Repository
    {
        //Repository Patter: CRUD

        //Field

        private readonly List<Developer> _developerDirectory = new List<Developer>();

        //CREATE
        public bool AddDeveloperToDirectory(Developer developer)
        {
            int startingCount = _developerDirectory.Count;
            _developerDirectory.Add(developer);
            bool wasAdded = (_developerDirectory.Count > startingCount);
            if (wasAdded)
            {
                Console.WriteLine("Successfully added!\n");
            }
            return wasAdded;
        }

        

        //READ
        public List<Developer> ViewAllDevelopers()
        {
            return _developerDirectory;
        }

        public Developer FindDeveloperByName(string developerName)
        {
            foreach (Developer name in _developerDirectory)
            {
                if (name.Name.ToLower() == developerName.ToLower())
                {
                    return name;
                }
            }
            return null;
        }

        public Developer FindDeveloperByID(int developerID)
        {
            foreach (Developer ID in _developerDirectory)
            {
                if (ID.IdNumber == developerID)
                {
                    return ID;
                }
            }
            return null;
        }

        //UPDATE
        public bool UpdateDevelopersInfo(Developer currentInformation, Developer newInformation)
        {
            if (currentInformation != null)
            {
                currentInformation.Name = newInformation.Name;
                currentInformation.IdNumber = newInformation.IdNumber;
                currentInformation.Pluralsight = newInformation.Pluralsight;
                return true;
            }
            else
            {
                return false;
            }
        }

        //DELETE
        public bool DeletingDeveloper(Developer existingDeveloper)
        {
            bool remove = _developerDirectory.Remove(existingDeveloper);
            return remove;
        }
    }
}
