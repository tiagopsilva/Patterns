namespace Strategy
{
    using System;

    public static class Program
    {
        public static void Main()
        {
            Context context = new Context(new ConcreteStrategy1());
            context.ExecuteOperation();
            context.SetStrategy(new ConcreteStrategy2());
            context.ExecuteOperation();
        }
    }
    public interface IStrategy
    {
        void Algorithm();
    }

    public class ConcreteStrategy1 : IStrategy
    {
        public void Algorithm()
        {
            Console.WriteLine("Выполняется алгоритм стратегии 1.");
        }
    }

    public class ConcreteStrategy2 : IStrategy
    {
        public void Algorithm()
        {
            Console.WriteLine("Выполняется алгоритм стратегии 2.");
        }
    }

    public class Context
    {
        private IStrategy _strategy;

        public Context(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public void SetStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public void ExecuteOperation()
        {
            _strategy.Algorithm();
        }
    }
}