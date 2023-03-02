using Behavioral.State;

namespace Behavioral.State
{
    class Context
    {
        private State state;

        public Context(State state)
        {
            this.state = state;
            Console.WriteLine("Context: " + this.state.GetType().Name);
        }

        public void RequestA()
        {
            this.state = this.state.OperationA();
            Console.WriteLine("Context: " + this.state.GetType().Name);
        }

        public void RequestB()
        {
            this.state = this.state.OperationB();
            Console.WriteLine("Context: " + this.state.GetType().Name);
        }
    }

    interface State
    {
        State OperationA();

        State OperationB();
    }

    class FirstState : State
    {
        public State OperationA()
        {
            return new SecondState();
        }

        public State OperationB()
        {
            return this;
        }
    }

    class SecondState : State
    {
        public State OperationA()
        {
            return this;
        }

        public State OperationB()
        {
            return new FirstState();
        }
    }
}

namespace DesignPatterns
{
    partial class Behavioral
    {
        public static void State()
        {
            Helper.Run("Behavioral.State", () =>
            {
                var context = new Context(new FirstState());
                context.RequestA();
                context.RequestB();
            });
        }
    }
}
