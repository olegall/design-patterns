using System;
using System.Threading;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Computer comp = new Computer();
            comp.Launch("Windows 8.1");
            Console.WriteLine(comp.OS.Name);

            // у нас не получится изменить ОС, так как объект уже создан    
            comp.OS = OS.getInstance("Windows 10");
            Console.WriteLine(comp.OS.Name);



            /* Синглтон и многопоточность */
            (new Thread(() =>
            {
                Computer comp2 = new Computer();
                comp2.OS = OS.getInstance("Windows 10");
                Console.WriteLine(comp2.OS.Name);

            })).Start();

            (new Thread(() =>
            {
                SingletonNoLock singleton1 = SingletonNoLock.GetInstance();
                Console.WriteLine(singleton1.Date);
            })).Start();



            SingletonNoLock singleton2 = SingletonNoLock.GetInstance();
            Console.WriteLine(singleton2.Date);



            Console.WriteLine($"Main {DateTime.Now.TimeOfDay}");
            Console.WriteLine(SingletonNested.text);

            SingletonNested singleton1 = SingletonNested.GetInstance();
            Console.WriteLine(singleton1.Date);
        }
    }
}
