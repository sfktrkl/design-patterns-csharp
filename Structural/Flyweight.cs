using Structural.Flyweight;

namespace Structural.Flyweight
{
    public class Context
    {
        public string name;

        public Context(string name)
        {
            this.name = name;
        }
    }

    public class Flyweight
    {
        private Context context;

        public Flyweight(Context context)
        {
            this.context = context;
        }

        public void Operation(Context unique)
        {
            Console.WriteLine($"Flyweight shared: {context.name}\nFlyweight unique: {unique.name}");
        }
    }

    public class FlyweightFactory
    {
        private Dictionary<string, Flyweight> flyweights = new Dictionary<string, Flyweight>();

        public FlyweightFactory(Context[] contexts)
        {
            foreach (var context in contexts)
                flyweights[context.name] = new Flyweight(new Context(context.name));
        }

        public Flyweight GetFlyweight(Context context)
        {
            if (!flyweights.ContainsKey(context.name))
                flyweights[context.name] = new Flyweight(new Context(context.name));
            return flyweights[context.name];
        }
    }
}

namespace DesignPatterns
{
    partial class Structural
    {
        public static void Flyweight()
        {
            Helper.Run("Structural.Flyweight", () =>
            {
                var factory = new FlyweightFactory(new Context[] {
                    new Context("A"), new Context("B"), new Context("C")
                });
                var flyweight = factory.GetFlyweight(new Context("A"));
                flyweight.Operation(new Context("D"));
            });
        }
    }
}
