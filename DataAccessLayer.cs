public class DataLayer
{
    public List<CardHolder> myCardHolders = new List<CardHolder>(); //Lista med kort användare

    public DataLayer()
    {
        myCardHolders.Add(new CardHolder("566559515251", 5678, "Victoria", "Mellgren", 36555.45));
        myCardHolders.Add(new CardHolder("123456789101", 1234, "Sara", "Mellgren", 236555.35));
        myCardHolders.Add(new CardHolder("259959515253", 6894, "Felica", "Mellgren", 655.56));
        myCardHolders.Add(new CardHolder("256459515254", 1278, "Stefan", "Mellgren", 40555.55));
        myCardHolders.Add(new CardHolder("256459515695", 5678, "Snobben", "Mellgren", 5.34));
        myCardHolders.Add(new CardHolder("256459695256", 3678, "Ingela", "Mellgren", 8900.55));
        myCardHolders.Add(new CardHolder("222222", 3030, "Emil", "HanEeeSuperSmart", 557155.25));
        myCardHolders.Add(new CardHolder("1", 1, "Björn", "Lagerblad", 178555.55));

        //Användarnas korthistorik. Detta hade i normala fall varit i en databas.
        myCardHolders[0].TransactionHistory.Add(new Transaction("Deposit", 1000.0));
        myCardHolders[0].TransactionHistory.Add(new Transaction("Deposit", 1000.0));
        myCardHolders[0].TransactionHistory.Add(new Transaction("Withdraw", 2000.0));
        myCardHolders[0].TransactionHistory.Add(new Transaction("Deposit", 1000.0));
        myCardHolders[1].TransactionHistory.Add(new Transaction("Deposit", 5000.0));
        myCardHolders[1].TransactionHistory.Add(new Transaction("Withdrawal", 3000.0));
        myCardHolders[1].TransactionHistory.Add(new Transaction("Deposit", 5000.0));
        myCardHolders[2].TransactionHistory.Add(new Transaction("Withdrawal", 200.0));
        myCardHolders[2].TransactionHistory.Add(new Transaction("Withdrawal", 200.0));
        myCardHolders[2].TransactionHistory.Add(new Transaction("Deposit", 200.0));
        myCardHolders[3].TransactionHistory.Add(new Transaction("Deposit", 3000.0));
        myCardHolders[3].TransactionHistory.Add(new Transaction("Deposit", 3000.0));
        myCardHolders[3].TransactionHistory.Add(new Transaction("Withdrawal", 8000.0));
        myCardHolders[4].TransactionHistory.Add(new Transaction("Deposit", 1000.0));
        myCardHolders[4].TransactionHistory.Add(new Transaction("Deposit", 1000.0));
        myCardHolders[4].TransactionHistory.Add(new Transaction("Withdrawal", 1000.0));
        myCardHolders[5].TransactionHistory.Add(new Transaction("Deposit", 5000.0));
        myCardHolders[5].TransactionHistory.Add(new Transaction("Deposit", 5000.0));
        myCardHolders[5].TransactionHistory.Add(new Transaction("Withdrawal", 2000.0));
        myCardHolders[6].TransactionHistory.Add(new Transaction("Withdrawal", 200.0));
        myCardHolders[6].TransactionHistory.Add(new Transaction("Withdrawal", 200.0));
        myCardHolders[6].TransactionHistory.Add(new Transaction("Deposit", 8000.0));
        myCardHolders[7].TransactionHistory.Add(new Transaction("Deposit", 3000.0));
        myCardHolders[7].TransactionHistory.Add(new Transaction("Deposit", 8000.0));
        myCardHolders[7].TransactionHistory.Add(new Transaction("Withdrawal", 200.0));

    }
}

public class Transaction //Användarnas korthistorik
{
    public string Type { get; }//Utag eller insättning.
    public double Amount { get; } //Belopp
    public DateTime Timestamp { get; }// Sätter tid och datum på aktuell transaktion.

        public Transaction(string type, double amount)
        {
            Type = type;
            Amount = amount;
            Timestamp = DateTime.Now;
        }
}




public class AtmMachine // Själva klassen för hur mycket pengar i ATM
{
    public double AtmAmount { get; set; }

    public AtmMachine(double atmAmount)
    {
        AtmAmount = atmAmount;
    }

    public AtmMachine()
    {
        AtmAmount = 10000000; // Hur mycket pengar som finns i automaten
}
}







