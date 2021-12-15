namespace PeopleManager.ConsoleApp.ConsoleBuilders
{
    public abstract class ConsoleModelBuilder<T>
    {
        public abstract T Build();

        protected string ReadString(string title)
        {
            Console.WriteLine(title);
            var value = string.Empty;

            while (value == null || value == string.Empty)
                value = Console.ReadLine();

            return value;
        }

        protected bool ReadBoolean(string title)
        {
            Console.WriteLine(title);
            var value = string.Empty;

            while (!(value == "yes" || value == "no"))
                value = Console.ReadLine();

            return value == "yes";
        }

        protected DateTime ReadDate(string title)
        {
            Console.WriteLine(title);
            var value = string.Empty;
            DateTime date;

            while (value == null || value == string.Empty || !DateTime.TryParse(value, out date))
                value = Console.ReadLine();

            return date;
        }
    }
}
