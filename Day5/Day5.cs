using System.Linq;
using System.Threading.Tasks;

namespace adventofcode_2022.Day5
{


	class Day5 : SolverInterface
    {
		
	
        public void solvePart1()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Jalil\Desktop\src\C#\adventofcode-2022\Day5\input.txt");

            Dictionary<int, Stack<string>> crates = new Dictionary<int, Stack<string>>();
            bool reverse = false;
            foreach (string line in lines)
            {

                if (line.Contains("["))
                {
                    string[] row = line.Split(" ");
                    int position = 1;
                    int nbSpace = 1;
                    foreach (string elementRow in row)
                    {
                        if (!string.IsNullOrEmpty(elementRow))
                        {
                            string replacedString = elementRow.Replace("[","");
                            string replacedString2 = replacedString.Replace("]","");
                            if (!crates.ContainsKey(position))
                            {
                                Stack<string> myStack = new Stack<string>();
                                myStack.Push(replacedString2);
                                crates.Add(position, myStack);
                            }
                            else
                            {
                                crates[position].Push(replacedString2);
                            }
                            position++;
                            nbSpace = 0;
                        }

                        //to clear out spaces
                        if (nbSpace == 4)
                        {
                            position++;
                            nbSpace = 0;
                        }
                        nbSpace++;


                    }
                }
                else if (line.Contains("move"))
                {

                    if (!reverse)
                    {
                        crates = this.reverse(crates);
                        reverse = true;
                    }

                    string[] insctructions = line.Split(" ");
                    int nb = Convert.ToInt32(insctructions[1]);
                    int positionStart = Convert.ToInt32(insctructions[3]);
                    int positionEnd = Convert.ToInt32(insctructions[5]);


                    for (int i = 0; i < nb; i++)
                    {
                        crates[positionEnd].Push(crates[positionStart].Pop());
                    }


                }


            }

            int column = 1;
            string solution = "";
            foreach (var crate in crates)
            {
                solution = solution + crates[column].Peek();
                column++;
            }
            Console.WriteLine(solution);

            System.Console.ReadKey();
        }

        public void solvePart2()
        {
        /*    string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Jalil\Desktop\src\C#\adventofcode-2022\Day5\input.txt");


            foreach (string line in lines)
            {

            }
            System.Console.ReadKey();*/
        }

        public Dictionary<int, Stack<string>> reverse(Dictionary<int, Stack<string>> crates)
        {
            int column = 1;
            foreach (var crate2 in crates)
            {

                Stack<string> myStackss = new Stack<string>();

                while (crates[column].Count != 0)
                {
                    myStackss.Push(crates[column].Pop());
                }
                crates[column] = myStackss;
                column++;
            }
            return crates;
        }
    }
}
