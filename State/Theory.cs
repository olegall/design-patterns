namespace State
{
    abstract class State
    {
        public abstract void Handle(Context context);
    }

    class StateA : State
    {
        public override void Handle(Context context)
        {
            context.State = new StateB();
        }
    }

    class StateB : State
    {
        public override void Handle(Context context)
        {
            context.State = new StateA();
        }
    }

    class Context
    {
        public State State { get; set; }

        public Context(State state)
        {
            this.State = state;
        }

        public void Request()
        {
            this.State.Handle(this);
        }
    }
}