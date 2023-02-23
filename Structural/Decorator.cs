using Structural.Decorator;

namespace Structural.Decorator
{
    abstract class Component
    {
        public abstract string Operation();
    }

    class FirstComponent : Component
    {
        public override string Operation()
        {
            return "FirstComponent";
        }
    }

    abstract class Decorator : Component
    {
        private Component component;

        public Decorator(Component component)
        {
            this.component = component;
        }

        public override string Operation()
        {
            if (this.component is not null)
                return this.component.Operation();
            else
                return string.Empty;
        }
    }

    class FirstDecorator : Decorator
    {
        public FirstDecorator(Component component) : base(component)
        {
        }

        public override string Operation()
        {
            return "FirstDecorator(" + base.Operation() + ")";
        }
    }

    class SecondDecorator : Decorator
    {
        public SecondDecorator(Component component) : base(component)
        {
        }

        public override string Operation()
        {
            return "SecondDecorator(" + base.Operation() + ")";
        }
    }
}

namespace DesignPatterns
{
    partial class Structural
    {
        public static void Decorator()
        {
            Helper.Run("Structural.Decorator", () =>
            {
                var component = new FirstComponent();
                Console.WriteLine(component.Operation());

                var firstDecorator = new FirstDecorator(component);
                var secondDecorator = new SecondDecorator(firstDecorator);
                Console.WriteLine(secondDecorator.Operation());
            });
        }
    }
}
