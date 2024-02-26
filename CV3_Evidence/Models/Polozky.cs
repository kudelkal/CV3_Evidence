namespace CV3_Evidence.Models
{
    public class Polozky
    {
        public DateOnly Datum { get; set; }
        private double naklady;

        public double Naklady
        {
            get { return naklady; }
            set
            {
                if (naklady != value)
                {
                    if (value >= 0)
                    {
                        naklady = value;
                    }
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
                    if (value >=0)
                    {
                        vynosy = value;
                    }
                }                
            }
        }


        public double Zisk => Vynosy - Naklady;
    }
}
