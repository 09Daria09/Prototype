using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Prototype
{

    public interface IClone_
    {
        Transport DeepCopy();
    }

    public class Engine
    {
        public double EnginePower { get; set; }

        public Engine(double idNumber)
        {
            EnginePower = idNumber;
        }

        public Engine()
        {
            EnginePower = 0;
        }
        public Engine DeepCopy()
        {
            return new Engine(EnginePower);
        }
    }

    public abstract class Transport : IClone_
    {
        public string Name { get; set; }
        public double Range { get; set; }
        public Engine engine { get; set; }

        public Transport(string name, double range, Engine engine)
        {
            Name = name;
            Range = range;
            this.engine = engine;
        }
        public abstract Transport DeepCopy();
    }
    public class Airplane : Transport
    {
        public int MaxAltitude { get; set; }
        public int MaxSpeed { get; set; }

        public Airplane(string name, double range, Engine engine, int maxAltitude, int maxSpeed)
            : base(name, range, engine)
        {
            MaxAltitude = maxAltitude;
            MaxSpeed = maxSpeed;
        }

        public override string ToString()
        {
            return $"{Name} - Max Altitude: {MaxAltitude} ft, Max Speed: {MaxSpeed} mph, Range: {Range} miles";
        }
        public override Transport DeepCopy()
        {
            Airplane copy = new Airplane(Name, Range, engine.DeepCopy(), MaxAltitude, MaxSpeed);
            return copy;
        }
    }
    public class Car : Transport
    {
        public int MaxPassengers { get; set; }
        public int MaxSpeed { get; set; }

        public Car(string name, double range, Engine engine, int maxPassengers, int maxSpeed)
            : base(name, range, engine)
        {
            MaxPassengers = maxPassengers;
            MaxSpeed = maxSpeed;
        }

        public override string ToString()
        {
            return $"{Name} - Max Passengers: {MaxPassengers}, Max Speed: {MaxSpeed} mph, Range: {Range} miles";
        }
        public override Transport DeepCopy()
        {
            Car copy = new Car(Name, Range, engine.DeepCopy(), MaxPassengers, MaxSpeed);
            return copy;
        }
    }
    public class Ship : Transport
    {
        public int MaxDisplacement { get; set; }
        public int MaxSpeed { get; set; }

        public Ship(string name, double range, Engine engine, int maxDisplacement, int maxSpeed)
            : base(name, range, engine)
        {
            MaxDisplacement = maxDisplacement;
            MaxSpeed = maxSpeed;
        }

        public override string ToString()
        {
            return $"{Name} - Max Displacement: {MaxDisplacement} tons, Max Speed: {MaxSpeed} knots, Range: {Range} miles";
        }
        public override Transport DeepCopy()
        {
            Ship copy = new Ship(Name, Range, engine.DeepCopy(), MaxDisplacement, MaxSpeed);
            return copy;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine(250);
            Airplane airplane = new Airplane("Boeing 747", 8000, engine, 45000, 570);
            Ship ship = new Ship("Titanic", 2600, engine, 52476, 23);
            Car car = new Car("Toyota Camry", 500, engine, 5, 120);

            Airplane copy = (Airplane)airplane.DeepCopy();

            Console.WriteLine($"Origin - {airplane}");
            Console.WriteLine($"Copy - {copy}");
        }
    }
}
