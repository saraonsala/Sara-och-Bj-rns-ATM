using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
  
public class CardHolder //Klassen för kortanvändare
{ 
    AtmMachine atm = new AtmMachine(); // Instansierar ett objekt av klassen DataLayer i och med ordet new
    public List<Transaction> TransactionHistory { get; set; } = new List<Transaction>(); // Lista för användarens kontoutdrag.

    public string CardNum { get; set; }
    public int Pin { get; set; }
    public string FirstName { get; set; }
    public string LastName { get;  set; }
    public double Balance { get; set; }
    public int WrongPinAttempts { get; set; } 

    public CardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        CardNum = cardNum;
        Pin = pin;
        FirstName = firstName;
        LastName = lastName;
        Balance = balance;
        WrongPinAttempts = 0; //startar med värdet 0 och räknar uppåt
    }      
    public void Deposit(CardHolder currentUser) //Insättning av pengar, kodblock stämmer av med aktuellt saldo samt lägger till transaktionen i listan TransactionHistory. 
    {
        Console.WriteLine($"\n\nHow much money would you like to deposit?\n\n");
        double deposit = Double.Parse(Console.ReadLine() + "");
        currentUser.Balance += deposit; // Använd Balance-egenskapen.
        Ui.PrintYellowThenMagenta($"\n\nThank you for your deposit. Your new balance is: {currentUser.Balance:C}\n\n"); 
        TransactionHistory.Add(new Transaction("Deposit", deposit));
    }

    public void Withdraw(CardHolder currentUser)//Utag av pengar, kodblock stämmer av med aktuellt saldo samt lägger till transaktionen i listan TransactionHistory. 
    {
        Console.WriteLine("\n\nHow much money would you like to withdraw?\n\n\n");
        double withdrawal = Double.Parse(Console.ReadLine()+("\n\n")+"");
        
        
        if (currentUser.Balance < withdrawal) // Är balance minde än withdrawal
        {   
            Ui.PrintRedThenMagenta($"\n\nInsufficient balance.Your balance is {currentUser.Balance:C}\n\n");
        }
        else if (atm.AtmAmount < withdrawal) // Om själva ATM maskinen har mindre pengar än vad användaren vill ta ut.
        {   
            Ui.PrintRedThenMagenta($"\n\nATM out of cash.Support 0771-666 666.\n\n");
        }                            
        else
        {
            currentUser.Balance -= withdrawal; // Uppdaterar saldot på användarens konto med summan som har tagits ut.  
            Console.WriteLine("Loading");
            Ui.PrintDotAnimation(); //Animation för att visa att ATM räknar upp de fysiska pengarna.
            Ui.PrintYellowThenMagenta($"\n\nYou're good to go! Thank you. Your new balance is: {currentUser.Balance:C}\n\n"); // Skriver ut användarens aktuella saldo.
            atm.AtmAmount -= withdrawal; // Uppdaterar ATMamount(pengar i maskinen) med hur mycket som har tagits ut
            TransactionHistory.Add(new Transaction("Withdrawal", withdrawal));        
        }
    }

    public void balance(CardHolder currentUser)//Visar användarens saldo i consolen.
    {   
        Ui.PrintYellowThenMagenta($"\n\nCurrent balance: {currentUser.Balance:C}\n\n"); //:C för currency, automatiskt lägger in vad du har för valuta beroende på dina dators regions inställningar.
    }
    public bool IsCardLocked()//Den kollar om kortet är inte är spärrat. 
    {
        return WrongPinAttempts >= 3; // om pin är 3 eller under
    }

    public void IncreaseWrongPinAttempts()
    {
        WrongPinAttempts++; // Vid fel pinkods input så ökas antal fel försök med ett.
    }
    public static void DisplayTransactionHistory(CardHolder currentUser)// Den skriver ut transaktionshistoriken för användarens kort.
    {
        Console.WriteLine("\n\nTransaction History:\n\n");
        foreach (var transaction in currentUser.TransactionHistory)
        {
            Ui.PrintYellowThenMagenta($"{transaction.Timestamp} - {transaction.Type}: {transaction.Amount:C}");
        }
    }    
    public void ChangePin()//Ändra pin
    {   
        Console.WriteLine("\n\nPlease enter you current PIN:\n\n");
        int currentPin;
        
        while(true)//Om sant 
        {
            
            try // try/catch om input inte skulle stämma
            {
                currentPin = int.Parse(Console.ReadLine()+ "");
            
                if (currentPin == Pin)//Kontrollerar att nuvarande pinkod är korrekt.
                { 
                    Console.WriteLine("\n\nPlease enter you new PIN:\n\n");
                    int newPin = int.Parse(Console.ReadLine()+""); 
                    Pin = newPin; //Ändrar till den nya pinkoden.
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n\nPIN succesfully changed!\n\n");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                }
                else
                {
                    Ui.PrintRedThenMagenta("\n\nIncorrect PIN. Try again!\n\n");
                }   
            }     
            catch // fångar ifall input inte är samma som PIN
            {
                Ui.PrintRedThenMagenta("\n\nIncorrect PIN. Try again!\n\n");

            }
        }
    }
}



  
 