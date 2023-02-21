using Creational.Singleton;

namespace Creational.Singleton
{
    class ThreadSafeSingleton
    {
        public int Value { get; set; }

        private ThreadSafeSingleton()
        {
            this.Value = 0;
        }

        private static readonly object _lock = new object();
        private static ThreadSafeSingleton? instance = null;

        public static ThreadSafeSingleton Instance
        {
            get
            {
                if (instance is null)
                {
                    lock (_lock)
                    {
                        if (instance is null)
                        {
                            instance = new ThreadSafeSingleton();
                        }
                    }
                }
                return instance;
            }
        }
    }
}

namespace DesignPatterns
{
    partial class Creational
    {
        public static void Singleton()
        {
            Helper.Run("Creational.Singleton", () =>
            {
                void Test()
                {
                    var singleton = ThreadSafeSingleton.Instance;
                    Console.WriteLine("Init value: " + singleton.Value);
                    singleton.Value += 1;
                    Console.WriteLine("End value: " + singleton.Value);
                }
                Test();

                Thread process = new Thread(() =>
                {
                    Test();
                });

                process.Start();
                process.Join();

                Test();
            });
        }
    }
}
