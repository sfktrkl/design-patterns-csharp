using Behavioral.Visitor;

namespace Behavioral.Visitor
{
    public interface IComponent
    {
        void Accept(IVisitor visitor);
    }

    public class FirstComponent : IComponent
    {
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public string FirstOperation()
        {
            return "A: ";
        }
    }

    public class SecondComponent : IComponent
    {
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public string SecondOperation()
        {
            return "B: ";
        }
    }

    public interface IVisitor
    {
        void Visit(FirstComponent component);

        void Visit(SecondComponent component);
    }

    class FirstVisitor : IVisitor
    {
        public void Visit(FirstComponent component)
        {
            Console.WriteLine(component.FirstOperation() + "FirstVisitor");
        }

        public void Visit(SecondComponent component)
        {
            Console.WriteLine(component.SecondOperation() + "FirstVisitor");
        }
    }

    class SecondVisitor : IVisitor
    {
        public void Visit(FirstComponent component)
        {
            Console.WriteLine(component.FirstOperation() + "SecondVisitor");
        }

        public void Visit(SecondComponent component)
        {
            Console.WriteLine(component.SecondOperation() + "SecondVisitor");
        }
    }
}

namespace DesignPatterns
{
    partial class Behavioral
    {
        public static void Visitor()
        {
            Helper.Run("Behavioral.Visitor", () =>
            {
                var components = new List<IComponent>() {
                    new FirstComponent(), new SecondComponent()
                };

                var firstVisitor = new FirstVisitor();
                foreach (var component in components)
                    component.Accept(firstVisitor);

                var secondVisitor = new SecondVisitor();
                foreach (var component in components)
                    component.Accept(secondVisitor);
            });
        }
    }
}
