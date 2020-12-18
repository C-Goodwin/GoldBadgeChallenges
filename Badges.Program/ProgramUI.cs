using Badges.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges.Program
{
    class ProgramUI
    {
        public void Run()
        {
            SeedContentList();
            Menu();
        }
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Hello Komodo Security Admin.\n" +
                    " Please select one of the folowing options:\n" +
                    "1.Add a badge to the list of badges\n" +
                    "2.Edit the information of a badge\n" +
                    "3.View a list all badges\n" +
                    "4.Exit the application");
                string menuOption = Console.ReadLine();
                switch (menuOption)
                {
                    case "1":
                        AddABadge();
                        break;
                    case "2":
                        UpdateABadge();
                        break;
                    case "3":
                        ViewBadges();
                        break;
                    case "4":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please input a valid option.");
                        break;
                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public void AddABadge()
        {
            Console.Clear();
            Badge newBadge = new Badge();
            Console.WriteLine("Please input the Badge ID for this Badge");
            newBadge.BadgeID = int.Parse(Console.ReadLine());
            Console.WriteLine("Input a door that this badge needs access to:");
            newBadge.DoorNames.Add(Console.ReadLine().ToUpper());
            bool anyOtherDoors = true;
            while (anyOtherDoors)
            {
                Console.WriteLine("Are there any other doors that this badge needs access to (y/n):");
                if (Console.ReadLine().ToLower() == "n")
                {
                    anyOtherDoors = false;
                }
                else if (Console.ReadLine().ToLower() == "y")
                {
                    Console.WriteLine("Input a door that this badge needs access to:");
                    newBadge.DoorNames.Add(Console.ReadLine().ToUpper());
                }
            }
            BadgesRepo.CreateBadge(newBadge.BadgeID, newBadge);
        }
        public void UpdateABadge()
        {
            Console.Clear();
            Console.WriteLine("What is the Badge ID of the badge you would like to change:");
            int id = int.Parse(Console.ReadLine());
            Badge badge = BadgesRepo.GetBadgeByIDNumber(id);
            if (badge != null)
            {
                Console.WriteLine($"{badge.BadgeID} has access to doors{badge.DoorNames}\n" +
                    $"What would you like to do:\n" +
                    $"1.Remove a door from this badge\n" +
                    $"2.Add a door to this badge\n" +
                    $"3.Go to the main menu");
                int updateInput = int.Parse(Console.ReadLine());
                if (updateInput == 1)
                {
                    Console.WriteLine("Which door would you like to remove:");
                    string removeInput = Console.ReadLine().ToLower();
                    bool removed = BadgesRepo.RemoveDoorFromBadge(id, removeInput);
                    if (removed == true)
                    {
                        Console.Clear();
                        Console.WriteLine($"The door was removed from the badge\n" +
                            $"{badge.BadgeID} now has access to doors{badge.DoorNames}\n" +
                            $"Hit enter to return to the main menu");
                        Console.ReadKey();
                        Menu();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("The program was unable to remove the requested door\n" +
                            "Hit enter to return to the main menu");
                        Console.ReadKey();
                        Menu();
                    }
                }
                else if (updateInput == 2)
                {
                    Console.WriteLine("Please input the name of the door you would like to add to this badge:");
                    bool added = BadgesRepo.UpdateADoor(id, Console.ReadLine().ToUpper());
                    if (added == true)
                    {
                        Console.Clear();
                        Console.WriteLine($"The door was added to the badge\n" +
                            $"{badge.BadgeID} now has access to doors{badge.DoorNames}\n" +
                            $"Hit enter to return to the main menu");
                        Console.ReadKey();
                        Menu();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("The program was unable to add the requested door\n" +
                            "Hit enter to return to the main menu");
                        Console.ReadKey();
                        Menu();
                    }

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Returning you to the main menu, please hit enter.");
                    Console.ReadKey();
                    Menu();
                }
            }

        }
        public void ViewBadges()
        {
            BadgesRepo.ViewBadgeInfo();
            BadgesRepo._badgeDict.Select(_badgesDict => $"{_badgesDict.Key}: {_badgesDict.Value}").ToList().ForEach(Console.WriteLine);
        }
        public void SeedContentList()
        {
            List<string> doors = new List<string> { "B59", "G03", "T4" };
            Badge a = new Badge(64890, doors);
            Badge b = new Badge(92568, doors);
            Badge c = new Badge(75643, doors);

        }
    }
}
