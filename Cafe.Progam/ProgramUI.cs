using Cafe.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Progam
{
    class ProgramUI
    {
        private CafeRepo _menuRepo = new CafeRepo();

        public void Run()
        {
            MenuForCafeApp();
        }
        private void MenuForCafeApp()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Welcome to the Komodo Cafe Menu Editor.\n" +
                    "Please select one of the following options:\n" +
                    "1.Create a new menu item\n" +
                    "2.Remove a current menu item\n" +
                    "3.Display a list of the current menu options\n" +
                    "4.Display more information about a specific item\n" +
                    "5. Exit the application");
                string menuOption = Console.ReadLine();
                switch (menuOption)
                {
                    case "1":
                        CreateMenuItem();
                        break;
                    case "2":
                        RemoveMenuItem();
                        break;
                    case "3":
                        DisplayMenuItems();
                        break;
                    case "4":
                        DisplayMenuItemByNumber();
                        break;
                    case "5":
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
        private void CreateMenuItem()
        {
            Console.Clear();
            Menu newItem = new Menu();
            Console.WriteLine("Please input the number you would like to use for this item:");
            newItem.MealNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Input the name you would like to use for this item:");
            newItem.MealName = Console.ReadLine();
            Console.WriteLine("Please give this item a description:");
            newItem.Description = Console.ReadLine();
            Console.WriteLine("Please input the ingredients this item contains:\n" +
                "Seperate each item with a ',' ");
            var line = Console.ReadLine();
            string[] ingredientsArr = line.Split(',');
            List<string> ingredientsList = new List<string>(ingredientsArr);
            newItem.Ingredients = ingredientsList;
            Console.WriteLine("Input a price for this item:\n" +
                "(Does not need a $, Example: 2.99");
            newItem.Price = double.Parse(Console.ReadLine());
            _menuRepo.AddNewMenuItem(newItem);
        }
        private void RemoveMenuItem()
        {
            Console.Clear();
            DisplayMenuItems();
            Console.WriteLine("\nEnter the number of the item you would like to remove:");
            int input = int.Parse(Console.ReadLine());
            bool wasDeleted = _menuRepo.RemoveMenuItem(input);
            if(wasDeleted)
            {
                Console.WriteLine("The item was successfully removed.");
            }
            else
            {
                Console.WriteLine("The item could not be removed.");
            }
        }
        private void DisplayMenuItems()
        {
            Console.Clear();
            List<Menu> listOfItems = _menuRepo.GetMenuItems();
            foreach (Menu item in listOfItems)
            {
                Console.WriteLine($"\nName:{item.MealName}\n Description:{item.Description}\n");
            }
            Console.ReadKey();
        }
        private void DisplayMenuItemByNumber()
        {
            Console.Clear();
            Console.WriteLine("Please input the number of the item you would like to view:");
            int menuNum = int.Parse(Console.ReadLine());
            Menu item = _menuRepo.GetMenuItemByNumber(menuNum);
            if(item != null)
            {
                Console.WriteLine($"Number:{item.MealNumber}\n" +
                    $"Name:{item.MealName}\n" +
                    $"Description:{item.Description}\n" +
                    $"Ingredients:{item.Ingredients}\n" +
                    $"Price: ${item.Price}");
            }
            else
            {
                Console.WriteLine("There is no menu item with that number.");
            }
            Console.ReadKey();
        }
    }
}
