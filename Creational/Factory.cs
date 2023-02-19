using Creational.Factory;

namespace Creational.Factory
{
    public interface IProduct
    {
        void Operation();
    }

    class FirstProduct : IProduct
    {
        public void Operation()
        {
            Console.Write("First Product");
        }
    }

    class SecondProduct : IProduct
    {
        public void Operation()
        {
            Console.Write("Second Product");
        }
    }

    abstract class Factory
    {
        public abstract IProduct FactoryMethod();

        public void Run()
        {
            var product = FactoryMethod();
            Console.Write("Created: ");
            product.Operation();
            Console.WriteLine("");
        }
    }

    class FirstProductFactory : Factory
    {
        public override IProduct FactoryMethod()
        {
            return new FirstProduct();
        }
    }

    class SecondProductFactory : Factory
    {
        public override IProduct FactoryMethod()
        {
            return new SecondProduct();
        }
    }
}

namespace DesignPatterns
{
    partial class Creational
    {
        public static void Factory()
        {
            Factory Initialize()
            {
                Random rng = new Random();
                int num = rng.Next(0, 10);
                if (num % 2 == 0)
                    return new FirstProductFactory();
                else
                    return new SecondProductFactory();
            };

            Helper.Run("Creational.Factory", () =>
            {
                var factory = Initialize();
                factory.Run();
            });
        }
    }
}
