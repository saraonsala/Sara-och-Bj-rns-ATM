using System;
using System.Linq;
using System.Text;
using System.Threading;

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

            if (currentUser != null)
            {
                int attemptsLeft = 3;

                while (attemptsLeft > 0)
                {
                    Console.WriteLine("\nPlease enter your PIN:");

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
                            Console.Write("\b \b");
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
                        Console.WriteLine("\nChecking PIN...");
                        Ui.PrintDotAnimation();
                        Console.WriteLine("\n");

                        if (currentUser.Pin == userPin)
                        {
                            currentUser.WrongPinAttempts = 0;
                            break;
                        }
                        else
                        {
                            Ui.PrintRedThenMagenta($"Incorrect PIN. {--attemptsLeft} attempts left. Please try again.");
                        }
                    }
                    else
                    {
                        Ui.PrintRedThenMagenta("\nInvalid PIN format. Please try again.");
                    }
                }

                if (attemptsLeft == 0)
                {
                    Ui.PrintRedThenMagenta("Your card has been locked. Please contact customer support.");
                    // Additional logic for handling a locked card if needed
                }
                else
                {
                    // Continue with the rest of your code

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

                    Console.WriteLine($"\n\n-----Welcome ★ {currentUser.FirstName} ★ -------\n\n");
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
                    } while (option != 0);

                    Ui.PrintYellowThenMagenta("\n\nThank you! Have a nice day (ツ) ");
                }
            }
            else
            {
                Ui.PrintRedThenMagenta("\n\nCard not found. Please try again.\n");
            }
        }
    }
}

