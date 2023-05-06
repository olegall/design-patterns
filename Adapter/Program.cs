namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            // путешественник
            Driver driver = new Driver();

            // машина
            Auto auto = new Auto();
            //ITransport auto = new Auto(); // я

            // отправляемся в путешествие
            driver.Travel(auto);

            // встретились пески, надо использовать верблюда
            Camel camel = new Camel();

            // используем адаптер
            ITransport camelTransport = new CamelToTransportAdapter(camel);

            // продолжаем путь по пескам пустыни
            driver.Travel(camelTransport);
        }
    }
}
