namespace Prototype
{
    using System;

    class MainApp
    {
        static void Main()
        {
            Prototype prototype1 = new ConcretePrototype1("I");
            Prototype clonedPrototype1 = prototype1.Clone();
            Console.WriteLine("Cloned: {0}", clonedPrototype1.Id);

            Prototype prototype2 = new ConcretePrototype2("II");
            Prototype clonedPrototype2 = prototype2.Clone();
            Console.WriteLine("Cloned: {0}", clonedPrototype2.Id);
        }
    }

    public abstract class Prototype
    {
        public Prototype(string id)
        {
            this.Id = id;

            Console.Write("Base constructor is called.");
        }

        public string Id { get; private set; }

        public virtual Prototype Clone()
        {
            return (Prototype)this.MemberwiseClone();
        }
    }

    public class ConcretePrototype1 : Prototype
    {
        public ConcretePrototype1(string id) : base(id)
        {
        }
    }

    public class ConcretePrototype2 : Prototype
    {
        public ConcretePrototype2(string id) : base(id)
        {
        }
    }
}