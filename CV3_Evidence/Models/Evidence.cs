namespace CV3_Evidence.Models
{
    public class Evidence
    {
        public List<Polozky>  PolozkyList { get; set; } = new List<Polozky>();
        public Polozky Polozka { get; set; } = new Polozky();
        public string Vypis { get; set; } = "";

        public void Pridat()
        {
            //PolozkyList.Add(Polozky);
            //Polozky = new Polozky();      


            PolozkyList.Add(new Polozky(datum: Polozka.Datum,vynosy: Polozka.Vynosy,naklady: Polozka.Naklady));
        }

        public void ZobrazPocetZaznamu()
        {
            Vypis = $"Počet záznamů je {PolozkyList.Count}";
        }

        public void ZobrazZaznamy()
        {
            Vypis = $"Jednotlivé záznamy: <br>" + string.Join("<br>", PolozkyList);
        }

    }
}
