using System;
using System.Threading;

namespace Singleton
{
    class Singleton
    {
        private static Singleton instance;

        private Singleton() { }

        public static Singleton getInstance()
        {
            if (instance == null)
                instance = new Singleton();

            return instance;
        }
    }

    public class SingletonNoLock
    {
        private static readonly SingletonNoLock instance = new SingletonNoLock();

        public string Date { get; private set; }

        private SingletonNoLock()
        {
            Date = System.DateTime.Now.TimeOfDay.ToString();
        }

        public static SingletonNoLock GetInstance()
        {
            return instance;
        }
    }

    public class SingletonNested
    {
        public string Date { get; private set; }
        public static string text = "hello";

        private SingletonNested()
        {
            Console.WriteLine($"Singleton ctor {DateTime.Now.TimeOfDay}");
            Date = DateTime.Now.TimeOfDay.ToString();
        }

        public static SingletonNested GetInstance()
        {
            Console.WriteLine($"GetInstance {DateTime.Now.TimeOfDay}");
            Thread.Sleep(500);
            return Nested.instance;
        }

        private class Nested
        {
            static Nested() { }
            internal static readonly SingletonNested instance = new SingletonNested();
        }
    }


    public class SingletonLazy
    {
        private static readonly Lazy<SingletonLazy> lazy = new Lazy<SingletonLazy>(() => new SingletonLazy());

        public string Name { get; private set; }

        private SingletonLazy()
        {
            Name = System.Guid.NewGuid().ToString();
        }

        public static SingletonLazy GetInstance()
        {
            return lazy.Value;
        }
    }
}