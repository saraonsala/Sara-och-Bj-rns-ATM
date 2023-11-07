
using System;
using System.Collections.Generic;
using System.Linq;
public class CardHolder
{
    // fixa så att den skriver ut sek: Sara Klar
    // fixa så att man kan transfer pengar: Sara & Björn  
    // fixa så att kortet spärras efter tre försök: Björn 
    // fixa stavfel: Björn 
    // Användaren ska kunna ändra sin pin 
    // När användaren tar ut pengar så så ska det vara en fördröjning på några sek med texten "Loding" 
    /// Ladda bankomaten med pengar 
    // Lägga alla delar rätt som tex listan/databasen i UI
   

    public string CardNum { get; set; }
    public int Pin { get; set; }
    public string FirstName { get; set; }
    public string LastName { get;  set; }
    public double Balance { get; set; }


    public CardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        CardNum = cardNum;
        Pin = pin;
        FirstName = firstName;
        LastName = lastName;
        Balance = balance;
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

    public void balance(CardHolder currentUser)
    {
        Console.WriteLine($"Current balance: {currentUser.Balance:C}"); 

    }
    public void PrintOptions()
    {
        Console.WriteLine("-------------------------------------------------");
        Console.WriteLine("Pleas choose from one of the following options...");
        Console.WriteLine("1. Deposit");
        Console.WriteLine("2. Whitdraw");
        Console.WriteLine("3. Show Balance");
        Console.WriteLine("4. Exit");
        Console.WriteLine("-------------------------------------------------");
    }
}
