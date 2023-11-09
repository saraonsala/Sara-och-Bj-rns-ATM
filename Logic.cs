
using System;
using System.Collections.Generic;
using System.Linq;

public class CardHolder
{   
    // ToDoList
    // Fixa så att den skriver ut sek: Sara, Klar
    // Lägga alla delar rätt som tex listan/databasen i UI: Sara, klart
    // När användaren tar ut pengar så så ska det vara en fördröjning på några sek med texten "Loding": Sara, Klart    
    // Fixa så att man kan transfer pengar: Sara & Björn 
    // Fixa så att kortet spärras efter tre försök: Björn 
    // Fixa Kontoutdrag/cardHistory // Björn 
    // Fixa stavfel: Björn (pågånde/static ;))
    // Användaren ska kunna ändra sin pin 
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
        Console.WriteLine("How mutch $$ would you like to deposit: ? ");
        double deposit = Double.Parse(Console.ReadLine() + "");
        currentUser.Balance += deposit; // Använd Balance-egenskapen.
        Console.WriteLine($"Thank you for your $$. Your new balance is: {currentUser.Balance:C}"); 
    }

    public void Withdraw(CardHolder currentUser)
    {
        Console.WriteLine("How mutch $$ would you like to withdraw: ? ");
        double withdrawal = Double.Parse(Console.ReadLine() +"");
        //Check if the user has enough money
        if (currentUser.Balance < withdrawal)
        {
            Console.WriteLine("Insufficient balance :");
        }
        else
        {
            currentUser.Balance -= withdrawal; // Använd Balance-egenskapen.
            Console.WriteLine("\n\nLoding.....\n\n");
            Thread.Sleep(4000); //Fördröjning på 4 sek = 4000 milli sekunder
            Console.WriteLine($"\n\nYou're good to go! Thank you. Your new balance is: {currentUser.Balance:C}\n\n");
        }
    }

    public void balance(CardHolder currentUser)
    {
        Console.WriteLine($"Current balance: {currentUser.Balance:C}"); //:C för currency, automatiskt lägger in vad du har för vluta beroende på dina inställningar

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



