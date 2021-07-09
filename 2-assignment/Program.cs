using System;

namespace homworkAssignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool cakeIsVanilla = true;
            if (cakeIsVanilla)
                Console.WriteLine("Cake is vanilla");
            else
                Console.WriteLine("Cake is chocolate");


            string allMenAre = "mortal";
            string Socrates = "man";

            if (allMenAre == "mortal" && Socrates == "man")
                Console.WriteLine("Socrates is mortal");
            else
                Console.WriteLine("Socrates is not mortal");

        }
    }
}
