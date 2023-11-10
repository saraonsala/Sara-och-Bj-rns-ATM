public class DataLayer
{

    public List<CardHolder> myCardHolders = new List<CardHolder>();

    public DataLayer()
    {
        myCardHolders.Add(new CardHolder("566559515251", 5678, "Victoria", "Mellgren", 36555.45));
        myCardHolders.Add(new CardHolder("123456789101", 1234, "Sara", "Mellgren", 236555.35));
        myCardHolders.Add(new CardHolder("259959515253", 6894, "Felica", "Mellgren", 655.56));
        myCardHolders.Add(new CardHolder("256459515254", 1278, "Stefan", "Mellgren", 40555.55));
        myCardHolders.Add(new CardHolder("256459515695", 5678, "Snobben", "Mellgren", 5.34));
        myCardHolders.Add(new CardHolder("256459695256", 3678, "Ingela", "Mellgren", 8900.55));
        myCardHolders.Add(new CardHolder("256579515257", 4068, "Kerstin", "Rundqvist", 557155.25));
        myCardHolders.Add(new CardHolder("1", 1, "Björn", "Lagerblad", 178555.55));

        myCardHolders[0].TransactionHistory.Add(new Transaction("Deposit", 1000.0));
        myCardHolders[1].TransactionHistory.Add(new Transaction("Deposit", 5000.0));
        myCardHolders[2].TransactionHistory.Add(new Transaction("Withdrawal", 200.0));
        myCardHolders[3].TransactionHistory.Add(new Transaction("Deposit", 3000.0));
        myCardHolders[4].TransactionHistory.Add(new Transaction("Deposit", 1000.0));
        myCardHolders[5].TransactionHistory.Add(new Transaction("Deposit", 5000.0));
        myCardHolders[6].TransactionHistory.Add(new Transaction("Withdrawal", 200.0));
        myCardHolders[7].TransactionHistory.Add(new Transaction("Deposit", 3000.0));
    }
    }

    public class Transaction
{
    public string Type { get; }
    public double Amount { get; }
    public DateTime Timestamp { get; }

    public Transaction(string type, double amount)
    {
        Type = type;
        Amount = amount;
        Timestamp = DateTime.Now;
    }
}



