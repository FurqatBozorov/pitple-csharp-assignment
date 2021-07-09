using System;

namespace ElevatorProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] Passengers = new int[100,3];
            Random randInt = new Random();
            for(int i=0; i<100; i++)
            {
                // First element is the time when button was pressed
                Passengers[i, 0] = randInt.Next(181);
                // This is the plase where the passenger is
                Passengers[i, 1] = randInt.Next(12)-1;
                // This is the place where the passenger wants to go
                Passengers[i, 2] = randInt.Next(12) - 1;
            }

            Button newPassenger = new Button();
            for(int q=0; q<181; q++)
            {
                for (int k=0;k<100; k++)
                {
                    if (Passengers[k, 0] == q)
                    {
                        newPassenger.PressButton(Passengers[k, 0], Passengers[k, 1], Passengers[k, 2]);
                    }

                }
             
            }

        }
    }

    class Elevator
    {
        public int lastPosition;
        public int reachesDestinationAt;
        public Elevator(int initialPosition=0, int initialReachTime=0 )
        {
            lastPosition = initialPosition;
            reachesDestinationAt = initialReachTime;
        }

    }

    class Button
    {
        int elevatorAcomesAt;
        int elevatorBcomesAt;
        int distanceOfA;
        int distanceOfB;

        Elevator elevatorA = new Elevator();
        Elevator elevatorB = new Elevator();

        public void PressButton(int buttonPressedTime,int whereThePassengerIs, int passengerDestination )
        {
            elevatorAcomesAt = elevatorA.reachesDestinationAt + Math.Abs(elevatorA.lastPosition - whereThePassengerIs);
            elevatorBcomesAt = elevatorB.reachesDestinationAt + Math.Abs(elevatorA.lastPosition - whereThePassengerIs);
            distanceOfA = Math.Abs(whereThePassengerIs-elevatorA.lastPosition);
            distanceOfB = Math.Abs(whereThePassengerIs - elevatorB.lastPosition);
            // This passenger is traveling from 10-floor to -1
            if(whereThePassengerIs==10 && passengerDestination== -1)
            {
                Console.WriteLine($"Elevator A moves to {whereThePassengerIs}");
                Console.WriteLine($"Elevator A opens the door");
                Console.WriteLine($"Elevator A close the door");
                Console.WriteLine($"Elevator A moves to {passengerDestination}");
                elevatorA.lastPosition = passengerDestination;
                elevatorA.reachesDestinationAt = elevatorAcomesAt + Math.Abs(whereThePassengerIs-passengerDestination);
                
            }
            // This passenger is traveling from -1 to 10 floor
            else if (whereThePassengerIs== -1 && passengerDestination == 10)
            {
                Console.WriteLine($"Elevator B moves to {whereThePassengerIs}");
                Console.WriteLine($"Elevator B opens the door");
                Console.WriteLine($"Elevator B close the door");
                Console.WriteLine($"Elevator B moves to {passengerDestination}");
                elevatorB.lastPosition = passengerDestination;
                elevatorB.reachesDestinationAt = elevatorBcomesAt + Math.Abs(whereThePassengerIs - passengerDestination);
            }
            //this is for passengers traveling from or to 10th floor
            else if (whereThePassengerIs ==10 || passengerDestination==10)
            {
                Console.WriteLine($"Elevator A moves to {whereThePassengerIs}");
                Console.WriteLine($"Elevator A opens the door");
                Console.WriteLine($"Elevator A close the door");
                Console.WriteLine($"Elevator A moves to {passengerDestination}");
                elevatorA.lastPosition = passengerDestination;
                elevatorA.reachesDestinationAt = elevatorAcomesAt + Math.Abs(whereThePassengerIs - passengerDestination);
            } //this is for passengers traveling from or to -1th floor
            else if (whereThePassengerIs == -1 || passengerDestination == -1)
            {
                Console.WriteLine($"Elevator B moves to {whereThePassengerIs}");
                Console.WriteLine($"Elevator B opens the door");
                Console.WriteLine($"Elevator B close the door");
                Console.WriteLine($"Elevator B moves to {passengerDestination}");
                elevatorB.lastPosition = passengerDestination;
                elevatorB.reachesDestinationAt = elevatorBcomesAt + Math.Abs(whereThePassengerIs - passengerDestination);
            }
            else
            {   //this is to check if elevators both are busy  at the time of pressing button
                if (elevatorA.reachesDestinationAt>buttonPressedTime && elevatorB.reachesDestinationAt > buttonPressedTime)
                {//this is to find if elevatorA get free earlier
                    if (elevatorAcomesAt < elevatorBcomesAt)
                    {
                        Console.WriteLine($"Elevator A moves to {whereThePassengerIs}");
                        Console.WriteLine($"Elevator A opens the door");
                        Console.WriteLine($"Elevator A close the door");
                        Console.WriteLine($"Elevator A moves to {passengerDestination}");
                        elevatorA.lastPosition = passengerDestination;
                        elevatorA.reachesDestinationAt = elevatorAcomesAt + Math.Abs(whereThePassengerIs - passengerDestination);

                    }//this is to find if elevatorB get free earlier
                    else if (elevatorAcomesAt > elevatorBcomesAt)
                    {
                        Console.WriteLine($"Elevator B moves to {whereThePassengerIs}");
                        Console.WriteLine($"Elevator B opens the door");
                        Console.WriteLine($"Elevator B close the door");
                        Console.WriteLine($"Elevator B moves to {passengerDestination}");
                        elevatorB.lastPosition = passengerDestination;
                        elevatorB.reachesDestinationAt = elevatorBcomesAt + Math.Abs(whereThePassengerIs - passengerDestination);
                    }
                    else
                    {// this is to find nearest elevator when both gets free at the same time 
                     // if passenger goes down, ElevatorB will serv 
                        if (whereThePassengerIs - passengerDestination > 0)
                        {
                            Console.WriteLine($"Elevator B moves to {whereThePassengerIs}");
                            Console.WriteLine($"Elevator B opens the door");
                            Console.WriteLine($"Elevator B close the door");
                            Console.WriteLine($"Elevator B moves to {passengerDestination}");
                            elevatorB.lastPosition = passengerDestination;
                            elevatorB.reachesDestinationAt = elevatorBcomesAt + Math.Abs(whereThePassengerIs - passengerDestination);
                        }// if passenger goes up , ElevatorA will serv
                        else if (whereThePassengerIs - passengerDestination < 0)
                        {
                            Console.WriteLine($"Elevator A moves to {whereThePassengerIs}");
                            Console.WriteLine($"Elevator A opens the door");
                            Console.WriteLine($"Elevator A close the door");
                            Console.WriteLine($"Elevator A moves to {passengerDestination}");
                            elevatorA.lastPosition = passengerDestination;
                            elevatorA.reachesDestinationAt = elevatorAcomesAt + Math.Abs(whereThePassengerIs - passengerDestination);

                        }
                    }
                    //this is for the option, when elevator A is busy, ElevatorB is free 
                    // if one elevator is busy, we will immediately call anothere one
                }
                else if (elevatorA.reachesDestinationAt>buttonPressedTime  && elevatorB.reachesDestinationAt<=buttonPressedTime)
                {
                    Console.WriteLine($"Elevator B moves to {whereThePassengerIs}");
                    Console.WriteLine($"Elevator B opens the door");
                    Console.WriteLine($"Elevator B close the door");
                    Console.WriteLine($"Elevator B moves to {passengerDestination}");
                    elevatorB.lastPosition = passengerDestination;
                    elevatorB.reachesDestinationAt = elevatorBcomesAt + Math.Abs(whereThePassengerIs - passengerDestination);

                }
                //this is for the option, when elevatorB is busy, ElevatorA is free 
                // if one elevator is busy, we will immediately call anothere one
                else if (elevatorA.reachesDestinationAt <= buttonPressedTime && elevatorB.reachesDestinationAt > buttonPressedTime)
                {
                    Console.WriteLine($"Elevator A moves to {whereThePassengerIs}");
                    Console.WriteLine($"Elevator A opens the door");
                    Console.WriteLine($"Elevator A close the door");
                    Console.WriteLine($"Elevator A moves to {passengerDestination}");
                    elevatorA.lastPosition = passengerDestination;
                    elevatorA.reachesDestinationAt = elevatorAcomesAt + Math.Abs(whereThePassengerIs - passengerDestination);
                }
                else if (elevatorA.reachesDestinationAt < buttonPressedTime && elevatorB.reachesDestinationAt < buttonPressedTime)
                {
                    if (distanceOfA>distanceOfB)
                    {
                        Console.WriteLine($"Elevator B moves to {whereThePassengerIs}");
                        Console.WriteLine($"Elevator B opens the door");
                        Console.WriteLine($"Elevator B close the door");
                        Console.WriteLine($"Elevator B moves to {passengerDestination}");
                        elevatorB.lastPosition = passengerDestination;
                        elevatorB.reachesDestinationAt = elevatorBcomesAt + Math.Abs(whereThePassengerIs - passengerDestination);

                    }else if (distanceOfA < distanceOfB)
                    {
                        Console.WriteLine($"Elevator A moves to {whereThePassengerIs}");
                        Console.WriteLine($"Elevator A opens the door");
                        Console.WriteLine($"Elevator A close the door");
                        Console.WriteLine($"Elevator A moves to {passengerDestination}");
                        elevatorA.lastPosition = passengerDestination;
                        elevatorA.reachesDestinationAt = elevatorAcomesAt + Math.Abs(whereThePassengerIs - passengerDestination);

                    }else if (distanceOfA == distanceOfB)
                    {
                        if (whereThePassengerIs - passengerDestination > 0)
                        {
                            Console.WriteLine($"Elevator B moves to {whereThePassengerIs}");
                            Console.WriteLine($"Elevator B opens the door");
                            Console.WriteLine($"Elevator B close the door");
                            Console.WriteLine($"Elevator B moves to {passengerDestination}");
                            elevatorB.lastPosition = passengerDestination;
                            elevatorB.reachesDestinationAt = elevatorBcomesAt + Math.Abs(whereThePassengerIs - passengerDestination);
                        }// if passenger goes up , ElevatorA will serv
                        else if (whereThePassengerIs - passengerDestination < 0)
                        {
                            Console.WriteLine($"Elevator A moves to {whereThePassengerIs}");
                            Console.WriteLine($"Elevator A opens the door");
                            Console.WriteLine($"Elevator A close the door");
                            Console.WriteLine($"Elevator A moves to {passengerDestination}");
                            elevatorA.lastPosition = passengerDestination;
                            elevatorA.reachesDestinationAt = elevatorAcomesAt + Math.Abs(whereThePassengerIs - passengerDestination);

                        }
                    }
                } else if (elevatorA.reachesDestinationAt == buttonPressedTime && elevatorB.reachesDestinationAt == buttonPressedTime)
                {
                    if (whereThePassengerIs - passengerDestination > 0)
                    {
                        Console.WriteLine($"Elevator B moves to {whereThePassengerIs}");
                        Console.WriteLine($"Elevator B opens the door");
                        Console.WriteLine($"Elevator B close the door");
                        Console.WriteLine($"Elevator B moves to {passengerDestination}");
                        elevatorB.lastPosition = passengerDestination;
                        elevatorB.reachesDestinationAt = elevatorBcomesAt + Math.Abs(whereThePassengerIs - passengerDestination);
                    }// if passenger goes up , ElevatorA will serv
                    else if (whereThePassengerIs - passengerDestination < 0)
                    {
                        Console.WriteLine($"Elevator A moves to {whereThePassengerIs}");
                        Console.WriteLine($"Elevator A opens the door");
                        Console.WriteLine($"Elevator A close the door");
                        Console.WriteLine($"Elevator A moves to {passengerDestination}");
                        elevatorA.lastPosition = passengerDestination;
                        elevatorA.reachesDestinationAt = elevatorAcomesAt + Math.Abs(whereThePassengerIs - passengerDestination);

                    }
                }
            }
        }

    }




}



