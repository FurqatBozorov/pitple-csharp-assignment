using System;

namespace vehicleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Cars HyundaiTucson = new Cars("Hyundai", "tucson", "2015", "1702");
            Cars Malibu = new Cars("Chevrolet", "Malibu", "1997", "1425");
            Cars Focus = new Cars("Ford", "focus", "2000", "1471");
            Planes Boeing = new Planes("Boeing Commercial Airplanes", "Boeing 737", "1967", "60000kg");
            for (int i=1; i<101; i++)
            {
                HyundaiTucson.Drive();
                HyundaiTucson.Stop();
                Malibu.Drive();
                Malibu.Stop();
                Focus.Drive();
                Focus.Stop();
                Boeing.Drive();
                Boeing.Stop();
            }
        }
    }

    public class Vehicles
    {
        public string Make;
        public string Model;
        public string Year;
        public string Weight;
        public static bool NeedsMaintenance = false;
        public static int TripsSinceMaintenance = 0;


       public  Vehicles(string make, string model, string year, string weight)
        {
            Make = make;
            Model = model;
            Year = year;
            Weight = weight;
        }

        public static void Repair()
        {
            NeedsMaintenance = false;
            TripsSinceMaintenance = 0;
        }

    }

    class Cars : Vehicles
    {
        bool isDriving = false;

        public Cars(string make, string model, string year, string weight)
            :base( make,  model, year, weight)
        {
        }

        public void Drive()
        {
            isDriving = true;
            
        }
        
        public void Stop()
        {
            isDriving = false;
            TripsSinceMaintenance++;
            if (TripsSinceMaintenance == 100)
            {
                Console.WriteLine("This car produced by : " + Make);
                Console.WriteLine("Model of the car is : " + Model);
                Console.WriteLine("Produced year is : " + Year);
                Console.WriteLine("The car wieght is: " + Weight);
                NeedsMaintenance = true;
                Console.WriteLine("Car needs a maintennance!!!");
                Repair();
                Console.WriteLine("It is repaired. You can go!!!");
            }
        }

    }


    class Planes : Vehicles
    {
        bool isDriving = false;

        public Planes(string make, string model, string year, string weight)
            : base(make, model, year, weight)
        {
        }

        public void Drive()
        {
            isDriving = true;

        }

        public void Stop()
        {
            isDriving = false;
            TripsSinceMaintenance++;
            if (TripsSinceMaintenance == 100)
            {
                Console.WriteLine("The plane produced by : " + Make);
                Console.WriteLine("Model of the Plane is : " + Model);
                Console.WriteLine("Produced year is : " + Year);
                Console.WriteLine("The Plane wieght is: " + Weight);
                NeedsMaintenance = true;
                Console.WriteLine("The Plane needs a maintennance!!! It will not fly unless it get repared!");
                Repair();
                Console.WriteLine("It is repaired. You can go!!!");
            }
        }

    }

}
