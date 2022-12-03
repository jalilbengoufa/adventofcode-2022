using System.Linq;
using System.Threading.Tasks;

namespace adventofcode_2022.Day1
{
	class Day1 : SolverInterface
    {
		

        public void solvePart1()
        {

            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Jalil\Desktop\src\C#\adventofcode-2022\Day1\input.txt");


            try
            {
                int maxCaloeries = 0;
            int currentCaloeries = 0;
            foreach (string line in lines)
            {


                if (!String.IsNullOrEmpty(line))
                {
                    int calerie = Int32.Parse(line);
                    currentCaloeries += calerie;

                }
                else
                {
                    if (currentCaloeries > maxCaloeries)
                    {
                        maxCaloeries = currentCaloeries;
                    }

                    currentCaloeries = 0;

                }
            }
                Console.WriteLine("maxCaloeries:  " + maxCaloeries);

            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse");
            }
            System.Console.ReadKey();
        }

        public void solvePart2()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Jalil\Desktop\src\C#\adventofcode-2022\Day1\input.txt");

            try{ 
                int currentCaloeries = 0;
                var caloriesByElf = new List<int> { };
                foreach (string line in lines)
                {


                    if (!String.IsNullOrEmpty(line))
                    {
                        int calerie = Int32.Parse(line);
                        currentCaloeries += calerie;

                    }
                    else
                    {
                        caloriesByElf.Add(currentCaloeries);

                        currentCaloeries = 0;

                    }
                }
                IEnumerable<int> sortedCalories = caloriesByElf.OrderByDescending(c => c);

                var sum = sortedCalories.ElementAt(0) + sortedCalories.ElementAt(1) + sortedCalories.ElementAt(2);
                Console.WriteLine("maxCaloeries 1:  " + sum);
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse");
            }
            System.Console.ReadKey();
        }
    }
}