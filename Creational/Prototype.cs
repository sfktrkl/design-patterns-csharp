using Creational.Prototype;

namespace Creational.Prototype
{
    class Info
    {
        public int field;

        public Info(int field)
        {
            this.field = field;
        }
    }

    public interface IPrototype
    {
        IPrototype Clone();
        void Print();
    }

    class Prototype : IPrototype
    {
        public int field;
        public Info info;

        public Prototype(int field)
        {
            this.field = field;
            this.info = new Info(2);
        }

        public IPrototype Clone()
        {
            var clone = (Prototype)this.MemberwiseClone();
            clone.info = new Info(this.info.field);
            return clone;
        }

        public void Print()
        {
            Console.WriteLine("field = " + field.ToString() + " info = " + info.field.ToString());
        }
    }
}

namespace DesignPatterns
{
    partial class Creational
    {
        public static void Prototype()
        {
            Helper.Run("Creational.Prototype", () =>
            {
                var prototype = new Prototype(1);
                Console.Write("Prototype: ");
                prototype.Print();

                var clone = prototype.Clone();
                Console.Write("Clone: ");
                clone.Print();

                prototype.info.field = 3;

                Console.Write("Prototype: ");
                prototype.Print();

                Console.Write("Clone: ");
                clone.Print();
            });
        }
    }
}
