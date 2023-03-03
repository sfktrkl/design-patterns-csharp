using Behavioral.TemplateMethod;

namespace Behavioral.TemplateMethod
{
    abstract class AbstractClass
    {
        public void TemplateMethod()
        {
            this.BaseOperation();
            this.Hook();
            this.RequiredOperation();
        }

        protected void BaseOperation()
        {
            Console.Write("TemplateMethod");
        }

        protected abstract void RequiredOperation();

        protected virtual void Hook()
        {
            Console.Write(" -> ");
        }
    }

    class FirstClass : AbstractClass
    {
        protected override void RequiredOperation()
        {
            Console.WriteLine("FirstClass");
        }
    }

    class SecondClass : AbstractClass
    {
        protected override void RequiredOperation()
        {
            Console.WriteLine("SecondClass");
        }

        protected override void Hook()
        {
            Console.Write(" => ");
        }
    }
}

namespace DesignPatterns
{
    partial class Behavioral
    {
        public static void TemplateMethod()
        {
            Helper.Run("Behavioral.TemplateMethod", () =>
            {
                var firstClass = new FirstClass();
                firstClass.TemplateMethod();

                var secondClass = new SecondClass();
                secondClass.TemplateMethod();
            });
        }
    }
}
