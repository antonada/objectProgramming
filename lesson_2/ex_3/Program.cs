using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex_3
{
    public enum EngineStatus
    {
        Running,
        Stopped,
        CheckEngine
    }

    public class Car
    {
        public string Brand { get; }
        public string Model { get; }
        public int YearOfProduction { get; }

        private int speed;
        private int mileage;
        private EngineStatus engineStatus;

        public Car(string brand, string model, int yearOfProduction)
        {
            Brand = brand;
            Model = model;
            YearOfProduction = yearOfProduction;
            speed = 0;
            mileage = 0;
            engineStatus = EngineStatus.Stopped;
        }

        public void SetCruiseControl(int targetSpeed)
        {
            if (engineStatus == EngineStatus.Running)
            {
                speed = targetSpeed;
            }
        }

        public void IncreaseSpeed()
        {
            if (engineStatus == EngineStatus.Running)
            {
                speed += 5;
            }
        }

        public void ReduceSpeed()
        {
            if (engineStatus == EngineStatus.Running)
            {
                speed -= 5;
            }
        }

        public void StartEngine()
        {
            if (mileage <= 10000)
            {
                engineStatus = EngineStatus.Running;
            }
            else
            {
                engineStatus = EngineStatus.CheckEngine;
                throw new InvalidOperationException("Engine status is 'Check Engine'. You cant start the engine.");
            }
        }

        public void StopEngine()
        {
            engineStatus = EngineStatus.Stopped;
        }

        public TimeSpan CoverDistance(int distance)
        {
            if (engineStatus != EngineStatus.Running)
            {
                throw new InvalidOperationException("The engine is not running.");
            }

            if (mileage + distance > 10000)
            {
                engineStatus = EngineStatus.CheckEngine;
                throw new InvalidOperationException("Engine status is 'Check Engine'. Cant cover the distance.");
            }

            mileage += distance;
            double time = (double)distance / speed;
            return TimeSpan.FromHours(time);
        }

        public void EngineRepair()
        {
            engineStatus = EngineStatus.Stopped;
        }

        public int Speed
        {
            get
            {
                return speed;
            }
        }
    }

    public class Person
    {
        private string name;
        private string surname;
        private Car car;

        public Person(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
        }

        public string NameAndSurname => $"{name} {surname}";

        public bool IsAdult(int age)
        {
            return age >= 18;
        }

        public void ChangeName(string newName)
        {
            name = newName;
        }

        public void SetCarOwnership(Car car)
        {
            this.car = car;
        }

        public string GetCarInformation()
        {
            if (car != null)
            {
                return $"Car: {car.Brand} {car.Model}, Year of Production: {car.YearOfProduction}";
            }
            return "No car is owned.";
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
