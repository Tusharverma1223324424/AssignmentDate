namespace Dates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<DateTime> all13th = GetAll13thDates(5);

            while (true)
            {
                Console.WriteLine("Press 1 to show all 13th of every months ( for next 5 years)");
                Console.WriteLine("Press 2 to show only Friday && 13th as a date");
                Console.WriteLine("Press 3 to Exit");
                Console.Write("Choose an option (1-3): ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.WriteLine("All 13th dates for the next 5 years: \n");
                    ShowDates(all13th);
                }
                else if (choice == "2")
                {
                    var friday13th = all13th.FindAll(d => d.DayOfWeek == DayOfWeek.Friday);
                    Console.WriteLine("Friday the 13th dates for the next 5 years:\n");
                    ShowDates(friday13th);
                }
                else if (choice == "3")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
                }

                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        
        static List<DateTime> GetAll13thDates(int numberOfYears)
        {
            List<DateTime> dates = new List<DateTime>();

            DateTime today = DateTime.Today;
            int totalMonths = numberOfYears * 12;

            // If the 13th of this month has passed, start from next month
            DateTime first13th = new DateTime(today.Year, today.Month, 13);
            if (first13th < today)
                first13th = first13th.AddMonths(1);

            for (int i = 0; i < totalMonths; i++)
            {
                dates.Add(first13th.AddMonths(i));
            }

            return dates;
        }

        
        static void ShowDates(IEnumerable<DateTime> dates)
        {
            foreach (var d in dates)
            {
                Console.WriteLine($"{d:dd MMMM yyyy (dddd)}");
            }
        }
    }
}
