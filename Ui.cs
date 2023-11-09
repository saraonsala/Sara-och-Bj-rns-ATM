using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

public class Program
{

        static void Main(String[] args)
        {             

                Console.Clear(); //Clears the console screen
                Console.Title = "Tech Titans"; //sets the titel of the console window
                Console.ForegroundColor = ConsoleColor.Magenta; // sets the text color of foregrond color to magenta
                string debitCardNum = "";
                CardHolder currentUser;
                DataLayer dataLayer = new DataLayer();// // Skapa en instans av DataLayer

                void mainMenu()
                {
                        Console.WriteLine("\n\n----------Welcome to Tech Titans`s ATM App---------\n");
                        Console.WriteLine("\nPleas enter you debit card...\n\n");
                        Console.WriteLine("-----------------------------------------");

                }
        mainMenu();
                while (true)
                {
                try
                {
                        debitCardNum = Console.ReadLine() + "";
                        // Här kommer du åt myCardHolders från dataLayer-instansen
                        currentUser = dataLayer.myCardHolders.FirstOrDefault(a => a.CardNum == debitCardNum);
                        Console.ForegroundColor = ConsoleColor.Red; // sets the text color of foregrond color to red
                        if (currentUser != null) { break; }
              
                        else { Console.WriteLine("Card not recognized. Please try again"); }
                }
                catch { Console.WriteLine("Card not recognized. Please try again"); }
                }

                Console.ForegroundColor = ConsoleColor.Magenta; // sets the text color of foregrond color to magenta
                Console.WriteLine("Pleas enter you pin: ");             
                int userPin = 0; 
                while (true)
                {       
                        
                        try
                        {
                        userPin = int.Parse(Console.ReadLine() + "");
                        Console.ForegroundColor = ConsoleColor.Red; // sets the text color of foregrond color to red
                        if (currentUser.Pin == userPin) { break; }
                        else { Console.WriteLine("Incorrect pin. Pleas try again."); }
                        }
                        catch { Console.WriteLine("Incorrect pin. Pleas try again."); }
                        
                }

                Console.ForegroundColor = ConsoleColor.Magenta; // sets the text color of foregrond color to magenta

                void PrintOptions()
                {
                    Console.WriteLine("-------------------------------------------------");
                    Console.WriteLine("Please choose from one of the following options...");
                    Console.WriteLine("1. Deposit");
                    Console.WriteLine("2. Withdraw");
                    Console.WriteLine("3. Show Balance");
                    Console.WriteLine("4. Exit");
                    Console.WriteLine("-------------------------------------------------");
                }

                Console.WriteLine("\n\n-----Welcome " + currentUser.FirstName + " :) -------\n\n");
                int option = 0;
                do
                {
                    PrintOptions();
                    try
                    {
                        option = int.Parse(Console.ReadLine() + "");
                    }
                    catch { option = 0; }
                    if (option == 1) { currentUser.Deposit(currentUser); }
                    else if (option == 2) { currentUser.Withdraw(currentUser); }
                    else if (option == 3) { currentUser.balance(currentUser); }
                    else if (option == 4) {System.Console.WriteLine("TESTTEST");}
                    else if (option == 9) { break; }
                } while (option != 0); // exit menu 
                Console.WriteLine("\n\nThank you! Have a nice day :)");


        

        }
    
}
