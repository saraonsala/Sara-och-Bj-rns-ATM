using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;


namespace UI
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.Title = "Tech Titans";
            Console.ForegroundColor = ConsoleColor.Magenta;
            DataLayer dataLayer = new DataLayer();

            static void PressEnterToContinue()
            {
                Console.WriteLine("\n\n Press Enter to continue...\n");
                Console.ReadLine();
            }

            static void PrintMessage(string msg, bool success = true)
            {
                if(success)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.WriteLine(msg);
                Console.ForegroundColor = ConsoleColor.Cyan;
                PressEnterToContinue();
            }        

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
                Console.WriteLine("Please enter your debit card...\n\n");
                Console.WriteLine("\n\n-----------------------------------------\n\n");
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
                        Console.ForegroundColor = ConsoleColor.Cyan;


                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Please enter your PIN:");
                        int userPin = 0;

                        if (currentUser.WrongPinAttempts < 3) // Kolla så att pin är mindre än 3
                        {
                            while (true)
                            {
                                try
                                {
                                    userPin = int.Parse(Console.ReadLine()+"");
                                    PrintDotAnimation();

                                    Console.ForegroundColor = ConsoleColor.Red;

                                    if (currentUser.Pin == userPin)
                                    {
                                        currentUser.WrongPinAttempts = 0; // Starta om PIN
                                        break;
                                    }
                                    else
                                    {
                                        PrintMessage("Invalidate input. Try agin.", false);
                                        currentUser.IncreaseWrongPinAttempts();

                                        if (currentUser.IsCardLocked())
                                        {
                                            Console.WriteLine("Your card has been locked. Please contact customer support.");
                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            break; // Gå ut ur loop
                                        }
                                    }
                                }
                                catch
                                {
                                    PrintMessage("Invalidate input. Try agin.", false);
                                }
                            }
                        }
                        else
                        {
                            
                            Console.WriteLine("Your card has been locked. Please contact customer support.");
                            

                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Card not recognized. Please try again");
                    Console.ForegroundColor = ConsoleColor.Cyan;


                    Console.WriteLine("-------------------------------------------------");
                    Console.WriteLine("Please choose from one of the following options...");
                    Console.WriteLine("1. Deposit.");
                    Console.WriteLine("2. Withdraw.");
                    Console.WriteLine("3. Show Balance.");
                    Console.WriteLine("4. Change PIN.");
                    Console.WriteLine("0. Exit.");
                    Console.WriteLine("-------------------------------------------------");
                }

                if (currentUser != null && !currentUser.IsCardLocked()) // om användare finns(inte är null) och kortet inte är låst
                {
                    Console.ForegroundColor = ConsoleColor.Cyan; // magenta färg

                    void PrintOptions()
                    {
                        Console.WriteLine("-------------------------------------------------");
                        Console.WriteLine("Please choose from one of the following options...");
                        Console.WriteLine("1. Deposit.");
                        Console.WriteLine("2. Withdraw.");
                        Console.WriteLine("3. Show Balance.");
                        Console.WriteLine("4. Change PIN.");
                        Console.WriteLine("0. Exit.");
                        Console.WriteLine("-------------------------------------------------");
                    }
<<<<<<< HEAD

                    Console.WriteLine("\n\n-----Welcome " + currentUser.FirstName + " :) -------\n\n");
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
                        else if (option == 4) { currentUser.ChangePin();}
                        else if (option == 9) { break; }
                    } while (option != 0); // exit menu 
                    Console.WriteLine("\n\nThank you! Have a nice day :)");
            
                }
            }
=======
                    catch { option = 0; }
                    if (option == 1) { currentUser.Deposit(currentUser); }
                    else if (option == 2) { currentUser.Withdraw(currentUser); }
                    else if (option == 3) { currentUser.balance(currentUser); }
<<<<<<< HEAD
<<<<<<< HEAD
                    else if (option == 4) {System.Console.WriteLine("TEST");}
=======
                    else if (option == 4) { currentUser.ChangePin();}
>>>>>>> parent of ed1a8e8 (Transaction history WIP)
=======
                    else if (option == 4) { currentUser.ChangePin();}
>>>>>>> parent of ed1a8e8 (Transaction history WIP)
                    else if (option == 9) { break; }
                } while (option != 0); // exit menu 
                Console.WriteLine("\n\nThank you! Have a nice day :)");
          
          }
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> parent of f59babc (working pin change)
=======
>>>>>>> parent of ed1a8e8 (Transaction history WIP)
=======
>>>>>>> parent of ed1a8e8 (Transaction history WIP)
        }
    }
}



