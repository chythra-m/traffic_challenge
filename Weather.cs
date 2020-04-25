using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Traffic
{

    class Weather
    {
        static void Main(string[] args)
        {

            string line;
            string[] input;
            double orbit1_speed = 0, orbit2_speed = 0;
            string weather = "";
            double orbit1_leasttime = 0, orbit2_leasttime = 0;
            string orbit1_vehicle = "", orbit2_vehicle = "";
            int orbit1_craters = 20;
            int orbit2_craters = 10;
            double orbit1_distance = 18;
            double orbit2_distance = 20;


            
            try
            {
                string filename = Console.ReadLine();
                FileStream fileStream = new FileStream(filename, FileMode.Open);
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        input = line.Split(" ");
                        weather = input[0];
                        orbit1_speed = Convert.ToDouble(input[1]);
                        orbit2_speed = Convert.ToDouble(input[2]);

                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file or directory cannot be found.");
            }
        
            Orbit orbit1 = new Orbit(orbit1_speed, orbit1_distance, orbit1_craters);
            Orbit orbit2 = new Orbit(orbit2_speed, orbit2_distance, orbit2_craters);
            VehicleFactory factory = new ConcreteVehicleFactory();
            switch (weather)
            {
                case "SUNNY":
                    {
                        //Find the vehicle that takes the least time in Orbit1 and time taken by it


                        orbit1_vehicle = orbit1.calculate_sunnny_time().Item1;
                        orbit1_leasttime = orbit1.calculate_sunnny_time().Item2;

                        //Find the vehicle that takes the least time in Orbit2 and time taken by it
                        orbit2_vehicle = orbit2.calculate_sunnny_time().Item1;
                        orbit2_leasttime = orbit2.calculate_sunnny_time().Item2;

                    }
                    break;
                case "RAINY":
                    {
                        //Find the vehicle that takes the least time in Orbit1 and time taken by it
                        orbit1_vehicle = orbit1.calculate_rainy_time().Item1;
                        orbit1_leasttime = orbit1.calculate_rainy_time().Item2;

                        //Find the vehicle that takes the least time in Orbit2 and time taken by it
                        orbit2_vehicle = orbit2.calculate_rainy_time().Item1;
                        orbit2_leasttime = orbit2.calculate_rainy_time().Item2;
                    }
                    break;
                case "WINDY":
                    {
                        //Find the vehicle that takes the least time in Orbit1 and time taken by it
                        orbit1_vehicle = orbit1.calculate_windy_time().Item1;
                        orbit1_leasttime = orbit1.calculate_windy_time().Item2;

                        //Find the vehicle that takes the least time in Orbit2 and time taken by it
                        orbit2_vehicle = orbit2.calculate_windy_time().Item1;
                        orbit2_leasttime = orbit2.calculate_windy_time().Item2;
                    }
                    break;

            }
            try
            {
                if (orbit1_leasttime == orbit2_leasttime)
                {
                    switch (orbit1_vehicle)
                    {
                        case "CAR":
                            Console.WriteLine(orbit2_vehicle + " " + "ORBIT2");
                            break;
                        case "BIKE":
                            Console.WriteLine(orbit1_vehicle + " " + "ORBIT1");
                            break;
                        case "TUKTUK":
                            {
                                if (orbit2_vehicle == "BIKE")
                                    Console.WriteLine(orbit2_vehicle + " " + "ORBIT2");
                                else
                                    Console.WriteLine(orbit1_vehicle + " " + "ORBIT1");
                            }
                            break;
                        default:
                            new ApplicationException(string.Format("Invalid Data"));
                            break;
                    }
                }
                else
                {
                    if (orbit1_leasttime < orbit2_leasttime)
                    {
                        Console.WriteLine(orbit1_vehicle + " " + "ORBIT1");
                    }
                    else
                    {
                        Console.WriteLine(orbit2_vehicle + " " + "ORBIT2");
                    }
                }

            }

            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }



        }

    }
}