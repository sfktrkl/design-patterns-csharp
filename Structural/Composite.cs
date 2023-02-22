using Structural.Composite;

namespace Structural.Composite
{
    interface Component
    {
        void Search(string keyword);
    }

    class Leaf : Component
    {
        private string name;

        public Leaf(string name)
        {
            this.name = name;
        }

        public void Search(string keyword)
        {
            Console.WriteLine("Searching for " + keyword + " in " + name);
        }
    }

    class Composite : Component
    {
        private List<Component> components;
        private string name;

        public Composite(string name)
        {
            this.name = name;
            this.components = new List<Component>();
        }

        public void Add(Component component)
        {
            components.Add(component);
        }

        public void Search(string keyword)
        {
            Console.WriteLine("Searching recursively for " + keyword + " in " + name);
            foreach (var component in components)
                component.Search(keyword);
        }
    }
}


namespace DesignPatterns
{
    partial class Structural
    {
        public static void Composite()
        {
            Helper.Run("Structural.Composite", () =>
            {
                var firstLeaf = new Leaf("Leaf 1");
                var secondLeaf = new Leaf("Leaf 2");

                var firstComposite = new Composite("Composite 1");
                firstComposite.Add(firstLeaf);

                var secondComposite = new Composite("Composite 2");
                secondComposite.Add(secondLeaf);
                secondComposite.Add(firstComposite);

                secondComposite.Search("keyword");
            });
        }
    }
}

