using Creational.AbstractFactory;

namespace Creational.AbstractFactory
{
    public interface IProductA
    {
        void OperationA();
    }

    class FirstProductA : IProductA
    {
        public void OperationA()
        {
            Console.WriteLine("Created: First Product A");
        }
    }

    class SecondProductA : IProductA
    {
        public void OperationA()
        {
            Console.WriteLine("Created: Second Product A");
        }
    }

    public interface IProductB
    {
        void OperationB();
    }

    class FirstProductB : IProductB
    {
        public void OperationB()
        {
            Console.WriteLine("Created: First Product B");
        }
    }

    class SecondProductB : IProductB
    {
        public void OperationB()
        {
            Console.WriteLine("Created: Second Product B");
        }
    }

    public interface IAbstractFactory
    {
        public IProductA CreateProductA();
        public IProductB CreateProductB();
    }

    class FirstProductFactory : IAbstractFactory
    {
        public IProductA CreateProductA()
        {
            return new FirstProductA();
        }

        public IProductB CreateProductB()
        {
            return new FirstProductB();
        }
    }

    class SecondProductFactory : IAbstractFactory
    {
        public IProductA CreateProductA()
        {
            return new SecondProductA();
        }

        public IProductB CreateProductB()
        {
            return new SecondProductB();
        }
    }
}

namespace DesignPatterns
{
    partial class Creational
    {
        public static void AbstractFactory()
        {
            IAbstractFactory Initialize()
            {
                Random rng = new Random();
                int num = rng.Next(0, 10);
                if (num % 2 == 0)
                    return new FirstProductFactory();
                else
                    return new SecondProductFactory();
            };

            Helper.Run("Creational.AbstractFactory", () =>
            {
                var factory = Initialize();
                var productA = factory.CreateProductA();
                productA.OperationA();

                var productB = factory.CreateProductB();
                productB.OperationB();
            });
        }
    }
}