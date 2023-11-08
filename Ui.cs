using System;
using System.Collections.Generic;
using System.Security.Cryptography;


public class Program
{

        static void Main(String[] args)
        {             

                Console.Clear(); //Clears the console screen
                Console.Title = "Tech Titans"; //sets the titel of the console window
                Console.ForegroundColor = ConsoleColor.Magenta; // sets the text color of foregrond color to magenta


                Console.WriteLine("\n\n----------Welcome to Tech Titans`s ATM App---------\n");
                Console.WriteLine("\nPleas enter you debit card...\n\n");
                Console.WriteLine("-----------------------------------------");
                string debitCardNum = "";
                CardHolder currentUser;
                DataLayer dataLayer = new DataLayer();// // Skapa en instans av DataLayer
                

                while (true)
                {
                try
                {
                        debitCardNum = Console.ReadLine() + "";
                        // Här kommer du åt myCardHolders från dataLayer-instansen
                        currentUser = dataLayer.myCardHolders.FirstOrDefault(a => a.CardNum == debitCardNum);
                        if (currentUser != null) { break; }
                        else { Console.WriteLine("Card not recognized. Please try again"); }
                }
                catch { Console.WriteLine("Card not recognized. Please try again"); }
                }

                Console.WriteLine("Pleas enter you pin: ");             
                int userPin = 0; 
                while (true)
                {
                        try
                        {
                        userPin = int.Parse(Console.ReadLine() + "");
                        if (currentUser.Pin == userPin) { break; }
                        else { Console.WriteLine("Incorrect pin. Pleas try again."); }
                        }
                        catch { Console.WriteLine("Incorrect pin. Pleas try again."); }
                }
        
                void printOptions() // denna borde vi flytta till Logic 
                {
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("Pleas choose from one of the following options...");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Whitdraw");
                Console.WriteLine("3. Show Balance");
                Console.WriteLine("4. Exit");
                Console.WriteLine("-------------------------------------------------");
                }
                        
                Console.WriteLine("\n-----Welcome " + currentUser.FirstName + " :) ------- ");
                int option = 0;
                do
                {
                printOptions();
                try
                {
                        option = int.Parse(Console.ReadLine() + "");
                }
                catch { option= 0; }
                if (option == 1) { currentUser.Deposit(currentUser); }
                else if (option == 2) { currentUser.Withdraw(currentUser); }
                else if (option == 3) { currentUser.balance(currentUser); }
                else if (option == 4) { break; }
                else { option = 0; } //för att vi vill att loopen ska börja om
                }
                while (option != 4); //för nr 4 är exit i menun
                Console.WriteLine("\n\nThank you! Have a nice day :)");


        

        }
}       





