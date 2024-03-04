namespace CV3_Evidence.Models
{
    public class Polozky
    {
        public Polozky()
        {
            Datum = DateOnly.FromDateTime(DateTime.Now);   
        }

        public Polozky(DateOnly datum, double vynosy, double naklady)
        {
            Datum = datum;
            Vynosy = vynosy;
            Naklady = naklady;
        }

        public DateOnly Datum { get; set; }
        private double naklady;

        public double Naklady
        {
            get { return naklady; }
            set
            {
                if (naklady != value)
                {
                    naklady = Math.Abs(value);
                }
            }
        }



        private double vynosy;

        public double Vynosy
        {
            get { return vynosy; }
            set 
            {
                if (vynosy != value)
                {
                    if (value >=0)         //nebo vynosy = Math.Abs(value);
                    {
                        vynosy = value;
                    }
                }                
            }
        }


        public double Zisk => Vynosy - Naklady;

        public override string ToString()
        {
            return $"Datum: {Datum} - Náklady: {Naklady} - Výnosy: {Vynosy} - Zisk: {Zisk}";
        }
    }
}
