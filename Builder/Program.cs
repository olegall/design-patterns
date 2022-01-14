using System;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            // содаем объект пекаря
            Baker baker = new Baker();
            // создаем билдер для ржаного хлеба
            BreadBuilder builder = new RyeBreadBuilder();
            // выпекаем
            Bread ryeBread = baker.Bake(builder);
            Console.WriteLine(ryeBread.ToString());
            // оздаем билдер для пшеничного хлеба
            builder = new WheatBreadBuilder();
            Bread wheatBread = baker.Bake(builder);
            Console.WriteLine(wheatBread.ToString());

            Console.WriteLine("Hello World!");
        }
    }
}
