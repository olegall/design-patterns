namespace Interpreter
{
    class ContextTheory
    {
    }

    abstract class AbstractExpression
    {
        public abstract void Interpret(ContextTheory context);
    }

    class TerminalExpression : AbstractExpression
    {
        public override void Interpret(ContextTheory context)
        {
        }
    }

    class NonterminalExpression : AbstractExpression
    {
        AbstractExpression expression1;
        AbstractExpression expression2;

        public override void Interpret(ContextTheory context)
        {

        }
    }
}
