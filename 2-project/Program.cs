using System;

namespace timeadder
{
    class Program
    {
        static void Main(string[] args)
        {
            timeAdder();
        }

        static int value1;
        static int convertedValue1;
        static string label1;
        static int value2;
        static int convertedValue2;
        static string label2;
        static int resultInSeconds;
        static int value3;
        static string value3String;
        static string label3;
        static string[] myResultToReturn = new string[2]; 

        static void timeAdder()
        {
            timeValueValidator("Please, enter first time value you wanna add", 1);
            timeLableValidator("Please, enter first time label you wanna add", 1);
            timeValueValidator("Please, enter another time value you wanna add", 2);
            timeLableValidator("Please, enter second time label you wanna add", 2);

            convertedValue1 = ConvertToSeconds(value1, label1);
            convertedValue2 = ConvertToSeconds(value2, label2);
            resultInSeconds = convertedValue1 + convertedValue2;

            LastProccess(resultInSeconds);
            value3String = value3.ToString();

            myResultToReturn[0] = value3String;
            myResultToReturn[1]=label3;

            Console.WriteLine($"{myResultToReturn[0]}-{myResultToReturn[1]}");
            
        }


        static void timeValueValidator(string mess, int val)
        {
             string userInput;
            Console.WriteLine(mess);
            userInput= Console.ReadLine();
            int i;
            bool bNum = int.TryParse(userInput, out i);
            
            if (!bNum || i<0) {
                Console.WriteLine("You entered wrong value, Please try again!");
                 timeValueValidator(mess,val);
            }
            else
            {
                if(val == 1)
                {
                    value1 = i;
                }else if(val == 2)
                {
                    value2 = i;
                }
            }
        }

        static void timeLableValidator(string mess, int val)
        {
            string userInput;
            Console.WriteLine(mess);
            userInput = Console.ReadLine();
            char lastletter = userInput[userInput.Length - 1];
            if(val == 1 && value1>1)
            {
                if (lastletter != 's')
                {
                    Console.WriteLine(" Plural numbers should have plural ends");
                    timeLableValidator(mess, val);
                }
                else
                {
                    label1 = userInput;
                }
               
            }else if (val == 1 && value1 <= 1)
            {
                if (lastletter == 's')
                {
                    Console.WriteLine(" Singular numbers should not have plural ends");
                    timeLableValidator(mess, val);
                }
                else
                {
                    label1 = userInput;
                }

            }
            else if (val == 2 && value1 > 1)
            {
                if (lastletter != 's')
                {
                    Console.WriteLine(" Plural numbers should have plural ends");
                    timeLableValidator(mess, val);
                }
                else
                {
                    label2 = userInput;
                }

            }
            else if (val == 2 && value1 <= 1)
            {
                if (lastletter == 's')
                {
                    Console.WriteLine(" Singular numbers should not have plural ends");
                    timeLableValidator(mess, val);
                }
                else
                {
                    label2 = userInput;
                }

            }

        }

        static int ConvertToSeconds(int val, string lab)
        {
            if(lab == "second" ||  lab == "seconds")
            {
                return val * 1;
            }else if (lab == "minute" || lab == "minutes") 
            {
                return val * 1 * 60;
            }
            else if (lab == "hour" || lab == "hours")
            {
                return val * 1 * 60*60;
            }
            else if (lab == "day" || lab == "days")
            {
                return val * 1 * 60*60*24;
            }
            return 0;

        }

        static void LastProccess(int value) {
        if(value%(60 * 60 * 24) == 0)
            {
                value3 = value / (60 * 60 * 24);
                if (value3 > 1)
                {
                    label3 = "days";
                }
                else
                {
                    label3 = "day";
                }
            }else if (value % (60 * 60 ) == 0)
            {
                value3 = value / (60 * 60 );
                if (value3 > 1)
                {
                    label3 = "hours";
                }
                else
                {
                    label3 = "hour";
                }
            }else if (value % (60 ) == 0)
            {
                value3 = value / (60 );
                if (value3 > 1)
                {
                    label3 = "minutes";
                }
                else
                {
                    label3 = "minute";
                }
            }else 
            {
                value3 = value;
                if (value3 > 1)
                {
                    label3 = "seconds";
                }
                else
                {
                    label3 = "second";
                }
            }

        }
    }
}
