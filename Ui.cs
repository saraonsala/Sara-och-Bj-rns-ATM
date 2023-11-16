using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

public class Program
{ 
    static void Main(string[] args)
    {   
        Console.Title = "Tech Titans";//Ändrar titeln på consolfönstret, detta syns bättre i VS Studio
        Console.ForegroundColor = ConsoleColor.Magenta; //Sätter text färgen i consolfönstret
        DataLayer dataLayer = new DataLayer();// Instansierar ett objekt av klassen DataLayer i och med ordet new
        Console.OutputEncoding = Encoding.Unicode; //konverterar UTF så att man kan se alla ASCII karaktärer

        while (true)
        {   
            Console.WriteLine("\n\n----------Welcome to Tech Titans's ATM App---------\n");
            Console.WriteLine("\n\n Please enter your debit card...\n\n");
            Console.WriteLine("\n-----------------------------------------\n");

            string? debitCardNum = Console.ReadLine();//Användarens input och stämmer av med debitCardNR
            CardHolder? currentUser = dataLayer.myCardHolders.FirstOrDefault(a => a.CardNum == debitCardNum); //Den tar använarens input debitCardNum och hämtar hela objektet från listan myCardHolders.

            if (currentUser != null) // Om användaren inte är null
            {
                if (currentUser.IsCardLocked()) // Om kortet är låst.
                {
                    Ui.PrintRedThenMagenta("Your card has been locked. Please contact customer support 0771-666 666.");
                }
                else
                {
                Console.WriteLine("\n\nPlease enter your PIN:\n");

                if (currentUser.WrongPinAttempts < 3) //Om det är mindre än 3 försök.
                {
                    StringBuilder pinBuilder = new StringBuilder(); // Gör så att användarens input (pinkod) blir * i consolefönstret.

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
                    if (int.TryParse(pinBuilder.ToString(), out userPin))// Försök omvandla strängen från pinBuilder till ett heltal.Om omvandlingen är framgångsrik, spara det omvandlade värdet i userPin.
                    {   
                        Console.WriteLine("\nChecking PIN\n");
                        Ui.PrintDotAnimation(); //.... animation
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
                                Ui.PrintRedThenMagenta("Your card has been locked. Please contact customer support 0771-666 666.");
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
                    Ui.PrintRedThenMagenta("Your card has been locked. Please contact customer support 0771-666 666.");
                }
                
            if (currentUser != null && !currentUser.IsCardLocked()) // Om användare finns(inte är null) och kortet inte är låst.
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

                Console.WriteLine("\n\n---------- Welcome ★ " + currentUser.FirstName + " ★ -------\n\n"); //Användarmenyn.
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
    public static void PrintDotAnimation(int timer = 10) //Skapar en ... animation
    {
        for (int i = 0; i < timer; i++)
        {
            Console.Write(".");
            Thread.Sleep(200);
        }
        Console.Clear();
    }

    public static void PrintRedThenMagenta(string msg) //Metod för att texten för felmeddelanden skrivs i rött och efter en Console.WriteLine går tillbaka till programets förbestämda färg.  
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(msg);
        Console.ForegroundColor = ConsoleColor.Magenta;
   
    }
    public static void PrintYellowThenMagenta(string msg) //Metod för att saldo texten skrivs i gult och efter en Console.WriteLine går tillbaka till programets förbestämda färg. 
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(msg);
        Console.ForegroundColor = ConsoleColor.Magenta;

    }

}





