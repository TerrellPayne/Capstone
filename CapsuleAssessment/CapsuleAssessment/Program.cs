using System;
using System.Threading.Channels;

namespace CapsuleAssessment
{
    class Program
    {
        static void Main(string[] arg)
        {
            bool keepWorking = true;
            Console.WriteLine("Welcome to Space-Capsule.");
            Console.WriteLine("=================================");
            string userInput;
            int index;
           
            do
            {
                Console.Write("Enter the number of capsules available: ");
                userInput = Console.ReadLine();
                
               
            } while (int.TryParse(userInput, out index) == false || index <= 0 || index > arg.Length +index);

           
            Console.WriteLine($"There are {userInput} unoccupied capsules ready to be booked");
            string[] taskList = new string[index];

            while (keepWorking)
            {
                string input = (PromptMenu() + "").ToUpper();


                switch (input)
                {
                    case "1":
                        DisplayGuest(taskList);
                        break;
                    case "2":
                        CheckIn(taskList);
                        break;
                    case "3":
                        CheckOut(taskList);
                        break;
                    case "4":
                        ExitMenu(keepWorking);
                        ;
                        break;
                    default:
                        break;


                }
            }
            static void DisplayGuest(string[] input)
            {
                Console.Clear();
                Console.WriteLine("View Guests");
                Console.WriteLine("================");

                string capsule ;
                int capView ;
                do
                {
                    Console.Write("Capsule #: ");
                    capsule = Console.ReadLine();

                } while (int.TryParse(capsule, out capView) == false || capView <= 0 || capView > input.Length);



                int min = capView - 5;
                int max = capView + 6;
                //HINT: starting should be 5 less than the user has entered, end point is 6 greater than the number entered.
                //if min is less zero, set to zero, if max greater than input length, set to input  length

                if (min < 0)
                {
                    min = 0;

                }
                if (capView > max)
                {
                    max = capView + (capView - max);
                }



                for (int i = min; i < max; i++)
                {


                    if (String.IsNullOrEmpty(input[i]))
                    {
                        Console.WriteLine(i + ":" + " [unoccupied]");
                        continue;

                    }
                   


                    Console.WriteLine($" {input[i]}");
                }


                PressEnterKey();
            }
            //========================================================================


            static string PromptMenu()
            {
                Console.WriteLine("Guest Menu");
                Console.WriteLine("================");
                Console.WriteLine("1. View Guest");
                Console.WriteLine("2. Check In");
                Console.WriteLine("3. Check Out");
                Console.WriteLine("4. Exit");




                Console.WriteLine("Choose on option [1-4]: ");
                return Console.ReadLine();



            }
            //=====================================================
            static string[] CheckIn(string[] input)
            {


                Console.WriteLine("Guest Check In ");
                Console.WriteLine("================");
                Console.Write("Guest Name: ");
                string name = Console.ReadLine();
                string capsuleNum = "";
                int index = 0;
                do
                {
                    Console.Write("Capsule #: ");
                    capsuleNum = Console.ReadLine();

                } while (int.TryParse(capsuleNum, out index) == false || index <= 0 || index > input.Length);







                if (input[index] == null)
                {
                    Console.WriteLine($"{name} is booked in capsule {capsuleNum}");
                    Console.WriteLine("=========================================");
                    input[index] = index + ": " + name;
                }
                else
                {
                    Console.WriteLine($"Capsule {capsuleNum} is occupied");
                }




                return input;
            }
            //========================================================================
            static void CheckOut(string[] input)
            {
                Console.WriteLine("Guest Check Out ");
                Console.WriteLine("================");
                Console.Write("Capsule #: ");
                string choice = "";
                int index = 0;
                do
                {
                    Console.Write("Please enter choice: ");
                    choice = Console.ReadLine();

                } while (int.TryParse(choice, out index) == false || index <= 0 || index > input.Length);



            if (input[index] == null)
            {
                Console.WriteLine("Error capsule unoccupied");
                Console.WriteLine("=========================================");
            }
            else
            {
                Console.WriteLine($"Guest is checked out");
                input[index] = null;
            }


        

               


                PressEnterKey();
            }
            //===================================================================
            //TODO: change to a boolean return, return false when the user wants to exit, return true if they want to stay in the app
            static bool ExitMenu(bool input)
            {
                Console.Write("Are you sure you want to exit? \nAll data will be lost. \nExit[y / n]: ");
                string inputa = Console.ReadLine().ToLower();

               if ( inputa == "y")
                {
                    System.Environment.Exit(1); 
                    
                }
                else 
                {
                    input = true;
                }
                return input;
            }
            //=====================================================================
            static void PressEnterKey()
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
            }

        }

    }
}




