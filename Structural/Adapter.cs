using Structural.Adapter;

namespace Structural.Adapter
{
    public interface ITarget
    {
        string GetRequest();
    }

    class Adaptee
    {
        public string GetSpecificRequest()
        {
            return "tseuqer cificeps a";
        }
    }

    class Adapter : ITarget
    {
        private readonly Adaptee adaptee;

        public Adapter(Adaptee adaptee)
        {
            this.adaptee = adaptee;
        }

        public string GetRequest()
        {
            return new string(adaptee.GetSpecificRequest().Reverse().ToArray());
        }
    }
}

namespace DesignPatterns
{
    partial class Structural
    {
        public static void Adapter()
        {
            Helper.Run("Structural.Adapter", () =>
            {
                var adaptee = new Adaptee();
                Console.WriteLine(adaptee.GetSpecificRequest());

                var target = new Adapter(adaptee);
                Console.WriteLine(target.GetRequest());
            });
        }
    }
}
