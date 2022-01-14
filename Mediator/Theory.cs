using System;
using System.Collections.Generic;
using System.Text;

namespace Mediator
{
    abstract class MediatorTheory
    {
        public abstract void Send(string msg, ColleagueTheory colleague);
    }

    abstract class ColleagueTheory
    {
        protected MediatorTheory mediator;

        public ColleagueTheory(MediatorTheory mediator)
        {
            this.mediator = mediator;
        }
    }

    class ConcreteColleague1 : ColleagueTheory
    {
        public ConcreteColleague1(MediatorTheory mediator)
            : base(mediator)
        { }

        public void Send(string message)
        {
            mediator.Send(message, this);
        }

        public void Notify(string message)
        { }
    }

    class ConcreteColleague2 : ColleagueTheory
    {
        public ConcreteColleague2(MediatorTheory mediator)
            : base(mediator)
        { }

        public void Send(string message)
        {
            mediator.Send(message, this);
        }

        public void Notify(string message)
        { }
    }

    class ConcreteMediator : MediatorTheory
    {
        public ConcreteColleague1 Colleague1 { get; set; }
        public ConcreteColleague2 Colleague2 { get; set; }
        public override void Send(string msg, ColleagueTheory colleague)
        {
            if (Colleague1 == colleague)
                Colleague2.Notify(msg);
            else
                Colleague1.Notify(msg);
        }
    }
}
