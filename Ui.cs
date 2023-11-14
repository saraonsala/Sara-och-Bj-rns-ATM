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


        void PrintDotAnimation(int timer = 10)
        {
            for (int i = 0; i < timer; i++)
            {
                Console.Write(".");
                Thread.Sleep(200);
            }
            Console.Clear();
        }

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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Your card has been locked. Please contact customer support 0730 50 28.");
                    Console.ForegroundColor = ConsoleColor.Magenta;

                }
                else
                {
                Console.ForegroundColor = ConsoleColor.Magenta;
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
                        PrintDotAnimation();
                        Console.WriteLine("\n\n");
                        Console.ForegroundColor = ConsoleColor.Red;

                        if (currentUser.Pin == userPin)
                        {
                            currentUser.WrongPinAttempts = 0;
                        }
                        else
                        {    Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Incorrect PIN. Please try again.");
                            currentUser.IncreaseWrongPinAttempts();

                            if (currentUser.IsCardLocked())
                            {   

                                Console.WriteLine("Your card has been locked. Please contact customer support 0730 50 28.");
                                Console.ForegroundColor = ConsoleColor.Magenta;
                            }
                        }
                    }
                    else
                    {   
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid PIN format. Please try again.");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Your card has been locked. Please contact customer support.");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                }

                
            if (currentUser != null && !currentUser.IsCardLocked()) // om användare finns(inte är null) och kortet inte är låst
            {
                Console.ForegroundColor = ConsoleColor.Magenta; // magenta färg

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
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n\nThank you! Have a nice day (ツ) ");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\nCard not found. Please try again.\n");
                Console.ForegroundColor = ConsoleColor.Magenta;
            }
        }
    }}




