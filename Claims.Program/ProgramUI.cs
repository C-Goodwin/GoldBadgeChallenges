using Claims.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims.Program
{
    class ProgramUI
    {
        public void Run()
        {
            var instance = new ClaimsRepo();
            instance.SeedContentList();
            Menu();
        }
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Hello Komodo Insurance claims agent.\n" +
                    " Please select one of the folowing options:\n" +
                    "1.View a list fo the current claims\n" +
                    "2.View and interact with the foremost claim\n" +
                    "3.Input a new claim\n" +
                    "4.Exit the application");
                string menuOption = Console.ReadLine();
                switch (menuOption)
                {
                    case "1":
                        ShowClaimList();
                        break;
                    case "2":
                        ForemostClaim();
                        break;
                    case "3":
                        InputNewClaim();
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

        public void ShowClaimList()
        {
            ClaimsRepo.ShowTable(ClaimsRepo.InsuranceClaimsDT());
        }
        public void ForemostClaim()
        {
            Console.Clear();
            Claim nextClaim = ClaimsRepo.GetAllClaims().Peek();
            Console.WriteLine("\n" + "Here are the details of the next claim to be handled:\n" +
                $"Claim ID: {nextClaim.ClaimID}\n" +
                $"Claim Type: {nextClaim.ClaimType}\n" +
                $"Description: {nextClaim.Description}\n" +
                $"Claim Amount: {nextClaim.ClaimAmount}\n" +
                $"Date of Incident:{nextClaim.DateOfIncident}\n" +
                $"Date of Claim: {nextClaim.DateOfClaim}\n" +
                $"Is it Valid: {nextClaim.IsValid}\n" +
                $"Do you want to deal with this claim now (y/n)?");
            string input = Console.ReadLine().ToLower(); ;
            if (input == "y")
            {
                ClaimsRepo._claimsList.Dequeue();
            }
            else if (input == "n")
            {
                Console.Clear();
                Menu();
            }
            else
            {
                Console.WriteLine("Please input a valid response.");
            }
        }
        public void InputNewClaim()
        {
            Console.Clear();
            Claim newClaim = new Claim();
            Console.WriteLine("Please input the Claim ID for this claim:");
            newClaim.ClaimID = int.Parse(Console.ReadLine());
            Console.WriteLine("Input the number associated with claim type:\n" +
                "1.Car\n" +
                "2.Home\n" +
                "3.Theft");
            string claimType = Console.ReadLine();
            if (claimType == "1")
            {
                newClaim.ClaimType = ClaimType.Car;
            }
            else if (claimType == "2")
            {
                newClaim.ClaimType = ClaimType.Home;
            }
            else if (claimType == "3")
            {
                newClaim.ClaimType = ClaimType.Theft;
            }
            else
            {
                Console.WriteLine("Please input a vaild input.");
                Console.WriteLine("Returning you to the main menu.Hit enter to continue.");
                Console.ReadKey();
                Console.Clear();
                Menu();
            }
            Console.WriteLine("Please give this claim a description:");
            newClaim.Description = Console.ReadLine();
            Console.WriteLine("Please input the amount of damage:\n" +
                "Do not input a '$',  numbers only. ");
            newClaim.ClaimAmount = double.Parse(Console.ReadLine());
            Console.WriteLine("Input the date the accident occured:\n" +
                "(Use the following layout 'mm/dd/yy' )");
            newClaim.DateOfIncident = Console.ReadLine();
            Console.WriteLine("Input the date the claim was made:\n" +
                "(Use the following layout 'mm/dd/yy' )");
            newClaim.DateOfClaim = Console.ReadLine();
            Console.WriteLine("Is this claim valid? (y/n)");
            string isValid = Console.ReadLine().ToLower();
            if (isValid == "y")
            {
                newClaim.IsValid = true;
            }
            else if (isValid == "n")
            {
                newClaim.IsValid = false;
            }
            else
            {
                Console.WriteLine("Please input a vaild input.");
                Console.WriteLine("Returning you to the main menu.Hit enter to continue.");
                Console.ReadKey();
                Console.Clear();
                Menu();
            }
            ClaimsRepo.AddClaimToList(newClaim);
        }
    }
}
