using System;
using System.Collections.Generic;
using System.Text;

namespace Traffic
{
    public class Vehicle
    {
        public Vehicle() { }
     public double Calculate_vehicle_time(double _crater_time, double _vehicle_speed,double orbit_speed,double distance)
        {
            
            if (orbit_speed < _vehicle_speed)
                _vehicle_speed = orbit_speed;
            double _vehicle_time = (distance / _vehicle_speed) + _crater_time;
            return _vehicle_time;
        }
    }
    public interface IVehicle
    {
        int Vehicle_crater_cross_time { get; }
        double Vehicle_speed { get; set; }
        double Calculate_vehicletime(double craters, double distance, double orbit_speed);
    }

    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    
    public class Car : IVehicle
    {
        private  int _vehicle_crater_cross_time;
        private double _vehicle_speed; 
        public  int Vehicle_crater_cross_time
        {
            get { return _vehicle_crater_cross_time; }
        }
        public  double Vehicle_speed
        { get; set; }


        public Car()
        {
            _vehicle_speed = 20;
            _vehicle_crater_cross_time = 3;
        }
        public double Calculate_vehicletime(double craters, double distance, double orbit_speed)
        {
            Vehicle vehicle = new Vehicle();
            double _crater_time = (_vehicle_crater_cross_time * craters) / 60;           
            double _vehicle_time= vehicle.Calculate_vehicle_time(_crater_time, _vehicle_speed, orbit_speed, distance);
            return _vehicle_time;
        }
        
    }

    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    public class Bike : IVehicle
    {
        private  int _vehicle_crater_cross_time;
        private double _vehicle_speed;
        public int Vehicle_crater_cross_time
        {
            get { return _vehicle_crater_cross_time; }
        }
        public double Vehicle_speed
        { get; set; }

        public Bike()
        {
            this._vehicle_speed = 10;
            this._vehicle_crater_cross_time = 2;
        }
        public double Calculate_vehicletime(double craters, double distance, double orbit_speed)
        {
            Vehicle vehicle = new Vehicle();
            double _crater_time = (_vehicle_crater_cross_time * craters) / 60;
            double _vehicle_time = vehicle.Calculate_vehicle_time(_crater_time, _vehicle_speed, orbit_speed, distance);
            return _vehicle_time;
        }
    }

    public class Tuktuk : IVehicle
    {
        private readonly int _vehicle_crater_cross_time;
        private double _vehicle_speed;
        public int Vehicle_crater_cross_time
        {
            get { return _vehicle_crater_cross_time; }
        }
        public double Vehicle_speed
        { get; set; }
        public Tuktuk()
        {
            this._vehicle_speed = 12;
            this._vehicle_crater_cross_time = 1;
        }
        public double Calculate_vehicletime(double craters, double distance, double orbit_speed)
        {
            Vehicle vehicle = new Vehicle();
            double _crater_time = (_vehicle_crater_cross_time * craters) / 60;
            double _vehicle_time = vehicle.Calculate_vehicle_time(_crater_time, _vehicle_speed, orbit_speed, distance);
            return _vehicle_time;
        }
    }

    /// <summary>
    /// The Creator Abstract Class
    /// </summary>
    public abstract class VehicleFactory
    {
        public abstract IVehicle get_vehicle_time(string Vehicle);

    }

    /// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>
    public class ConcreteVehicleFactory : VehicleFactory
    {
        public override IVehicle get_vehicle_time(string Vehicle)
        {
            switch (Vehicle)
            {
                case "Car":
                    return new Car();
                case "Bike":
                    return new Bike();
                case "Tuktuk":
                    return new Tuktuk();
                default:
                    throw new ApplicationException(string.Format("Vehicle '{0}' cannot be created", Vehicle));
            }
        }

    }
}
