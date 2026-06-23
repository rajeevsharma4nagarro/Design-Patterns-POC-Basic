namespace E_Library.Utilities
{
    // We can configure any logger such as splunk, log4net, serilog etc. Here we are using console logger for simplicity.
    public class GlobalConsoleLogger
    {
        public static char LogMessage()
        {
            Console.Clear();
            Console.WriteLine("******* Library Management System *******");
            Console.WriteLine("User Management  : [S] SignUp, [E] Edit, [P] Purge, [L] List user profiles");
            Console.WriteLine("Book Management  : [A] Add, [U] Update, [D] Delete, [V] View books");
            Console.WriteLine("Loan Processing  : [B] Borrow books, [R] Return books, [T] Track loan status and due dates");
            Console.WriteLine("Notifications    : [N] Notify users about due dates and overdue books");
            Console.WriteLine("Exit             : [X]");
            Console.Write("Enter your choice: ");
            var choice = Char.ToUpper(Console.ReadKey().KeyChar);
            Console.Clear();
            return choice;
        }

        public static void LogMessage(string msg)
        {
            Console.WriteLine(msg);
        }

        public static void PromptMessage(string msg)
        {
            Console.Write(msg);
        }
    }
}
