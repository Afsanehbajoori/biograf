using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using biograf.Databaselage;

namespace biograf.Model
{
    class Bestillinger
    {
        public int Bestillingid { get; set; }
        public int Kundeid { get; set; }
        public string Flmnavn { get; set; }
        public int Antalpls { get; set; }

        public string Bestillingstid { get; set; }
        public string Typebilletter { get; set; }


        public Bestillinger()
        {

        }

        public Bestillinger(int bi, int i, string f, int a, string b, string t)
        {
            Bestillingid = bi;
            Kundeid = i;
            Flmnavn = f;
            Antalpls = a;
            Bestillingstid = b;
            Typebilletter = t;
        }



        public void InsertIntoDB()
        {
            string sql = "insert into Bestillinger values (" + Bestillingid + "," + Kundeid + ",'" + Flmnavn + "'," + Antalpls + ",  '" + Bestillingstid + "' , '" + Typebilletter + "')";
            try
            {

                SQL.insert(sql);
                Console.WriteLine($"Bestilling {Flmnavn} oprettet på tabellen");
            }
            catch (Exception)
            {

                Console.WriteLine("Der opstod en fejl i oprettelsen, film IKKE oprettet");
            }

        }

        public static List<Bestillinger> BestillingerListe()
        {
            string sql = "Select * from Bestillinger";

            DataTable bestillingerDataTable = SQL.ReadTable(sql);

            List<Bestillinger> listBestillinger = new List<Bestillinger>();
            foreach (DataRow BestillingData in bestillingerDataTable.Rows)
            {
                listBestillinger.Add(new Bestillinger()
                {
                    Bestillingid = Convert.ToInt32(BestillingData["bestillingid"]),
                    Kundeid = Convert.ToInt32(BestillingData["2"]),
                    Flmnavn = BestillingData["flmnavn"].ToString(),
                    Antalpls = Convert.ToInt32(BestillingData["antalpls"]),
                    Bestillingstid = BestillingData["bestillingstid"].ToString(),
                    Typebilletter = BestillingData["typebilletter"].ToString()
                });
            }

            return listBestillinger;

        }
    }
}
