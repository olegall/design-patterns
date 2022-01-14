using System;
using System.Collections.Generic;

namespace Composite
{
    class Client
    {
        public void Main()
        {
            ComponentTheory root = new Composite("Root");
            ComponentTheory leaf = new Leaf("Leaf");
            ComponentTheory subtree = new Composite("Subtree");

            root.Add(leaf);
            root.Add(subtree);
            root.Display();
        }
    }

    abstract class ComponentTheory
    {
        protected string name;

        public ComponentTheory(string name)
        {
            this.name = name;
        }

        public abstract void Display();
        public abstract void Add(ComponentTheory c);
        public abstract void Remove(ComponentTheory c);
    }

    class Composite : ComponentTheory
    {
        List<ComponentTheory> children = new List<ComponentTheory>();

        public Composite(string name) : base(name) { }

        public override void Add(ComponentTheory component)
        {
            children.Add(component);
        }

        public override void Remove(ComponentTheory component)
        {
            children.Remove(component);
        }

        public override void Display()
        {
            Console.WriteLine(name);

            foreach (ComponentTheory component in children)
            {
                component.Display();
            }
        }
    }

    class Leaf : ComponentTheory
    {
        public Leaf(string name) : base(name) { }

        public override void Display()
        {
            Console.WriteLine(name);
        }

        public override void Add(ComponentTheory component)
        {
            throw new NotImplementedException();
        }

        public override void Remove(ComponentTheory component)
        {
            throw new NotImplementedException();
        }
    }
}