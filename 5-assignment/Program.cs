using System;

namespace assignmentFive
{
    class Program
    {
        static void Main(string[] args)
        {
            int tester = 0;
            for (int i = 1; i<101; i++)
            {
                if(i%15 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }else if (i%3==0)
                {
                    Console.WriteLine("Fizz");
                }else if (i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }else
                {
                    tester = 0;
                    for(int q=2; q<i; q++)
                    {
                        if (i % q == 0)
                        {
                            tester = 1;
                        }
                    }
                    if (tester == 0)
                    {
                        if (i==1)
                        {
                            Console.WriteLine(i);
                        }
                        else
                        {
                            Console.WriteLine("Prime");
                        }
                        
                    }else if(tester == 1)
                    {
                        Console.WriteLine(i);
                    }
                }
            }
        }
    }
}
