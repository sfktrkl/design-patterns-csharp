using Behavioral.Strategy;

namespace Behavioral.Strategy
{
    class Context
    {
        private IStrategy? strategy;
        private List<string> data;

        public Context()
        {
            data = new List<string> { "c", "d", "a", "b", "e" };
        }

        public void SetStrategy(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void Operation()
        {
            strategy?.Operation(this.data);
            Console.WriteLine("Context: " + string.Join(", ", data.ToArray()));
        }
    }

    public interface IStrategy
    {
        void Operation(List<string> data);
    }

    class FirstStrategy : IStrategy
    {
        public void Operation(List<string> data)
        {
            data.Sort();
        }
    }

    class SecondStrategy : IStrategy
    {
        public void Operation(List<string> data)
        {
            data.Sort();
            data.Reverse();
        }
    }
}

namespace DesignPatterns
{
    partial class Behavioral
    {
        public static void Strategy()
        {
            Helper.Run("Behavioral.Strategy", () =>
            {
                var context = new Context();
                context.Operation();

                context.SetStrategy(new FirstStrategy());
                context.Operation();

                context.SetStrategy(new SecondStrategy());
                context.Operation();
            });
        }
    }
}
