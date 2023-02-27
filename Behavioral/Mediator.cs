using Behavioral.Mediator;

namespace Behavioral.Mediator
{
    public interface IMediator
    {
        void Notify(object sender, string e);
    }

    class Mediator : IMediator
    {
        private FirstComponent firstComponent;

        private SecondComponent secondComponent;

        public Mediator(FirstComponent firstComponent, SecondComponent secondComponent)
        {
            this.firstComponent = firstComponent;
            this.firstComponent.SetMediator(this);
            this.secondComponent = secondComponent;
            this.secondComponent.SetMediator(this);
        }

        public void Notify(object sender, string e)
        {
            if (e == "A")
            {
                Console.Write("Mediator: ");
                this.secondComponent.OperationB();
            }
        }
    }

    abstract class Component
    {
        protected IMediator? mediator;

        public void SetMediator(IMediator mediator)
        {
            this.mediator = mediator;
        }
    }

    class FirstComponent : Component
    {
        public void OperationA()
        {
            Console.WriteLine("FirstComponent does A.");
            this.mediator?.Notify(this, "A");
        }
    }

    class SecondComponent : Component
    {
        public void OperationB()
        {
            Console.WriteLine("SecondComponent does B.");
            this.mediator?.Notify(this, "B");
        }
    }
}

namespace DesignPatterns
{
    partial class Behavioral
    {
        public static void Mediator()
        {
            Helper.Run("Behavioral.Mediator", () =>
            {
                // The client code.
                var firstComponent = new FirstComponent();
                var secondComponent = new SecondComponent();
                var mediator = new Mediator(firstComponent, secondComponent);

                Console.Write("Client: ");
                firstComponent.OperationA();
            });
        }
    }
}
