using System;
using System.Collections.Generic;



public class cardHolder 
{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;

    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public String getNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }

    public string getFirstName()
    {
        return firstName;
    }

    public string getLastName()
    {
        return lastName;
    }

    public double getBalance()
    {
        return balance;
    }
    public void setCardNum(string newCardNum)
    {
        cardNum =newCardNum;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setFirstname(string newFirstName)
    {
        firstName= newFirstName;
    }

    public void setLastName(string newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(String[]args)
    {
        void printOptions()
        {
            System.Console.WriteLine("*************************************************");
            System.Console.WriteLine("Pleas choose from one of the following options...");
            System.Console.WriteLine("1. Deposit");
            System.Console.WriteLine("2. Whitdraw");
            System.Console.WriteLine("3. Show Balance");
            System.Console.WriteLine("4. Exit");
            System.Console.WriteLine("*************************************************");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How mutch $$ would you like to deposit: ? ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Thank you for you $$. Your new balance is: " + currentUser.getBalance());

        }
        
        void withdraw(cardHolder currentUser)
        {
        System.Console.WriteLine("How mutch $$ would you like to withdraw: ? ");
        double withdrawal = Double.Parse(Console.ReadLine());
        //Check if the user has enough money
        if(currentUser.getBalance() < withdrawal)
        {
            Console.WriteLine("Insufficient balance :");
        }
        else
        {
            currentUser.setBalance(currentUser.getBalance() -withdrawal);
            Console.WriteLine("You´re good to go! Thank you : ");
        }
        }

        void balance(cardHolder currentUser)
        {
            System.Console.WriteLine("Current balance: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders  = new List<cardHolder>();
        cardHolders.Add(new cardHolder("566559515251", 5678, "Victoria","Mellgren", 36555.45));
        cardHolders.Add(new cardHolder("123456789101", 5678, "Sara","Mellgren", 236555.35));    
        cardHolders.Add(new cardHolder("259959515253", 6894, "Felica","Mellgren", 655.56));
        cardHolders.Add(new cardHolder("256459515254", 1278, "Stefan","Mellgren", 40555.55));
        cardHolders.Add(new cardHolder("256459515695", 5678, "Snobben","Mellgren", 5.34));
        cardHolders.Add(new cardHolder("256459695256", 3678, "Ingela","Mellgren", 8900.55));
        cardHolders.Add(new cardHolder("256579515257", 4068, "Kerstin","Rundqvist", 557155.25));
        cardHolders.Add(new cardHolder("256459544258", 5678, "Ulla","Olsson", 78555.55));

        //promet user
        System.Console.WriteLine("****************************");
        System.Console.WriteLine("Welcome to Sara`s ATM");
        System.Console.WriteLine("Pleas enter you debit card: ");
        String debitCardNum = "";
        cardHolder currentUser;
        System.Console.WriteLine("*****************************");

        while(true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                //check aginst our db. Denna söker av db=databasen och retunerar hela objektet
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser != null) {break;} // denna visa 
                else { System.Console.WriteLine("Card not recognized. Pleas try again");}
            }
            catch{ Console.WriteLine("Card not recognized. Pleas try again"); }
        }
        
        System.Console.WriteLine("Pleas enter you pin: ");
        int userPin= 0;
        while(true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if (currentUser.getPin()== userPin) {break;} 
                else { System.Console.WriteLine("Incorrect pin. Pleas try again.");}
            }
            catch{Console.WriteLine("Incorrect pin. Pleas try again.");}
        }

        System.Console.WriteLine("Welcome " + currentUser.getFirstName() + " :) ");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if(option== 1){deposit(currentUser);}
            else if(option == 2) {withdraw(currentUser);}
            else if(option == 3) {balance(currentUser);}
            else if(option == 4) {break;}
            else { option = 0;} //för att vi vill att loopen ska börja om
        }
        while(option != 4); //för nr 4 är exit i menun
        {
            System.Console.WriteLine("Thank you! Have a nice day :)");
        }

    }

}




