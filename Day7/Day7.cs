using System.Linq;
using System.Threading.Tasks;

namespace adventofcode_2022.Day7
{


    enum COMMAND
    {
        LS,
        CD,
        BACK,
        ROW,
    }

    class Day7 : SolverInterface
    {
		
	


        public void solvePart1()
        {

            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Jalil\Desktop\src\C#\adventofcode-2022\Day7\input.txt");

            Dictionary<string, List<string>> childrens = new Dictionary<string, List<string>>();
            Dictionary<string, int> childSum = new Dictionary<string, int>();
            Stack<string> path = new Stack<string>();
            foreach (string line in lines)
            {

                switch (command(line))
                {
                    case COMMAND.BACK:


                        path.Pop();

                        break;
                    case COMMAND.LS:


                        break;
                    case COMMAND.CD:

                        string[] splitLine = line.Split(" ");
                        string dir = splitLine[2];
                        path.Push(dir);

                        break;
                    case COMMAND.ROW:
                        if (line.Contains("dir"))
                        {
                            string[] dirLine = line.Split(" ");
                            string dirRow = dirLine[1];
                            //add parent to node
                            //parent is current head in path

                        
                                if (!childrens.ContainsKey(path.Peek()))
                                {
                                    List<string> myStack = new List<string>();
                                    myStack.Add(dirRow);
                                    childrens.Add(path.Peek(), myStack);
                                }
                                else
                                {
                                    childrens[path.Peek()].Add(dirRow);
                                }

                          
                        }
                        else
                        {
                            string[] splitLineSize = line.Split(" ");
                            int size = Int32.Parse(splitLineSize[0]);
                            //sum size to current head in path
                         
                                if (!childSum.ContainsKey(path.Peek()))
                                {

                                    childSum.Add(path.Peek(), size);
                                }
                                else
                                {
                                    childSum[path.Peek()] += size;
                                }
                        }
                        break;
                    default:
                        break;
                }

             /*   string joinedString = String.Join(",", path);

                Console.WriteLine(joinedString);

                Console.WriteLine("==============");*/
            }

           



            foreach (KeyValuePair<string, List<string>> entry in childrens)
            {
                string joinedString = String.Join(",", entry.Value);

                int totlaChildren = 0;
                foreach (string value in entry.Value)
                {

                    if (!childSum.ContainsKey(value))
                    {
                        totlaChildren += childSum[value];

                    }

                }

                if (!childSum.ContainsKey(entry.Key))
                {

                    childSum.Add(entry.Key, totlaChildren);
                }
                else
                {
                    childSum[entry.Key] += totlaChildren;
                }

                Console.WriteLine("entry: " + entry.Key + " = " + joinedString+ " = " + totlaChildren + " = " + childSum[entry.Key]);
            }
            Console.WriteLine("==============");
            int total = 0;
            foreach (KeyValuePair<string, int> dirSum in childSum)
            {
                Console.WriteLine("dirRow: "+ dirSum.Key+ " = "+ dirSum.Value);

                if (dirSum.Value <= 100000)
                {
                    total += dirSum.Value;
                }

            }
            Console.WriteLine(total);

            System.Console.ReadKey();
        }

        public void solvePart2()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Jalil\Desktop\src\C#\adventofcode-2022\Day7\input.txt");


            foreach (string line in lines)
            {

            }


            System.Console.ReadKey();
        }


        public COMMAND command(string line)
        {
            if (line.Contains("..")){
                return COMMAND.BACK;
            }
            else if (line.Contains("ls"))
            {
                return COMMAND.LS;
            }
            else if (line.Contains("cd"))
            {
                return COMMAND.CD;
            }

            return COMMAND.ROW;
        }

        public int sumChildren(string key, Dictionary<string, int> childSum, Dictionary<string, List<string>> childrens)
        {



            int total = 0;
            foreach (var item in childrens[key])
            {
                total += sumChildren(item, childSum, childrens);

            }

            return total;

        }




    }
}
