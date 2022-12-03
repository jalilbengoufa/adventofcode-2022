using System.Linq;
using System.Threading.Tasks;

namespace adventofcode_2022.Day1
{
	class Day1
	{
		
		public void solve()
		{
   

            // Example #2
            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Jalil\Desktop\src\C#\adventofcode-2022\Day1\input.txt");



            try
            {
                /*
                 * 1
                 */
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
                        if(currentCaloeries> maxCaloeries)
                        {
                            maxCaloeries = currentCaloeries;
                        }
                        
                        currentCaloeries = 0;

                    }
                }
                Console.WriteLine("maxCaloeries:  " + maxCaloeries);

                /*
                 * 2
                 */
                currentCaloeries = 0;
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
     

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }

	}
}