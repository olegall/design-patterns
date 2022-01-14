﻿using System;

namespace Mediator
{
    abstract class Mediator
    {
        public abstract void Send(string msg, Colleague colleague);
    }

    abstract class Colleague
    {
        protected Mediator mediator;

        public Colleague(Mediator mediator)
        {
            this.mediator = mediator;
        }

        public virtual void Send(string message)
        {
            mediator.Send(message, this);
        }

        public abstract void Notify(string message);
    }

    // класс заказчика
    class CustomerColleague : Colleague
    {
        public CustomerColleague(Mediator mediator) : base(mediator) { }

        public override void Notify(string message)
        {
            Console.WriteLine("Сообщение заказчику: " + message);
        }
    }

    // класс программиста
    class ProgrammerColleague : Colleague
    {
        public ProgrammerColleague(Mediator mediator) : base(mediator) { }

        public override void Notify(string message)
        {
            Console.WriteLine("Сообщение программисту: " + message);
        }
    }

    // класс тестера
    class TesterColleague : Colleague
    {
        public TesterColleague(Mediator mediator) : base(mediator) { }

        public override void Notify(string message)
        {
            Console.WriteLine("Сообщение тестеру: " + message);
        }
    }

    class ManagerMediator : Mediator
    {
        public Colleague Customer { get; set; }
        public Colleague Programmer { get; set; }
        public Colleague Tester { get; set; }

        public override void Send(string msg, Colleague colleague)
        {
            if (Customer == colleague) // если отправитель - заказчик, значит есть новый заказ. отправляем сообщение программисту - выполнить заказ
            {
                Programmer.Notify(msg);
            }
            else if (Programmer == colleague) // если отправитель - программист, то можно приступать к тестированию. отправляем сообщение тестеру
            {
                Tester.Notify(msg);
            }
            else if (Tester == colleague) // если отправитель - тест, значит продукт готов. отправляем сообщение заказчику
            { 
                Customer.Notify(msg); 
            }
        }
    }
}
