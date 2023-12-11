using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Dz
{
    public interface IObserver
    {
        void Update(string message);
    }

    public class Rocket
    {
        private List<IObserver> observers = new List<IObserver>();
        private string state;

        public string State
        {
            get { return state; }
            set
            {
                state = value;
                NotifyObservers();
            }
        }

        
        public void Attach(IObserver observer)
        {
            observers.Add(observer);
        }

        
        public void Detach(IObserver observer)
        {
            observers.Remove(observer);
        }

        
        private void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update(State);
            }
        }
    }

   
    public class Camera : IObserver
    {
        private string name;

        public Camera(string name)
        {
            this.name = name;
        }

        
        public void Update(string message)
        {
            Console.WriteLine($"{name} отримав повідомлення: {message}");
        }
    }

    class Program
    {
        static void Main()
        {
           
            Rocket rocket = new Rocket();

           
            Camera camera1 = new Camera("Camera 1");
            Camera camera2 = new Camera("Camera 2");

           
            rocket.Attach(camera1);
            rocket.Attach(camera2);

           
            rocket.State = "Новий стан";

            
            rocket.Detach(camera1);

            
            rocket.State = "Ще один новий стан";

            Console.ReadLine();
        }
    }
}
