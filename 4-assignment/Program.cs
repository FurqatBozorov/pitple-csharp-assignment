using System;

namespace ComplexDataType
{
    class Program
    {
            static void Main(string[] args)
            {
                string myAnimalName = "Cow";
                int numberOflegs = 4;
                int numberOfTeeth = 32;
                double litrMilkADay = 15.15;
                bool isProduceMeat = true;
                char secondChar = 'o';
                string[] TopCattleBreed = new string[10];
            TopCattleBreed[0] = "Black Angus";
            TopCattleBreed[1] = "Charolais";
            TopCattleBreed[2] = "Hereford";
            TopCattleBreed[3] = "Simmental";
            TopCattleBreed[4] = "Red Angus";
            TopCattleBreed[5] = "Texas Longhorn";
            TopCattleBreed[6] = "Gelbvieh";
            TopCattleBreed[7] = "Holstein";
            TopCattleBreed[8] = "Limousin";
            TopCattleBreed[9] = "Highlands";

            CattleDetails cattle = new CattleDetails();
            cattle = CattleDetails.speed;

                Console.WriteLine(myAnimalName);
                Console.WriteLine(numberOflegs);
                Console.WriteLine(numberOfTeeth);
                Console.WriteLine(litrMilkADay);
                Console.WriteLine(isProduceMeat);
                Console.WriteLine(secondChar);
                Console.WriteLine(TopCattleBreed[8]);
                Console.WriteLine(cattle);

        }
        }
    enum CattleDetails
    {
        maxlivingyeasr,
        speed,
        dailySleep,
        everageWeight
    }

}


