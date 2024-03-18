using Microsoft.JSInterop;
using System.Globalization;

namespace CV3_Evidence.Models
{
    public class Evidence
    {
        public Evidence(IJSRuntime js)
        {
            JS = js;
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
        }
        private IJSRuntime JS { get; set; }

        public List<Polozky>  PolozkyList { get; set; } = new List<Polozky>();
        public Polozky Polozka { get; set; } = new Polozky();
        public string Vypis { get; set; } = "";

        public bool IsEditace { get; set; } = false;
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

        //        public void Statistiky()
        //        {
        //            Vypis = "";
        //            Vypis += $"Minumum: {Minimum()}";
        //            Vypis += $"Maximum: {Maximum()}";
        //            Vypis += $"Průměr: {Prumer()}";
        //        }

        //        private double Minimum()
        //        {
        //            if (PolozkyList.Count == 0)
        //            {
        //                return double.NaN;
        //            }
        //            return PolozkyList.Min(Polozky pol => pol.Zisk);
        //        }

        //        private double Maximum()
        //        {
        //            if (PolozkyList.Count == 0)
        //            {
        //                return double.NaN;
        //            }
        //            return PolozkyList.Max(Polozky pol => pol.Zisk);
        //        }

        //        private double Prumer()
        //        {
        //            if (PolozkyList.Count == 0)
        //            {
        //                return double.NaN;
        //            }
        //            return PolozkyList.Average(Polozky pol => pol.Zisk);
        //        }

        public async void SmazatZaznam(Models.Polozky item)
        {
            var zprava = $"Chcete smazat {item.Datum} - Zisk: {item.Zisk} z vašeho seznamu?";
            //JS.InvokeVoidAsync("alert", zprava);

            if (await JS.InvokeAsync<bool>("confirm", zprava))
            {
                PolozkyList.Remove(item);
            }
        }

        public void Editace(Polozky item)
        {
            Polozka = item;
            IsEditace = true;
        }

        public void UkonciEditaci()
        {
            IsEditace = false;
            Polozka = new Polozky();
        }
    }
}
