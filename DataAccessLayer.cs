using System.Collections.Generic;

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
        myCardHolders.Add(new CardHolder("111", 1234, "Björn", "Lagerblad", 178555.55));
    }





}


