using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using biograf.Databaselage;


namespace biograf.Model
{
    class Kunder : IComparable<Kunder>
    {
        public int Kundeid { get; set; }
        public string Fnavn { get; set; }
        public string Enavn { get; set; }
        public string Adresse { get; set; }
        public string Telnumer { get; set; }
        public string Kundetype { get; set; }


        public Kunder()
        {

        }

        public Kunder(string f,string e, string a, string t, string k)
        {
            
            Fnavn = f;
            Enavn = e;
            Adresse = a;
            Telnumer = t;
            Kundetype = k;
        }

        public void InsertIntoDB()
        {
            string sql = "insert into Kunder values ('" + Fnavn + "','" + Enavn + "','" + Adresse + "','" + Telnumer + "' , '" + Kundetype + "')";
            try
            {

                SQL.insert(sql);
                Console.WriteLine($"Kunden {Fnavn} oprettet på tabellen");
            }
            catch (Exception)
            {

                Console.WriteLine("Der opstod en fejl i oprettelsen, kunden IKKE oprettet");
            }

        }

        public static List<Kunder> KundeListe()
        {
            string sql = "Select * from Kunder";

            DataTable kundeDataTable = SQL.ReadTable(sql);

            List<Kunder> listKunder = new List<Kunder>();
            foreach (DataRow kundeData in kundeDataTable.Rows)
            {
                listKunder.Add(new Kunder()
                {
                    Kundeid = Convert.ToInt32(kundeData["kundeid"]),
                    Fnavn = kundeData["fnavn"].ToString(),
                    Enavn = kundeData["enavn"].ToString(),
                    Adresse = kundeData["adr"].ToString(),
                    Telnumer = kundeData["tlf"].ToString(),
                    Kundetype = kundeData["kundetype"].ToString()
                });
            }

            return listKunder;

        }

        public int CompareTo(Kunder other)
        {
            return string.Compare(this.Fnavn, other.Fnavn);
        }



        public override string ToString()
        {
            return $"navn : {Fnavn}";
        }

    }
}


