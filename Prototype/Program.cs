using System;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            IFigure figure = new Rectangle(30, 40);
            IFigure clonedFigure = figure.Clone();
            figure.GetInfo();
            clonedFigure.GetInfo();

            figure = new Circle(30);
            clonedFigure = figure.Clone();
            figure.GetInfo();
            clonedFigure.GetInfo();

            Console.Read();

            CirclePoint figure1 = new CirclePoint(30, 50, 60);
            CirclePoint clonedFigure2 = figure.Clone() as CirclePoint;
            figure1.Point.X = 100; // изменяем координаты начальной фигуры
            figure1.GetInfo(); // figure.Point.X = 100
            clonedFigure2.GetInfo(); // clonedFigure.Point.X = 100

            CirclePoint figure2 = new CirclePoint(30, 50, 60);
            // применяем глубокое копирование
            CirclePoint clonedFigure3 = figure2.DeepCopy() as CirclePoint;
            figure2.Point.X = 100;
            figure2.GetInfo();
            clonedFigure3.GetInfo();


            Console.WriteLine("Hello World!");
        }
    }
}
