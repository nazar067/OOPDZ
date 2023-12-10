using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Dz
{
    public interface IComponent
    {
        void Operation();
    }

    public class Falcon : IComponent
    {
        public void Operation()
        {
            Console.WriteLine("Запуск Falcon 9");
        }
    }
    
    public abstract class Decorator : IComponent
    {
        protected IComponent component;

        public Decorator(IComponent component)
        {
            this.component = component;
        }

        public virtual void Operation()
        {
            if (component != null)
            {
                component.Operation();
            }
        }
    }

    public class RocketStageA : Decorator
    {
        public RocketStageA(IComponent component) : base(component)
        {
        }

        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("Знищеня ступеня А");
        }
    }

    public class RocketStageB : Decorator
    {
        public RocketStageB(IComponent component) : base(component)
        {
        }

        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("Знищеня ступеня B");
        }
    }

    class Program
    {
        static void Main()
        {
            IComponent component = new Falcon();

            IComponent decoratedComponentA = new RocketStageA(component);
            IComponent decoratedComponentB = new RocketStageB(decoratedComponentA);

            decoratedComponentB.Operation();
        }
    }
}
