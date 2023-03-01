using Behavioral.Memento;

namespace Behavioral.Memento
{
    class Originator
    {
        private string state;

        public Originator(string state)
        {
            this.state = state;
            Console.WriteLine("Originator: " + state);
        }

        public void Operation()
        {
            state += "-operation";
            Console.WriteLine("Originator: " + state);
        }

        public IMemento Save()
        {
            return new Memento(this.state);
        }

        public void Restore(IMemento memento)
        {
            this.state = memento.GetState();
            Console.WriteLine("Originator: " + state);
        }
    }

    public interface IMemento
    {
        string GetState();
    }

    class Memento : IMemento
    {
        private string state;

        public Memento(string state)
        {
            this.state = state;
        }

        public string GetState()
        {
            return this.state;
        }
    }

    class Caretaker
    {
        private Originator originator;
        private List<IMemento> history = new List<IMemento>();

        public Caretaker(Originator originator)
        {
            this.originator = originator;
        }

        public void Backup()
        {
            this.history.Add(this.originator.Save());
        }

        public void Undo()
        {
            if (this.history.Count == 0)
                return;

            var memento = this.history.Last();
            this.history.Remove(memento);
            this.originator.Restore(memento);
        }
    }
}

namespace DesignPatterns
{
    partial class Behavioral
    {
        public static void Memento()
        {
            Helper.Run("Behavioral.Memento", () =>
            {
                Originator originator = new Originator("original");
                Caretaker caretaker = new Caretaker(originator);

                caretaker.Backup();
                originator.Operation();

                caretaker.Backup();
                originator.Operation();

                caretaker.Undo();
                caretaker.Undo();
            });
        }
    }
}
