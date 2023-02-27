using System.Collections;
using Behavioral.Iterator;

namespace Behavioral.Iterator
{
    abstract class Iterator : IEnumerator
    {
        object IEnumerator.Current => Current();

        public abstract object Current();

        public abstract bool MoveNext();

        public abstract void Reset();
    }

    class CollectionIterator : Iterator
    {
        private Collection collection;
        private int position = -1;

        public CollectionIterator(Collection collection)
        {
            this.collection = collection;
        }

        public override object Current()
        {
            return this.collection.users[position];
        }

        public override bool MoveNext()
        {
            if (position + 1 < this.collection.users.Count)
            {
                this.position += 1;
                return true;
            }
            else
                return false;
        }

        public override void Reset()
        {
            this.position = -1;
        }
    }

    abstract class IteratorAggregate : IEnumerable
    {
        public abstract IEnumerator GetEnumerator();
    }

    class Collection : IteratorAggregate
    {
        public List<string> users;

        public Collection(List<string> users)
        {
            this.users = users;
        }

        public override IEnumerator GetEnumerator()
        {
            return new CollectionIterator(this);
        }
    }
}

namespace DesignPatterns
{
    partial class Behavioral
    {
        public static void Iterator()
        {
            Helper.Run("Behavioral.Iterator", () =>
            {
                var users = new List<string>() { "Alice", "Bob", "Carl" };
                var collection = new Collection(users);

                Console.Write("All elements in collection: ");
                foreach (var item in collection)
                    Console.Write(item + " ");
                Console.WriteLine("");
            });
        }
    }
}

