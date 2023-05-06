using System;

namespace Adapter
{
    interface ITransport
    {
        void Drive();
    }

    // интерфейс животного
    interface IAnimal
    {
        void Move();
    }

    class Driver
    {
        public void Travel(ITransport transport)
        {
            transport.Drive();
        }
    }

    // класс верблюда
    class Camel : IAnimal
    {
        public void Move()
        {
            Console.WriteLine("Верблюд идет по пескам пустыни");
        }
    }

    // класс машины
    class Auto : ITransport
    {
        public void Drive()
        {
            Console.WriteLine("Машина едет по дороге");
        }
    }

    // Адаптер от Camel к ITransport
    class CamelToTransportAdapter : ITransport
    {
        Camel camel;

        public CamelToTransportAdapter(Camel c)
        {
            camel = c;
        }

        public void Drive()
        {
            camel.Move();
        }
    }
}