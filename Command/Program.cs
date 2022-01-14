using System;
using System.Collections.Generic;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            Pult pult = new Pult();
            TV tv = new TV();
            pult.SetCommand(new TVOnCommand(tv));
            pult.PressButton();
            pult.PressUndo();

            TV tv2 = new TV();
            Volume volume = new Volume();
            MultiPult mPult = new MultiPult();
            mPult.SetCommand(0, new TVOnCommand(tv2));
            mPult.SetCommand(1, new VolumeCommand(volume));
            // включаем телевизор
            mPult.PressButton(0);
            // увеличиваем громкость
            mPult.PressButton(1);
            mPult.PressButton(1);
            mPult.PressButton(1);
            // действия отмены
            mPult.PressUndoButton();
            mPult.PressUndoButton();
            mPult.PressUndoButton();
            mPult.PressUndoButton();

            Programmer programmer = new Programmer();
            Tester tester = new Tester();
            Marketolog marketolog = new Marketolog();

            List<ICommand> commands = new List<ICommand>
            {
                new CodeCommand(programmer),
                new TestCommand(tester),
                new AdvertizeCommand(marketolog)
            };
            Manager manager = new Manager();
            manager.SetCommand(new MacroCommand(commands));
            manager.StartProject();
            manager.StopProject();
        }
    }
}
