using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Dz
{
    public class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Engine { get; set; }
        public string Transmission { get; set; }
        public string Color { get; set; }

        public void DisplayInfo()
        {
            Console.WriteLine($"Brand: {Brand}");
            Console.WriteLine($"Model: {Model}");
            Console.WriteLine($"Engine: {Engine}");
            Console.WriteLine($"Transmission: {Transmission}");
            Console.WriteLine($"Color: {Color}");
            Console.WriteLine();
        }
    }

    // Базовий інтерфейс для будівника автомобілів
    public interface ICarBuilder
    {
        void BuildBrand();
        void BuildModel();
        void BuildEngine();
        void BuildTransmission();
        void BuildColor();
        Car GetCar();
    }

    // Конкретний будівник для створення спортивного автомобіля
    public class SportsCarBuilder : ICarBuilder
    {
        private Car car = new Car();

        public void BuildBrand()
        {
            car.Brand = "Ferrari";
        }

        public void BuildModel()
        {
            car.Model = "488 GTB";
        }

        public void BuildEngine()
        {
            car.Engine = "V8 Twin Turbo";
        }

        public void BuildTransmission()
        {
            car.Transmission = "7-speed dual-clutch";
        }

        public void BuildColor()
        {
            car.Color = "Red";
        }

        public Car GetCar()
        {
            return car;
        }
    }

    // Директор, який визначає порядок створення автомобіля
    public class CarDirector
    {
        public Car Construct(ICarBuilder builder)
        {
            builder.BuildBrand();
            builder.BuildModel();
            builder.BuildEngine();
            builder.BuildTransmission();
            builder.BuildColor();

            return builder.GetCar();
        }
    }

    class Program
    {
        static void Main()
        {
            // Використання патерну Будівник
            CarDirector director = new CarDirector();
            ICarBuilder sportsCarBuilder = new SportsCarBuilder();

            Car sportsCar = director.Construct(sportsCarBuilder);
            sportsCar.DisplayInfo();

            Console.ReadLine();
        }
    }
}
