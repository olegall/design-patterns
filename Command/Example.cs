using System;
using System.Collections.Generic;

namespace Command
{
    interface ICommand
    {
        void Execute();
        void Undo();
    }

    // Receiver - Получатель
    class TV
    {
        public void On()
        {
            Console.WriteLine("Телевизор включен!");
        }

        public void Off()
        {
            Console.WriteLine("Телевизор выключен...");
        }
    }

    class TVOnCommand : ICommand
    {
        TV tv;

        public TVOnCommand(TV tvSet)
        {
            tv = tvSet;
        }

        public void Execute()
        {
            tv.On();
        }

        public void Undo()
        {
            tv.Off();
        }
    }

    // Invoker - инициатор
    class Pult
    {
        ICommand command;

        public Pult() { }

        public void SetCommand(ICommand com)
        {
            command = com;
        }

        public void PressButton()
        {
            command.Execute();
        }

        public void PressUndo()
        {
            command.Undo();
        }
    }

    //class Pult
    //{
    //    ICommand command;

    //    public Pult() { }

    //    public void SetCommand(ICommand com)
    //    {
    //        command = com;
    //    }

    //    public void PressButton()
    //    {
    //        if (command != null)
    //            command.Execute();
    //    }

    //    public void PressUndo()
    //    {
    //        if (command != null)
    //            command.Undo();
    //    }
    //}

    class NoCommand : ICommand
    {
        public void Execute()
        {
        }

        public void Undo()
        {
        }
    }

    class PultNoCommand
    {
        ICommand command;

        public PultNoCommand()
        {
            command = new NoCommand();
        }

        public void SetCommand(ICommand com)
        {
            command = com;
        }

        public void PressButton()
        {
            command.Execute();
        }

        public void PressUndo()
        {
            command.Undo();
        }
    }

    class Volume
    {
        public const int OFF = 0;
        public const int HIGH = 20;
        private int level;

        public Volume()
        {
            level = OFF;
        }

        public void RaiseLevel()
        {
            if (level < HIGH)
                level++;
            Console.WriteLine("Уровень звука {0}", level);
        }

        public void DropLevel()
        {
            if (level > OFF)
                level--;
            Console.WriteLine("Уровень звука {0}", level);
        }
    }

    class VolumeCommand : ICommand
    {
        Volume volume;

        public VolumeCommand(Volume v)
        {
            volume = v;
        }

        public void Execute()
        {
            volume.RaiseLevel();
        }

        public void Undo()
        {
            volume.DropLevel();
        }
    }

    class MultiPult
    {
        ICommand[] buttons;
        Stack<ICommand> commandsHistory;

        public MultiPult()
        {
            buttons = new ICommand[2];
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i] = new NoCommand();
            }
            commandsHistory = new Stack<ICommand>();
        }

        public void SetCommand(int number, ICommand com)
        {
            buttons[number] = com;
        }

        public void PressButton(int number)
        {
            buttons[number].Execute();
            // добавляем выполненную команду в историю команд
            commandsHistory.Push(buttons[number]);
        }

        public void PressUndoButton()
        {
            if (commandsHistory.Count > 0)
            {
                ICommand undoCommand = commandsHistory.Pop();
                undoCommand.Undo();
            }
        }
    }
}