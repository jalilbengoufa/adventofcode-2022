using System.Linq;
using System.Threading.Tasks;

namespace adventofcode_2022.Day3
{


    class Day3 : SolverInterface
    {


        public void solvePart1()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Jalil\Desktop\src\C#\adventofcode-2022\Day3\input.txt");


            var itemsValue = new Dictionary<string, int>();
            char[] alphabetList = Enumerable.Range('a', 'z' - 'a' + 1).Select(i => (Char)i).ToArray();
            int index = 1;
            foreach (var letter in alphabetList)
            {
                itemsValue.Add(letter.ToString(), index);
                index++;
            }

            int sumPriority = 0;
            foreach (string line in lines)
            {
                string firsthalf = line.Substring(0, line.Length / 2);
                string secondhalf = line.Substring((line.Length / 2), line.Length / 2);

                var firsthalfLetters = new HashSet<char>(firsthalf);
                foreach (char secondhalfLetter in secondhalf)
                {
                    if (firsthalfLetters.Contains(secondhalfLetter))
                    {

                        int priority;
                        if (itemsValue.TryGetValue(secondhalfLetter.ToString().ToLower(), out priority))
                        {
                            if (Char.IsUpper(secondhalfLetter))
                            {
                                priority += 26;
                            }
                        }
                        sumPriority += priority;
                        break;
                    }
                }

            }
            Console.WriteLine(sumPriority);
            System.Console.ReadKey();
        }

        public void solvePart2()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Jalil\Desktop\src\C#\adventofcode-2022\Day3\input.txt");

            /*
             * Part 2
             */
            var itemsValue = new Dictionary<string, int>();
            char[] alphabetList = Enumerable.Range('a', 'z' - 'a' + 1).Select(i => (Char)i).ToArray();
            int index = 1;
            foreach (var letter in alphabetList)
            {
                itemsValue.Add(letter.ToString(), index);
                index++;
            }

            int sumPriority = 0;

            string elve1 = "";
            var elve2 = new HashSet<char>();
            int indexElve = 0;
            foreach (string line in lines)
            {


                if (indexElve == 1)
                {
                    var elve1Letters = new HashSet<char>(elve1);

                    foreach (char elve2Ltter in line)
                    {
                        if (elve1Letters.Contains(elve2Ltter))
                        {



                            foreach (char elve3Ltter in line)
                            {
                                if (elve2.Contains(elve3Ltter))
                                {
                                    int priority;
                                    if (itemsValue.TryGetValue(elve3Ltter.ToString().ToLower(), out priority))
                                    {
                                        if (Char.IsUpper(elve3Ltter))
                                        {
                                            priority += 26;
                                        }
                                    }
                                    sumPriority += priority;
                                    indexElve = 0;
                                    elve2 = new HashSet<char>();
                                    break;
                                }
                            }
                        }
                        else if (indexElve == 0)
                        {
                            elve1 = line;
                            indexElve++;
                        }


                    }
                    Console.WriteLine(sumPriority);
                    System.Console.ReadKey();
                }

            }
        }
    }
}
