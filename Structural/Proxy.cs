using Structural.Proxy;

namespace Structural.Proxy
{
    public interface IService
    {
        void Operation();
    }

    class Service : IService
    {
        public void Operation()
        {
            Console.WriteLine("Service: Handle operation.");
        }
    }

    class Proxy : IService
    {
        private Service service;

        public Proxy(Service service)
        {
            this.service = service;
        }

        public void Operation()
        {
            if (this.CheckAccess())
                this.service.Operation();
        }

        public bool CheckAccess()
        {
            Console.WriteLine("Proxy: Checking access.");
            return true;
        }
    }
}

namespace DesignPatterns
{
    partial class Structural
    {
        public static void Proxy()
        {
            Helper.Run("Structural.Proxy", () =>
            {
                var service = new Service();
                service.Operation();

                var proxy = new Proxy(service);
                proxy.Operation();
            });
        }
    }
}
