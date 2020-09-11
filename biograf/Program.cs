using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using biograf.Model;
using biograf.Databaselage;



namespace biograf
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //check forbindelse
            if (SQL.SqlConnectionOK())
            {
                Console.WriteLine("Der er forbindelse til databasen");
            }
            else
            {
                Console.WriteLine("Der er ikke forbindelse til databasen");
            }

            //oprette to kunder
            Kunder k1 = new Kunder( "Allan" , "Jensen", "Telegrafvej 9", "52012368", "Pensionist");
            k1.InsertIntoDB();

            Kunder k2 = new Kunder( "Vincet" , "Hansen", "Telegrafvej 2", "52012858", "Pensionist");
            k2.InsertIntoDB();


            //oprette to bestillinger
            Bestillinger b1 = new Bestillinger(1, 1, "Baby Boss 1", 2, "2020-01-10 10:10", "købe");
            b1.InsertIntoDB();

            Bestillinger b2 = new Bestillinger(2, 2, "Fast and Forest3", 4, "2020-05-12 20:00", "købe");
            b2.InsertIntoDB();


            //list af alle kunder:

            List<Kunder> heleKunder = Kunder.KundeListe();
            foreach (var item in heleKunder)
            {
                Console.WriteLine(" ID: " + item.Kundeid + "Fnavn: " + item.Fnavn + "Enavn: " + item.Enavn + "Adresse: " + item.Adresse + " Telnummer: " + item.Telnumer + " Kunetype: " + item.Kundetype);
            }

            SQL.DataReader();


            //sortere

            SortEnavn Senv = new SortEnavn();

            List<Kunder> kundelist =
                new List<Kunder>() { k1, k2 };
          
            //kundelist.Sort(Senv);
            Console.WriteLine("sorteret list efter Enavn:");

            foreach (var item in kundelist)

            {
                Console.WriteLine($"{item.Fnavn} {item.Enavn}");
            }


            // Update 
            SQL.Update("Allan");



            //Delete
            SQL.Delete("Vincet");



            // list bestillinger fra kundeid=2

            List<Bestillinger> heleBestillinger = Bestillinger.BestillingerListe();
            foreach (var item in heleBestillinger)
            {
                Console.WriteLine(" BestillingrID: " + item.Bestillingid + " KundeID: " + item.Kundeid + "Flmnavn  : " + item.Flmnavn + "Antalpls: " + item.Antalpls + " Bestillingstid: " + item.Bestillingstid + " Typebilletter: " + item.Typebilletter);
            }

            SQL.DataReader();



            Console.ReadKey();

        }
    }
}
