using System;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            var structureTheory = new ObjectStructure();
            structureTheory.Add(new ElementA());
            structureTheory.Add(new ElementB());
            structureTheory.Accept(new ConcreteVisitor1());
            structureTheory.Accept(new ConcreteVisitor2());

            var structure = new Bank();
            structure.Add(new Person { Name = "Иван Алексеев", Number = "82184931" });
            structure.Add(new Company { Name = "Microsoft", RegNumber = "ewuir32141324", Number = "3424131445" });
            structure.Accept(new HtmlVisitor());
            structure.Accept(new XmlVisitor());
        }
    }
}
