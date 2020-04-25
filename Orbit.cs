using System;
using System.Collections.Generic;
using System.Text;

namespace Traffic
{
    public class Orbit 
    {
        public readonly double _speed, _distance;
        public int _craters;

        public Orbit(double speed, double distance,int craters)
        {
            _speed = speed;
            _distance = distance;
            _craters = craters;
        }

        VehicleFactory factory = new ConcreteVehicleFactory();


        //Finds the vehicle that takes the least time during Sunny weather
        public  Tuple<string, double> calculate_sunnny_time()
        {
            double _least_time, _minimum_time;
            string _vehicle;

            double sunny_craters = Convert.ToDouble(_craters - (_craters * 0.1));
            IVehicle car = factory.get_vehicle_time("Car");
            IVehicle bike = factory.get_vehicle_time("Bike");
            IVehicle tuktuk = factory.get_vehicle_time("Tuktuk");
            
            double car_time = car.Calculate_vehicletime(sunny_craters, _distance, _speed);
            double bike_time = bike.Calculate_vehicletime(sunny_craters, _distance, _speed);
            double tuktuk_time = tuktuk.Calculate_vehicletime(sunny_craters, _distance, _speed);
            
            if ((car_time==bike_time)&(bike_time==tuktuk_time))
            {
                _least_time = bike_time;
                _vehicle = "BIKE";
            }
            else if((car_time == bike_time)&(tuktuk_time >bike_time))
            {
                _least_time = bike_time;
                _vehicle = "BIKE";

            }
            else if ((tuktuk_time == bike_time) & (car_time > tuktuk_time))
            {
                _least_time = bike_time;
                _vehicle = "BIKE";
            }
            else if((car_time == tuktuk_time) & (bike_time > tuktuk_time))
            {
                _least_time = tuktuk_time;
                _vehicle = "TUKTUK";
            }

            else
            {
                _minimum_time = Math.Min(car_time, Math.Min(bike_time, tuktuk_time));
                if (_minimum_time == car_time)
                {
                    _least_time = car_time;
                    _vehicle = "CAR";
                }
                else if (_minimum_time == bike_time)
                {
                    _least_time = bike_time;
                    _vehicle = "BIKE";
                }
                else
                {
                    _least_time = tuktuk_time;
                    _vehicle = "TUKTUK";
                }
            }
            return new Tuple<string, double>(_vehicle, _least_time);
        }
        //Finds the vehicle that takes the least time during Rainy weather
        public  Tuple<string, double> calculate_rainy_time()
        {
            double _least_time,_minimum_time;
            string _vehicle;

            double rainy_craters = Convert.ToDouble(_craters + (_craters * 0.2));

            IVehicle car = factory.get_vehicle_time("Car");
            IVehicle tuktuk = factory.get_vehicle_time("Tuktuk");

            double car_time = car.Calculate_vehicletime(rainy_craters, _distance, _speed);
            double tuktuk_time = tuktuk.Calculate_vehicletime(rainy_craters, _distance, _speed);

            if(!(car_time==tuktuk_time))
            {
                _minimum_time = Math.Min(car_time, tuktuk_time);

                if (_minimum_time == car_time)
                {
                    _least_time = car_time;
                    _vehicle = "CAR";
                }
                else
                {
                    _least_time = tuktuk_time;
                    _vehicle = "TUKTUK";
                }
                return new Tuple<string, double>(_vehicle, _least_time);
            }
            _least_time = tuktuk_time;
            _vehicle = "TUKTUK";
            return new Tuple<string, double>(_vehicle, _least_time);
        }
        //Finds the vehicle that takes the least time during Windy weather
        public  Tuple<string, double> calculate_windy_time()
        {
            double _least_time, _minimum_time;
            string _vehicle;

            IVehicle car = factory.get_vehicle_time("Car");
            IVehicle bike = factory.get_vehicle_time("Bike");

            double car_time = car.Calculate_vehicletime(_craters, _distance, _speed);
            double bike_time = bike.Calculate_vehicletime(_craters, _distance, _speed);
            if(!(car_time==bike_time))
            {
                _minimum_time = Math.Min(car_time, bike_time);

                if (_minimum_time == car_time)
                {
                    _least_time = car_time;
                    _vehicle = "CAR";
                }
                else
                {
                    _least_time = bike_time;
                    _vehicle = "BIKE";
                }
                return new Tuple<string, double>(_vehicle, _least_time);
            }
            _least_time = bike_time;
            _vehicle = "BIKE";

            return new Tuple<string, double>(_vehicle, _least_time);
        }
    }
}
