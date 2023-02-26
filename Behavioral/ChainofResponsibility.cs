using Behavioral.ChainofResponsibility;

namespace Behavioral.ChainofResponsibility
{
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);

        string Handle(string request);
    }

    abstract class AbstractHandler : IHandler
    {
        private IHandler? handler;

        public IHandler SetNext(IHandler handler)
        {
            this.handler = handler;
            return handler;
        }

        public virtual string Handle(string request)
        {
            if (this.handler != null)
                return this.handler.Handle(request);
            else
                return request;
        }
    }

    class FirstHandler : AbstractHandler
    {
        public override string Handle(string request)
        {
            if (request is not null && request.Contains("First"))
                return "FirstHandler";
            else
                return base.Handle(request + "FirstHandler > ");
        }
    }

    class SecondHandler : AbstractHandler
    {
        public override string Handle(string request)
        {
            if (request is not null && request.Contains("Second"))
                return "SecondHandler";
            else
                return base.Handle(request + "SecondHandler > ");
        }
    }

    class ThirdHandler : AbstractHandler
    {
        public override string Handle(string request)
        {
            if (request is not null && request.Contains("Third"))
                return "ThirdHandler";
            else
                return base.Handle(request + "ThirdHandler");
        }
    }
}

namespace DesignPatterns
{
    partial class Behavioral
    {
        public static void ChainofResponsibility()
        {
            Helper.Run("Behavioral.ChainofResponsibility", () =>
            {
                var first = new FirstHandler();
                var second = new SecondHandler();
                var third = new ThirdHandler();

                first.SetNext(second).SetNext(third);
                Console.WriteLine(first.Handle("Chain: "));
                Console.WriteLine(second.Handle("Subchain: "));
            });
        }
    }
}
