using Structural.Bridge;

namespace Structural.Bridge
{
    class Abstraction
    {
        protected IImplementation implementation;

        public Abstraction(IImplementation implementation)
        {
            this.implementation = implementation;
        }

        public virtual void Operation()
        {
            Console.WriteLine("Abstract: " + implementation.Operation());
        }
    }

    class RefinedAbstraction : Abstraction
    {
        public RefinedAbstraction(IImplementation implementation) : base(implementation)
        {
        }

        public override void Operation()
        {
            Console.WriteLine("RefinedAbstraction: " + implementation.Operation());
        }
    }

    public interface IImplementation
    {
        string Operation();
    }

    class FirstImplementation : IImplementation
    {
        public string Operation()
        {
            return "FirstImplementation";
        }
    }

    class SecondImplementation : IImplementation
    {
        public string Operation()
        {
            return "SecondImplementation";
        }
    }
}

namespace DesignPatterns
{
    partial class Structural
    {
        public static void Bridge()
        {
            Helper.Run("Structural.Bridge", () =>
            {
                var firstImplementation = new FirstImplementation();
                var abstraction = new Abstraction(firstImplementation);
                abstraction.Operation();

                var secondImplementation = new SecondImplementation();
                var extendedAbstraction = new RefinedAbstraction(secondImplementation);
                extendedAbstraction.Operation();
            });
        }
    }
}
