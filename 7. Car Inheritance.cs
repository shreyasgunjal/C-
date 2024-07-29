///car inheritance


    class WagonR : Car
    {
        private int mileage;

        public WagonR(int mileage) : base(false, "4") 
        {
            this.mileage = mileage;
        }

       

        public override string getMileage()
        {
            return $"{mileage} kmpl";
        }
    }

     class HondaCity : Car
    {
        private int mileage;

        public HondaCity(int mileage) : base(true, "4") 
        {
            this.mileage = mileage;
        }

        

        public override string getMileage()
        {
            return $"{mileage} kmpl";
        }
    }

     class InnovaCrysta : Car
    {
        private int mileage;

        public InnovaCrysta(int mileage) : base(false, "6") 
        {
         this.mileage=mileage;
        }

       

        public override string getMileage()
        {
            return $"{mileage} kmpl";
        }
    }
