using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

public class Program
{ 
    static void Main(string[] args)
    {   
        Console.OutputEncoding = Encoding.Unicode;
        Console.Clear();
        Console.Title = "Tech Titans";
        Console.ForegroundColor = ConsoleColor.Magenta;
        DataLayer dataLayer = new DataLayer();

        void mainMenu()
        {
            Console.WriteLine("\n\n----------Welcome to Tech Titans's ATM App---------\n");
            Console.WriteLine("\n\n Please enter your debit card...\n\n");
            Console.WriteLine("\n-----------------------------------------\n");
        }

        while (true)
        {
            mainMenu();
            string? debitCardNum = Console.ReadLine();
            CardHolder? currentUser = dataLayer.myCardHolders.FirstOrDefault(a => a.CardNum == debitCardNum);

            if (currentUser != null) // ifall användaren inte är null alltså om användaren är null så existerar dom inte
            {
                if (currentUser.IsCardLocked()) // går till om kortet är låst (är det under 3 försök)
                {
                    Ui.PrintRedThenMagenta("Your card has been locked. Please contact customer support 0730 50 28.");
                }
                else
                {
                Console.WriteLine("\n\nPlease enter your PIN:\n");

                if (currentUser.WrongPinAttempts < 3)
                {
                    StringBuilder pinBuilder = new StringBuilder();

                    while (true)
                    {
                        ConsoleKeyInfo key = Console.ReadKey(true);

                        if (key.Key == ConsoleKey.Enter)
                        {
                            break;
                        }
                        else if (key.Key == ConsoleKey.Backspace && pinBuilder.Length > 0)
                        {
                            pinBuilder.Remove(pinBuilder.Length - 1, 1);
                            Console.Write("\b \b");//sekvens av tecken som flyttar markören tillbaka med en position i konsolfönstret och sedan skriva över det sista tecknet med ett mellanslag
                        }
                        else if (char.IsDigit(key.KeyChar))
                        {
                            pinBuilder.Append(key.KeyChar);
                            Console.Write("*");
                        }
                    }

                    int userPin;
                    if (int.TryParse(pinBuilder.ToString(), out userPin))
                    {   
                        Console.WriteLine("\nChecking PIN\n");
                        Ui.PrintDotAnimation();
                        Console.WriteLine("\n\n");

                        if (currentUser.Pin == userPin)
                        {
                            currentUser.WrongPinAttempts = 0;
                        }
                        else
                        {    
                            Ui.PrintRedThenMagenta("Incorrect PIN. Please try again.");
                            currentUser.IncreaseWrongPinAttempts();

                            if (currentUser.IsCardLocked())
                            {   
                                Ui.PrintRedThenMagenta("Your card has been locked. Please contact customer support 0730 50 28.");
                            }
                        }
                    }
                    else
                    {   
                        Ui.PrintRedThenMagenta("\nInvalid PIN format. Please try again.");
                    }
                }
                else
                {
                    Ui.PrintRedThenMagenta("Your card has been locked. Please contact customer support.");
                }
                
            if (currentUser != null && !currentUser.IsCardLocked()) // om användare finns(inte är null) och kortet inte är låst
            {
                void PrintOptions()
                {
                    Console.WriteLine("-------------------------------------------------");
                    Console.WriteLine("Please choose from one of the following options...");
                    Console.WriteLine("1. Deposit.");
                    Console.WriteLine("2. Withdraw.");
                    Console.WriteLine("3. Show Balance.");
                    Console.WriteLine("4. Transaction History");
                    Console.WriteLine("5. Change PIN.");
                    Console.WriteLine("0. Exit.");
                    Console.WriteLine("-------------------------------------------------");
                }

                Console.WriteLine("\n\n-----Welcome ★ " + currentUser.FirstName + " ★ -------\n\n");
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
                    else if (option == 4) { CardHolder.DisplayTransactionHistory(currentUser); }
                    else if (option == 5) { currentUser.ChangePin(); }
                    else if (option == 9) { break; }
                } while (option != 0); // exit menu 
                        Ui.PrintYellowThenMagenta("\n\nThank you! Have a nice day (ツ) ");
                    }
                }
            }
            else
            {
                Ui.PrintRedThenMagenta("\n\nCard not found. Please try again.\n");
            }
        }
    }}
public class Ui
{
    public static void PrintDotAnimation(int timer = 10)
    {
        for (int i = 0; i < timer; i++)
        {
            Console.Write(".");
            Thread.Sleep(200);
        }
        Console.Clear();
    }

    public static void PrintRedThenMagenta(string msg)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(msg);
        Console.ForegroundColor = ConsoleColor.Magenta;
   
    }
    public static void PrintYellowThenMagenta(string msg)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(msg);
        Console.ForegroundColor = ConsoleColor.Magenta;

    }

}





