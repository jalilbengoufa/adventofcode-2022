using System.Linq;
using System.Threading.Tasks;

namespace adventofcode_2022.Day4
{


	class Day4 : SolverInterface
    {
		
	
        public void solvePart1()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Jalil\Desktop\src\C#\adventofcode-2022\Day4\input.txt");


            int totalOverlap = 0;
            foreach (string line in lines)
            {

                string[] pairs = line.Split(",");

                string[] pairsOfNumbers1 = pairs[0].Split("-");
                int startNb = Int32.Parse(pairsOfNumbers1[0]);
                int endNb = Int32.Parse(pairsOfNumbers1[1]);

                string[] pairsOfNumbers2 = pairs[1].Split("-");
                int startNb2 = Int32.Parse(pairsOfNumbers2[0]);
                int endNb2 = Int32.Parse(pairsOfNumbers2[1]);

                if(startNb - startNb2 <= 0 && endNb - endNb2 >= 0)
                {
                    totalOverlap++;
                }
                else if (startNb2 - startNb <= 0 && endNb2 - endNb >= 0)
                {
                    totalOverlap++;
                }



            }
            Console.WriteLine(totalOverlap);
            System.Console.ReadKey();
        }

        public void solvePart2()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Jalil\Desktop\src\C#\adventofcode-2022\Day4\input.txt");


            int totalOverlap = 0;
            foreach (string line in lines)
            {

                string[] pairs = line.Split(",");

                string[] pairsOfNumbers1 = pairs[0].Split("-");
                int startNb = Int32.Parse(pairsOfNumbers1[0]);
                int endNb = Int32.Parse(pairsOfNumbers1[1]);

                string[] pairsOfNumbers2 = pairs[1].Split("-");
                int startNb2 = Int32.Parse(pairsOfNumbers2[0]);
                int endNb2 = Int32.Parse(pairsOfNumbers2[1]);

                /*
                 * 
                 * solution1
                 */

                /*   IEnumerable<int> range = Enumerable.Range(startNb, endNb - startNb + 1);
                   IEnumerable<int> range2 = Enumerable.Range(startNb2, endNb2 - startNb2 + 1);


                   var range2Set = new HashSet<int>(range2);

                   foreach (int i in range)
                   {
                       if (range2Set.Contains(i))
                       {
                           totalOverlap++;
                           break;
                       }

                   }*/


                /*
                * 
                * solution 2
                */

                if ((startNb - startNb2 <= 0 && startNb - endNb2 >= 0)
                    || (endNb - startNb2 >= 0 && endNb - endNb2 <= 0))
                {
                    totalOverlap++;
                }
                else if ((startNb2 - startNb <= 0 && startNb2 - endNb >= 0)
                || (endNb2 - startNb >= 0 && endNb2 - endNb <= 0))
                {
                    totalOverlap++;
                }

            }
            Console.WriteLine(totalOverlap);
            System.Console.ReadKey();
        }
    }
}
