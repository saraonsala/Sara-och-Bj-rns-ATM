using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;


public class CardHolder
{
    // fixa så att den skriver ut sek: Sara Klar
    // fixa så att man kan transfer pengar: Sara 
    // fixa så att kortet spärras efter tre försök: Björn 
    // fixa stavfel: Björn 
    // Användaren ska kunna ändra sin pin 
    // När användaren tar ut pengar så så ska det vara en fördröjning på några sek med texten "Loding" 
    /// Ladda bankomaten med pengar 
    /// Ändra alla varingstexter till röd och ändra till
        
    // Lägga alla delar rätt som tex listan/databasen i UI  
    public string CardNum { get; private set; }
    public int Pin { get; set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    private double balance;

    public double Balance
    {
        get
        {
            return balance;
        }
        private set
        {
            balance = value;
        }
    }



    public CardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        CardNum = cardNum;
        Pin = pin;
        FirstName = firstName;
        LastName = lastName;
        Balance = balance;
    }
    
    public static void Main(String[] args)
    {
        Console.Clear(); //Clears the console screen
        Console.Title = "Tech Titans"; //sets the titel of the console window
        Console.ForegroundColor = ConsoleColor.Magenta; // sets the text color of foregrond color to magenta

        void mainMenu()
    {
        Console.WriteLine("\n\n----------Welcome to Tech Titans`s ATM App---------\n");
        Console.WriteLine("\nPleas enter you debit card...\n\n");
        Console.WriteLine("-----------------------------------------");
    }
    mainMenu();

    


        void printOptions()
    {
        System.Console.WriteLine("-------------------------------------------------");
        System.Console.WriteLine("Pleas choose from one of the following options...");
        System.Console.WriteLine("1. Deposit");
        System.Console.WriteLine("2. Whitdraw");
        System.Console.WriteLine("3. Show Balance");
        System.Console.WriteLine("4. Exit");
        System.Console.WriteLine("-------------------------------------------------");
    }

    public static void Main(String[] args)
    {
        Console.Clear(); //Clears the console screen
        Console.Title = "Tech Titans"; //sets the titel of the console window
        Console.ForegroundColor = ConsoleColor.Magenta; // sets the text color of foregrond color to magenta

        mainMenu();






        void deposit(CardHolder currentUser)
        {
            Console.WriteLine("How mutch $$ would you like to deposit: ? ");
            double deposit = Double.Parse(Console.ReadLine() + "");
            currentUser.Balance += deposit; // Använd Balance-egenskapen.
            Console.WriteLine($"Thank you for your $$. Your new balance is: {currentUser.Balance:C}"); 
        }

        void withdraw(CardHolder currentUser)
        {
            Console.WriteLine("How mutch $$ would you like to withdraw: ? ");
            double withdrawal = Double.Parse(Console.ReadLine() + "");
            //Check if the user has enough money
            if (currentUser.Balance < withdrawal)
            {
                Console.WriteLine("Insufficient balance :");
            }
            else
            {
                currentUser.Balance -= withdrawal; // Använd Balance-egenskapen.
                Console.WriteLine($"You're good to go! Thank you. Your new balance is: {currentUser.Balance:C}");
            }
        }

         void balance(CardHolder currentUser)
        {
            Console.WriteLine($"Current balance: {currentUser.Balance:C}"); //.ToString("C2", new System.Globalization.CultureInfo("sv-SE")));
        }


        List<CardHolder> cardHolderList = new List<CardHolder>();
        cardHolderList.Add(new CardHolder("566559515251", 5678, "Victoria", "Mellgren", 36555.45));
        cardHolderList.Add(new CardHolder("123456789101", 1234, "Sara", "Mellgren", 236555.35));
        cardHolderList.Add(new CardHolder("259959515253", 6894, "Felica", "Mellgren", 655.56));
        cardHolderList.Add(new CardHolder("256459515254", 1278, "Stefan", "Mellgren", 40555.55));
        cardHolderList.Add(new CardHolder("256459515695", 5678, "Snobben", "Mellgren", 5.34));
        cardHolderList.Add(new CardHolder("256459695256", 3678, "Ingela", "Mellgren", 8900.55));
        cardHolderList.Add(new CardHolder("256579515257", 4068, "Kerstin", "Rundqvist", 557155.25));
        cardHolderList.Add(new CardHolder("111", 1234, "Björn", "Lagerblad", 178555.55));

        //promet user
        
    
        string debitCardNum = "";
        CardHolder currentUser;
        
        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine() + "";
                //check aginst our db. FirstOrDefault söker av db=databasen och retunerar hela objektet
                currentUser = cardHolderList.FirstOrDefault(a => a.CardNum == debitCardNum);
                if (currentUser != null) { break; } // denna visa 
                else { Console.WriteLine("Card not recognized. Pleas try again"); }
            }
            catch{ Console.WriteLine("Card not recognized. Pleas try again"); }
        }

        Console.WriteLine("Pleas enter you pin: ");
        int attemptsRemaining = 3;
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine() + "");
                if (currentUser.Pin == userPin) { break; }
                else
                { 
                    attemptsRemaining--;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Incorrect pin. Pleas try again. Attempts remaining:{attemptsRemaining}");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    if (attemptsRemaining == 0)
                    {      
                        System.Console.WriteLine("För många felaktiga försök. Ditt kort är nu spärrat");
                        cardHolderList.Remove(currentUser);
                        break;
    
                        
                    }
                }
            }

            catch{ Console.WriteLine("Incorrect pin. Pleas try again."); }
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
            if (option == 1) { deposit(currentUser); }
            else if (option == 2) { withdraw(currentUser); }
            else if (option == 3) { balance(currentUser); }
            else if (option == 4) {   }
            else { option = 0; } //för att vi vill att loopen ska börja om
        }
        while (option != 4); //för nr 4 är exit i menun
        Console.WriteLine("\n\nThank you! Have a nice day :)"); 
        mainMenu();



    }

}




