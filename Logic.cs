using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography.X509Certificates;
using System.Threading;



  
    // ToDoList
    // * Fixa så att den skriver ut sek: Sara,  ***KLAR***
    // * Lägga alla delar rätt som tex listan/databasen i UI: Sara,  ***KLAR***
    // * När användaren tar ut pengar så så ska det vara en fördröjning på några sek med texten "Loding": Sara,  ***KLAR***    
    // * Fixa så att kortet spärras efter tre försök: Björn  ***KLAR***
    // * Användaren ska kunna ändra sin pin: Björn ***KLAR***
    // * Fixa Kontoutdrag/cardHistory // Björn ***KLAR***
    // *Timestamp.now till något som inte uppdaterar efter nu2varande tid // Björn  ***KLAR***  
    // * När användaren skriver in sin pin så ska det se ut som stjärnor på skärmen: Sara ***KLAR***
    // *Ladda bankomaten med pengar : Björn **KLAR**

    
    // Fixa så att man kan transfer pengar mellan konton: Sara  


    // Fixa stavfel: Björn (pågånde/static ;))
    // Fixa syntax: Sara (pågånde/static ;))
    

   
public class CardHolder
{ 

    public string CardNum { get; set; }
    public int Pin { get; set; }
    public string FirstName { get; set; }
    public string LastName { get;  set; }
    public double Balance { get; set; }
    public List<Transaction> TransactionHistory { get; set; } = new List<Transaction>();
    AtmMachine atm = new AtmMachine();
    Program program = new Program();
    Ui ui = new Ui();

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
    public void Deposit(CardHolder currentUser)
    {
        Console.WriteLine($"How much money would you like to deposit?\n ");
        double deposit = Double.Parse(Console.ReadLine() + "");
        currentUser.Balance += deposit; // Använd Balance-egenskapen.
        Ui.PrintYellowThenMagenta($"Thank you for your deposit. Your new balance is: {currentUser.Balance:C}"); 
        TransactionHistory.Add(new Transaction("Deposit", deposit));
    }

    public void Withdraw(CardHolder currentUser)
    {
        Console.WriteLine("How much money would you like to withdraw?\n ");
        double withdrawal = Double.Parse(Console.ReadLine() +"");
        TransactionHistory.Add(new Transaction("Withdrawal", withdrawal));
        if (currentUser.Balance < withdrawal) // är balance minde än withdrawal
        {   
            Ui.PrintRedThenMagenta($"\n\nInsufficient balance.Your balance is {currentUser.Balance:C}\n\n");
        }
        else if (atm.AtmAmount > withdrawal) // om atm har mindre pengar än vad man vill ta ut
        {   
            Ui.PrintRedThenMagenta($"\n\nOut of order.Support 555-12765\n\n");
        }                 
                    
        else
        {
            currentUser.Balance -= withdrawal; // Använd Balance-egenskapen.
            Console.WriteLine("\n\nLoading.....");
            Ui.PrintDotAnimation();
            Ui.PrintYellowThenMagenta($"\n\nYou're good to go! Thank you. Your new balance is: {currentUser.Balance:C}\n\n");
            atm.AtmAmount -= withdrawal; // uppdaterar atmamount(pengar i maskinen) med hur mycket som har tagits ut        
        }
    }

    public void balance(CardHolder currentUser)
    {   
        Ui.PrintRedThenMagenta($"Current balance: {currentUser.Balance:C}"); //:C för currency, automatiskt lägger in vad du har för valuta beroende på dina inställningar
    }
    public bool IsCardLocked()
    {
        return WrongPinAttempts >= 3; // om pin är 3 eller under
    }

    public void IncreaseWrongPinAttempts()
    {
        WrongPinAttempts++; // öka hur många fel användaren har haft
    }
  public static void DisplayTransactionHistory(CardHolder currentUser)
    {
        Console.WriteLine("Transaction History:");
        foreach (var transaction in currentUser.TransactionHistory)
        {
            Ui.PrintYellowThenMagenta($"{transaction.Timestamp} - {transaction.Type}: {transaction.Amount:C}");
        }
    }    
public void ChangePin()
{   
    Console.WriteLine("Please enter you current PIN:");
    int currentPin;
    
    while(true)
    {
        
        try // try/catch om input inte skulle stämma
        {
            currentPin = int.Parse(Console.ReadLine()+ "");
           
            if (currentPin == Pin)
            { 
                System.Console.WriteLine("Please enter you new PIN:");
                int newPin = int.Parse(Console.ReadLine()+""); 
                Pin = newPin; 
                System.Console.WriteLine("PIN succesfully changed!");
                break;
            }
            else
            {
                Ui.PrintRedThenMagenta("Incorrect PIN. Try again!");
            }   
        }     
        catch // fångar ifall input inte är samma som PIN
        {
            Ui.PrintRedThenMagenta("Incorrect PIN. Try again!");

        }
    }
}
}

  
 