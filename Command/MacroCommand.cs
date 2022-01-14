using System;
using System.Collections.Generic;

namespace Command
{
    // Класс макрокоманды
    class MacroCommand : ICommand
    {
        List<ICommand> commands;

        public MacroCommand(List<ICommand> coms)
        {
            commands = coms;
        }

        public void Execute()
        {
            foreach (ICommand c in commands)
                c.Execute();
        }

        public void Undo()
        {
            foreach (ICommand c in commands)
                c.Undo();
        }
    }

    class Programmer
    {
        public void StartCoding()
        {
            Console.WriteLine("Программист начинает писать код");
        }

        public void StopCoding()
        {
            Console.WriteLine("Программист завершает писать код");
        }
    }

    class Tester
    {
        public void StartTest()
        {
            Console.WriteLine("Тестировщик начинает тестирование");
        }

        public void StopTest()
        {
            Console.WriteLine("Тестировщик завершает тестирование");
        }
    }

    class Marketolog
    {
        public void StartAdvertize()
        {
            Console.WriteLine("Маркетолог начинает рекламировать продукт");
        }

        public void StopAdvertize()
        {
            Console.WriteLine("Маркетолог прекращает рекламную кампанию");
        }
    }

    class CodeCommand : ICommand
    {
        Programmer programmer;

        public CodeCommand(Programmer p)
        {
            programmer = p;
        }

        public void Execute()
        {
            programmer.StartCoding();
        }

        public void Undo()
        {
            programmer.StopCoding();
        }
    }

    class TestCommand : ICommand
    {
        Tester tester;

        public TestCommand(Tester t)
        {
            tester = t;
        }

        public void Execute()
        {
            tester.StartTest();
        }

        public void Undo()
        {
            tester.StopTest();
        }
    }

    class AdvertizeCommand : ICommand
    {
        Marketolog marketolog;

        public AdvertizeCommand(Marketolog m)
        {
            marketolog = m;
        }

        public void Execute()
        {
            marketolog.StartAdvertize();
        }

        public void Undo()
        {
            marketolog.StopAdvertize();
        }
    }

    class Manager
    {
        ICommand command;

        public void SetCommand(ICommand com)
        {
            command = com;
        }

        public void StartProject()
        {
            if (command != null)
                command.Execute();
        }

        public void StopProject()
        {
            if (command != null)
                command.Undo();
        }
    }
}