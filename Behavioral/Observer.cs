using Behavioral.Observer;

namespace Behavioral.Observer
{
    public interface IObserver
    {
        void Update(ISubject subject);
    }

    public interface ISubject
    {
        void Attach(IObserver observer);

        void Detach(IObserver observer);

        void Notify();
    }

    public class Subject : ISubject
    {
        public int State { get; set; } = 0;

        private List<IObserver> observers = new List<IObserver>();

        public void Attach(IObserver observer)
        {
            this.observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            this.observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in observers)
                observer.Update(this);
            Console.WriteLine("");
        }

        public void Operation()
        {
            this.State++;
            Console.Write("Subject " + this.State + ":");
            this.Notify();
        }
    }

    class FirstObserver : IObserver
    {
        public void Update(ISubject subject)
        {
            if (subject is Subject s && s.State % 2 == 0)
                Console.Write(" FirstObserver");
        }
    }

    class SecondObserver : IObserver
    {
        public void Update(ISubject subject)
        {
            if (subject is Subject s && s.State % 3 == 0)
                Console.Write(" SecondObserver");
        }
    }
}

namespace DesignPatterns
{
    partial class Behavioral
    {
        public static void Observer()
        {
            Helper.Run("Behavioral.Observer", () =>
            {
                var subject = new Subject();
                var firstObserver = new FirstObserver();
                var secondObserver = new SecondObserver();

                subject.Attach(firstObserver);
                subject.Attach(secondObserver);

                subject.Operation();
                subject.Operation();
                subject.Operation();

                subject.Detach(firstObserver);
                subject.Operation();
            });
        }
    }
}
