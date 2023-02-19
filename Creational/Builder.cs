using Creational.Builder;

namespace Creational.Builder
{
    class Product
    {
        private List<string> parts = new List<string>();

        public void Add(string part)
        {
            this.parts.Add(part);
        }

        public void ListParts()
        {
            Console.Write("Created: ");
            for (int i = 0; i < this.parts.Count; i++)
                Console.Write(this.parts[i] + (this.parts.Count > (i + 1) ? ", " : ""));
            Console.WriteLine("");
        }
    }

    public interface IBuilder
    {
        void BuildPartA();
        void BuildPartB();
        void BuildPartC();
    }

    class Builder : IBuilder
    {
        private Product product = new Product();

        public void BuildPartA()
        {
            product.Add("Part A");
        }

        public void BuildPartB()
        {
            product.Add("Part B");
        }

        public void BuildPartC()
        {
            product.Add("Part C");
        }

        public Product GetProduct()
        {
            var product = this.product;
            this.product = new Product();
            return product;
        }
    }

    public class Director
    {
        private IBuilder builder;

        public Director(IBuilder builder)
        {
            this.builder = builder;
        }

        public void BuildMinimalProduct()
        {
            builder.BuildPartA();
        }

        public void BuildFullProduct()
        {
            builder.BuildPartA();
            builder.BuildPartB();
            builder.BuildPartC();
        }
    }
}

namespace DesignPatterns
{
    partial class Creational
    {
        public static void Builder()
        {
            Helper.Run("Creational.Builder", () =>
            {
                var builder = new Builder();
                var director = new Director(builder);

                director.BuildMinimalProduct();
                builder.GetProduct().ListParts();

                director.BuildMinimalProduct();
                builder.BuildPartB();
                builder.GetProduct().ListParts();

                director.BuildFullProduct();
                builder.GetProduct().ListParts();
            });
        }
    }
}
