using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Dz
{
    public abstract class Сomponents
    {
        public abstract void getСomponent();
    }
    class Processor : Сomponents
    {
        public int Frequency { get; set; }
        public int Cores { get; set; }

        public Processor(int frequency, int cores)
        {
            Frequency = frequency;
            Cores = cores;
        }

        public override void getСomponent()
        {
            Console.WriteLine(Frequency.ToString(), Cores);
        }
    }
    class RAM : Сomponents
    {
        public int Memory { get; set; }
        public int Speed { get; set; }
        public RAM(int memory, int speed)
        {
            Memory = memory;
            Speed = speed;
        }
        public override void getСomponent()
        {
            Console.WriteLine(Memory);
            Console.WriteLine(Speed);
        }
    }
    class Motherboard : Сomponents
    {
        public int Chipset { get; set; }

        public Motherboard(int chipset)
        {
            Chipset = chipset;
        }
        public override void getСomponent()
        {
            Console.WriteLine(Chipset);
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            RAM ram = new RAM(10, 4);
            ram.getСomponent();

            Сomponents[] сomponents = new Сomponents[]
            {
                new Processor(10, 8),
                new RAM(10, 8),
                new Motherboard(550)
            };
            foreach(var component in сomponents)
            {
                component.getСomponent();
            }
        }
    }
}
