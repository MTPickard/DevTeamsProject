using DeveloperPart;
using DevTeam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Console
{
    public class ProgramUI
    {

        //Fields
        private Developer_Repository _developerRepository = new Developer_Repository();

        private DevTeam_Repository _devTeamRepository = new DevTeam_Repository();

        //Run Method
        public void Run()
        {
            RunMenu();
        }

        //Menu
        public void RunMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine
                (
                    "Enter the number of your selection:\n" +
                    "1. Add a developer to directory.\n" +
                    "2. Add a team to directory.\n" +
                    "3. Add a developer to team.\n" +
                    "4. View all developers.\n" +
                    "5. View all teams.\n" +
                    "6. View developers that have access to Pluralsight\n" +
                    "7. Search developers by name.\n" +
                    "8. Search team by team ID.\n" +
                    "9. Search developer's by ID number\n" +
                    "10. Update information.\n" +
                    "11. Delete developer from directory.\n" +
                    "12. Exit.\n"
                );
                string userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "1":
                        CreateNewDeveloper();
                        break;
                    case "2":
                        AddTeam();
                        break;
                    case "3":
                        AddDeveloperToTeam();
                        break;
                    case "4":
                        ViewAllDevelopers();
                        break;
                    case "5":
                        ViewAllTeams();
                        break;                    
                    case "6":
                        HasAccess();
                        break;
                    case "7":
                        SearchDeveloperByName();
                        break;
                    case "8":
                        SearchTeamByID();
                        break;
                    case "9":
                        SearchDeveloperByID();
                        break;
                    case "10":
                        UpdateInformation();
                        break;
                    case "11":
                        Delete();
                        break;
                    case "12":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please choose a valid selection.\n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        break;
                }


            }
        }


        //Create

        //Add developer to directory
        private void CreateNewDeveloper()
        {
            Console.Clear();

            Developer newDeveloper = new Developer();
            
            {
                Console.WriteLine("Please enter the name of the developer.");
                newDeveloper.Name = Console.ReadLine();

                Console.WriteLine("Please enter the developer's ID Number");
                newDeveloper.IdNumber = int.Parse(Console.ReadLine());

                Console.WriteLine("Does developer have access to Pluralsight\n" +
                    "Enter the number cooresponding with response.\n" +
                    "1. Yes\n" +
                    "2. No\n");
                string response = Console.ReadLine();

                switch(response)
                {
                    case "1":
                        Console.Clear();
                        newDeveloper.Pluralsight = true;
                        Console.WriteLine("Developer now has access!");
                        PressAnyKeyToContinue();
                        break;
                    case "2":
                        Console.Clear();
                        newDeveloper.Pluralsight = false;
                        Console.WriteLine("Developer does NOT have access!");
                        PressAnyKeyToContinue();
                        break;
                }                
                _developerRepository.AddDeveloperToDirectory(newDeveloper);
            }


        }


        //Add Team to Directory
        private void AddTeam()
        {
            Console.Clear();

            DeveloperTeam newTeam = new DeveloperTeam();

            Console.WriteLine("Please enter the team name.");
            newTeam.NameOfTeam = Console.ReadLine();

            Console.WriteLine("Please enter the team ID.");
            newTeam.TeamID = int.Parse(Console.ReadLine());

            _devTeamRepository.AddTeamToDirectory(newTeam);


            PressAnyKeyToContinue();
        }

        //Add a Developer to Team
        private void AddDeveloperToTeam()
        {
            Console.Clear();

            List<Developer> developers = _developerRepository.ViewAllDevelopers();
            List<DeveloperTeam> devTeams = _devTeamRepository.ViewAllTeams();

            int indexTeam = 1;
            foreach (DeveloperTeam team in devTeams)
            {
                Console.WriteLine($"{indexTeam}. {team.NameOfTeam}");
                indexTeam++;
            }

            Console.WriteLine("Enter the number of the team you want to add the developer to:");
            int numberOfTeam = int.Parse(Console.ReadLine());
            int targetTeamNumber = numberOfTeam - 1;

            if (targetTeamNumber >= 0 && targetTeamNumber < devTeams.Count)
            {
                DeveloperTeam targetTeam = devTeams[targetTeamNumber];

                int indexDeveloper = 1;
                foreach (Developer developer in developers)

                {
                    Console.WriteLine($"{indexDeveloper}. {developer.Name}");
                    indexDeveloper++;
                }
                Console.WriteLine("Enter the number of the developer you want to add:");
                int number = int.Parse(Console.ReadLine());
                int targetNumber = number - 1;

                if (targetNumber >= 0 && targetNumber < developers.Count)
                {
                    Developer targetDeveloper = developers[targetNumber];
                    if (_devTeamRepository.AddMemberToTeam(targetDeveloper, targetTeam))
                    {
                        Console.WriteLine("Sucessfully added member!");
                    }
                }
                else
                {
                    Console.WriteLine("Enter a valid number");
                }
            }
        }

        //View All Teams
        private void ViewAllTeams()
        {
            Console.Clear();

            List<DeveloperTeam> teams = _devTeamRepository.ViewAllTeams();

            foreach (DeveloperTeam names in teams)
            {
                DisplayTeams(names);
            }
            PressAnyKeyToContinue();
        }

        //View all members


        //View All Developers
        private void ViewAllDevelopers()
        {
            Console.Clear();

            List<Developer> listOfDevelopers = _developerRepository.ViewAllDevelopers();

            foreach (Developer developer in listOfDevelopers)
            {
                DisplayDevelopers(developer);
            }
            PressAnyKeyToContinue();
        }

        //View Access to Pluralsight
        private void HasAccess()
        {
            Console.Clear();
            List<Developer> listOfDevs = _developerRepository.ViewAllDevelopers();
            Console.WriteLine("Which access level are you looking for?\n" +
                "Select number of cooresponding answer:\n" +
                "1. Access\n" +
                "2. No Access");
            string response = Console.ReadLine();

            switch (response)
            {
                case "1":
                    foreach (Developer developer in listOfDevs)
                        if (developer.Pluralsight == true)
                        {
                            DisplayDevelopers(developer);
                            PressAnyKeyToContinue();
                        }
                    break;
                case "2":
                     foreach(Developer developer in listOfDevs)
                        if (developer.Pluralsight == false)
                        {
                            DisplayDevelopers(developer);
                            PressAnyKeyToContinue();
                        }
                    break;
            }            
        }


        //Search Developers by Name
        private void SearchDeveloperByName()
        {
            Console.Clear();
            Console.WriteLine("What is developer's name?");
            string nameInput = Console.ReadLine();

            Developer name = _developerRepository.FindDeveloperByName(nameInput);

            if (name != null)
            {
                DisplayDevelopers(name);
            }
            else
            {
                Console.WriteLine("Sorry, not finding that developer in directory.");
            }

            PressAnyKeyToContinue();
        }

        //Search Team by ID
        private void SearchTeamByID()
        {
            Console.Clear();
            Console.WriteLine("What is the team's ID number?");
            int idNumber = int.Parse(Console.ReadLine());

            DeveloperTeam teamName = _devTeamRepository.FindTeamByID(idNumber);

            if (teamName != null)
            {
                DisplayTeams(teamName);
                Console.WriteLine("Do you want to view members of team?\n" +
                    "Choose number of cooresponding answer:\n" +
                    "1. Yes\n" +
                    "2. No\n");
                string response = Console.ReadLine();

                switch (response)
                {
                    case "1":
                        Console.WriteLine(teamName.TeamMember);
                        break;
                    case "2":
                        return;
                }
                
            }
            else
            {
                Console.WriteLine("Sorry, not finding that ID Number.");
            }

            PressAnyKeyToContinue();
        }

        //Search Developers by ID
        private void SearchDeveloperByID()
        {
            Console.Clear();
            Console.WriteLine("What is the developer's ID Number?");
            int idNumber = int.Parse(Console.ReadLine());

            Developer identify = _developerRepository.FindDeveloperByID(idNumber);

            if (identify != null)
            {
                DisplayDevelopers(identify);
            }
            else
            {
                Console.WriteLine("Sorry, not finding that ID Number.");
            }

            PressAnyKeyToContinue();
        }


        //Update Information About Developers
        private void UpdateInformation()
        {
            Console.Clear();

            Console.WriteLine("Find developer by Name or ID:\n" +
                "1. Name\n" +
                "2. ID\n");

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    Console.Clear();

                    Console.WriteLine("Enter the name of the developer:");
                    string nameEntered = Console.ReadLine();

                    Developer existingInformation = _developerRepository.FindDeveloperByName(nameEntered);
                    if (nameEntered == null)
                    {
                        Console.WriteLine("Sorry, we dont have a developer matching that name.");
                        PressAnyKeyToContinue();
                        return;
                    }

                    Developer newInformation = new Developer();

                    Console.WriteLine("Okay found the developer. Enter the number for what you want to update:\n" +
                        "1. Name\n" +
                        "2. Developer ID\n" +
                        "3. Access to PluralSight\n" +
                        "4. All Information\n");

                    string newUserInput = Console.ReadLine();

                    switch (newUserInput)
                    {
                        case "1":
                            Console.Clear();
                            Console.WriteLine($"Current name is {existingInformation.Name}\n" +
                                $"Please enter the new name.");
                            newInformation.Name = Console.ReadLine();
                            newInformation.IdNumber = existingInformation.IdNumber;
                            newInformation.Pluralsight = existingInformation.Pluralsight;
                            break;

                        case "2":
                            Console.Clear();
                            Console.WriteLine($"Current Developer ID is {existingInformation.IdNumber}\n" +
                                $"Please enter new ID number\n");
                            newInformation.Name = existingInformation.Name;
                            newInformation.IdNumber = int.Parse(Console.ReadLine());
                            newInformation.Pluralsight = existingInformation.Pluralsight;
                            break;

                        case "3":
                            Console.Clear();
                            Console.WriteLine($"Current developer access is {existingInformation.Pluralsight}\n" +
                                "Enter the number cooresponding with response.\n" +
                                "1. Yes\n" +
                                "2. No\n");
                            string responseOne = Console.ReadLine();

                            switch (responseOne)
                            {
                                case "1":
                                    Console.Clear();
                                    newInformation.Pluralsight = true;
                                    Console.WriteLine("Developer now has access!");
                                    PressAnyKeyToContinue();
                                    break;
                                case "2":
                                    Console.Clear();
                                    newInformation.Pluralsight = false;
                                    Console.WriteLine("Developer does NOT have access!");
                                    PressAnyKeyToContinue();
                                    break;
                            }
                            newInformation.Name = existingInformation.Name;
                            newInformation.IdNumber = existingInformation.IdNumber;
                            break;

                        case "4":
                            Console.Clear();
                            Console.WriteLine($"Current name is {existingInformation.Name}\n" +
                                $"Please enter the new name.");
                            newInformation.Name = Console.ReadLine();

                            Console.WriteLine();
                            Console.WriteLine($"Current Developer ID is {existingInformation.IdNumber}\n" +
                                $"Please enter new ID number\n");
                            newInformation.IdNumber = int.Parse(Console.ReadLine());

                            Console.WriteLine();
                            Console.WriteLine($"Current developer access is {existingInformation.Pluralsight}\n" +
                                "Enter the number cooresponding with response.\n" +
                                "1. Yes\n" +
                                "2. No\n");
                            string responseTwo = Console.ReadLine();

                            switch (responseTwo)
                            {
                                case "1":
                                    Console.Clear();
                                    newInformation.Pluralsight = true;
                                    Console.WriteLine("Developer now has access!");
                                    PressAnyKeyToContinue();
                                    break;
                                case "2":
                                    Console.Clear();
                                    newInformation.Pluralsight = false;
                                    Console.WriteLine("Developer does NOT have access!");
                                    PressAnyKeyToContinue();
                                    break;
                            }
                            break;

                        default:
                            Console.WriteLine("Please enter a valid selection.");
                            break;

                    }
                    if (_developerRepository.UpdateDevelopersInfo(existingInformation, newInformation))
                    {
                        Console.WriteLine("Update Successful");
                    }
                    else
                    {
                        Console.WriteLine("Update Failed");
                    }
                    break;

                case "2":
                    Console.Clear();

                    Console.WriteLine("Enter the deverloper's ID Number:");
                    int idEntered = int.Parse(Console.ReadLine());

                    Developer existingID = _developerRepository.FindDeveloperByID(idEntered);

                    if (_developerRepository.FindDeveloperByID(idEntered) != existingID)
                    {
                        Console.WriteLine("Sorry, we dont have a developer matching that ID Number.");
                        PressAnyKeyToContinue();
                        return;
                    }

                    Developer newID = new Developer();

                    Console.WriteLine("Okay found the developer. Enter the number for what you want to update:\n" +
                        "1. Name\n" +
                        "2. Developer ID\n" +
                        "3. Access to PluralSight\n" +
                        "4. All Information\n");

                    string userChoice = Console.ReadLine();

                    switch (userChoice)
                    {
                        case "1":
                            Console.Clear();
                            Console.WriteLine($"Current name is {existingID.Name}\n" +
                                $"Please enter the new name.");
                            newID.Name = Console.ReadLine();
                            newID.IdNumber = existingID.IdNumber;
                            newID.Pluralsight = existingID.Pluralsight;
                            break;

                        case "2":
                            Console.Clear();
                            Console.WriteLine($"Current Developer ID is {existingID.IdNumber}\n" +
                                $"Please enter new ID number\n");
                            newID.Name = existingID.Name;
                            newID.IdNumber = int.Parse(Console.ReadLine());
                            newID.Pluralsight = existingID.Pluralsight;
                            break;

                        case "3":
                            Console.Clear();
                            Console.WriteLine($"Current developer access is {existingID.Pluralsight}\n" +
                                "Enter the number cooresponding with response.\n" +
                                "1. Yes\n" +
                                "2. No\n");
                            string responseOne = Console.ReadLine();

                            switch (responseOne)
                            {
                                case "1":
                                    Console.Clear();
                                    newID.Pluralsight = true;
                                    Console.WriteLine("Developer now has access!");
                                    PressAnyKeyToContinue();
                                    break;
                                case "2":
                                    Console.Clear();
                                    newID.Pluralsight = false;
                                    Console.WriteLine("Developer does NOT have access!");
                                    PressAnyKeyToContinue();
                                    break;
                            }                            
                            newID.Name = existingID.Name;
                            newID.IdNumber = existingID.IdNumber;
                            break;

                        case "4":
                            Console.Clear();
                            Console.WriteLine($"Current name is {existingID.Name}\n" +
                                $"Please enter the new name.");
                            newID.Name = Console.ReadLine();

                            Console.WriteLine();
                            Console.WriteLine($"Current Developer ID is {existingID.IdNumber}\n" +
                                $"Please enter new ID number\n");
                            newID.IdNumber = int.Parse(Console.ReadLine());

                            Console.WriteLine();
                            Console.WriteLine($"Current developer access is {existingID.Pluralsight}\n" +
                                "Enter the number cooresponding with response.\n" +
                                "1. Yes\n" +
                                "2. No\n");
                            string responseTwo = Console.ReadLine();

                            switch (responseTwo)
                            {
                                case "1":
                                    Console.Clear();
                                    newID.Pluralsight = true;
                                    Console.WriteLine("Developer now has access!");
                                    PressAnyKeyToContinue();
                                    break;
                                case "2":
                                    Console.Clear();
                                    newID.Pluralsight = false;
                                    Console.WriteLine("Developer does NOT have access!");
                                    PressAnyKeyToContinue();
                                    break;
                            }
                            break;

                        default:
                            Console.WriteLine("Please enter a valid selection.");
                            break;
                    }
                    if (_developerRepository.UpdateDevelopersInfo(existingID, newID))
                    {
                        Console.WriteLine("Update Successful");
                    }
                    else
                    {
                        Console.WriteLine("Update Failed");
                    }
                    break;
            }
        }


        //Delete Developer
        private void Delete()
        {
            Console.Clear();

            List<Developer> devList = _developerRepository.ViewAllDevelopers();
            int index = 1;

            foreach (Developer developer in devList)
            {
                Console.WriteLine($"{index}. {developer}");
                index++;
            }

            Console.WriteLine("Enter the number by the developer you want to remove.");
            int numEntered = int.Parse(Console.ReadLine());
            int newNum = numEntered - 1;

            if (newNum >= 0 && newNum < devList.Count)
            {
                Developer targetDeveloper = devList[newNum];

                if (_developerRepository.DeletingDeveloper(targetDeveloper))
                {
                    Console.WriteLine($"{targetDeveloper} was successfully deleted");
                }
                else
                {
                    Console.WriteLine("An error occured.");
                }
            }
            else
            {
                Console.WriteLine("Please enter valid number");
            }

            PressAnyKeyToContinue();

        }

        //Helper Methods    
        public void DisplayDevelopers(Developer information)
        {
            Console.WriteLine(
                $"Name:{information.Name}\n" +
                $"ID Number: {information.IdNumber}\n" +
                $"Puralsight Acess: {information.Pluralsight}\n");
        }

        public void DisplayTeams(DeveloperTeam team)
        {
            Console.WriteLine(
                $"Name: {team.NameOfTeam}\n" +
                $"Team ID: {team.TeamID}");
        }

        public void PressAnyKeyToContinue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }


        
    }
}
