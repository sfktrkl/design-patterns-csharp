namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Creational.Factory();
            Creational.AbstractFactory();
            Creational.Builder();
            Creational.Prototype();
            Creational.Singleton();

            Structural.Adapter();
            Structural.Bridge();
            Structural.Composite();
            Structural.Decorator();
            Structural.Facade();
            Structural.Flyweight();
            Structural.Proxy();

            Behavioral.ChainofResponsibility();
            Behavioral.Command();
            Behavioral.Iterator();
            Behavioral.Mediator();
            Behavioral.Memento();
            Behavioral.Observer();
        }
    }
}