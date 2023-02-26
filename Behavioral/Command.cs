using Behavioral.Command;

namespace Behavioral.Command
{
    public interface ICommand
    {
        void Execute();
    }

    class FirstCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("FirstCommand");
        }
    }

    class SecondCommand : ICommand
    {
        private Receiver receiver;

        private string param;

        public SecondCommand(Receiver receiver, string param)
        {
            this.receiver = receiver;
            this.param = param;
        }

        public void Execute()
        {
            Console.Write("SecondCommand, ");
            this.receiver.Operation(this.param);
        }
    }

    class Receiver
    {
        public void Operation(string param)
        {
            Console.WriteLine($"Receiver {param}");
        }
    }

    class Invoker
    {
        public ICommand? OnStart { private get; set; }
        public ICommand? OnFinish { private get; set; }

        public void ExecuteCommand()
        {
            Console.Write("OnStart: ");
            if (OnStart is ICommand)
                OnStart.Execute();

            Console.Write("OnFinish: ");
            if (OnFinish is ICommand)
                OnFinish.Execute();
        }
    }
}

namespace DesignPatterns
{
    partial class Behavioral
    {
        public static void Command()
        {
            Helper.Run("Behavioral.Command", () =>
            {
                Invoker invoker = new Invoker();
                invoker.OnStart = new FirstCommand();

                Receiver receiver = new Receiver();
                invoker.OnFinish = new SecondCommand(receiver, "Send email");

                invoker.ExecuteCommand();
            });
        }
    }
}
