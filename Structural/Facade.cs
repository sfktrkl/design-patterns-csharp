using Structural.Facade;

namespace Structural.Facade
{
    public class Facade
    {
        protected FirstSubsystem firstSubsystem;

        protected SecondSubsystem secondSubsystem;

        public Facade(FirstSubsystem firstSubsystem, SecondSubsystem secondSubsystem)
        {
            this.firstSubsystem = firstSubsystem;
            this.secondSubsystem = secondSubsystem;
        }

        public void Operation()
        {
            string result = "Facade: ";
            result += this.firstSubsystem.Operation();
            result += ", ";
            result += this.firstSubsystem.Operation();
            Console.WriteLine(result);
        }
    }

    public class FirstSubsystem
    {
        public string Operation()
        {
            return "FirstSubsystem";
        }
    }

    public class SecondSubsystem
    {
        public string Operation()
        {
            return "SecondSubsystem";
        }
    }
}

namespace DesignPatterns
{
    partial class Structural
    {
        public static void Facade()
        {
            Helper.Run("Structural.Facade", () =>
            {
                var firstSubsystem = new FirstSubsystem();
                var secondSubsystem = new SecondSubsystem();
                var facade = new Facade(firstSubsystem, secondSubsystem);
                facade.Operation();
            });
        }
    }
}
