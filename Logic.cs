
using System;
using System.Collections.Generic;
using System.Linq;

public class CardHolder
{   
    // ToDoList
    // * Fixa så att den skriver ut sek: Sara, Klar
    // * Lägga alla delar rätt som tex listan/databasen i UI: Sara, klart
    // * När användaren tar ut pengar så så ska det vara en fördröjning på några sek med texten "Loding": Sara, Klart    
    // Fixa så att man kan transfer pengar mellan konton: Sara & Björn 
    // * Fixa så att kortet spärras efter tre försök: Björn  ***KLAR***
    // Fixa Kontoutdrag/cardHistory // Björn WIP
    // Fixa stavfel: Björn (pågånde/static ;))
    // Användaren ska kunna ändra sin pin: Björn 
    /// Ladda bankomaten med pengar : Björn Och Sara
    // Användaren ska kunna ändra sin pin
    // När användaren skriver in sin pin så ska det se ut som stjärnor på skärmen 
    /// Ladda bankomaten med pengar 

   

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
       
    public void Deposit(CardHolder currentUser)
    {
        Console.WriteLine($"How much money would you like to deposit?\n ");
        double deposit = Double.Parse(Console.ReadLine() + "");
        currentUser.Balance += deposit; // Använd Balance-egenskapen.
        Console.WriteLine($"Thank you for your deposit. Your new balance is: {currentUser.Balance:C}"); 
    }

    public void Withdraw(CardHolder currentUser)
    {
        Console.WriteLine("How much money would you like to withdraw?\n ");
        double withdrawal = Double.Parse(Console.ReadLine() +"");
        if (currentUser.Balance < withdrawal) // är balance minde än withdrawal
        {
            Console.WriteLine("Insufficient balance :");
        }
        else
        {
            currentUser.Balance -= withdrawal; // Använd Balance-egenskapen.
            Console.WriteLine("\n\nLoading...\n\n");
            Thread.Sleep(1000); //Fördröjning på 1 sek = 1000 milli sekunder
            Console.WriteLine("\n\nLoading...\n\n");
            Thread.Sleep(1000);
            Console.WriteLine("\n\nLoading...\n\n");
            Thread.Sleep(1000); 
            Console.WriteLine($"\n\nYou're good to go! Thank you. Your new balance is: {currentUser.Balance:C}\n\n");
        }
    }

    public void balance(CardHolder currentUser)
    {
        Console.WriteLine($"Current balance: {currentUser.Balance:C}"); //:C för currency, automatiskt lägger in vad du har för valuta beroende på dina inställningar

    }
 public bool IsCardLocked()
    {
        return WrongPinAttempts >= 3; // om pin är 3 eller under
    }

    public void IncreaseWrongPinAttempts()
    {
        WrongPinAttempts++; // öka hur många fel användaren har haft
    }
}



