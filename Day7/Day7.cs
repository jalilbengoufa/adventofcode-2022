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

                string joinedString = String.Join("", path);

                switch (command(line))
                {
                    case COMMAND.BACK:

                     
                        if (path.Count >0)
                        {
                            path.Pop();

                        }

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


                            if (!childrens.ContainsKey(joinedString))
                                {
                                    List<string> myStack = new List<string>();
                                    myStack.Add(dirRow + joinedString);
                                    childrens.Add(joinedString, myStack);
                                }
                                else
                                {
                                    childrens[joinedString].Add(dirRow + joinedString);
                                }

                          
                        }
                        else
                        {

                            string[] splitLineSize = line.Split(" ");
                            int size = Int32.Parse(splitLineSize[0]);
                            //sum size to current head in path

                            if (!childSum.ContainsKey(joinedString))
                                {

                                    childSum.Add(joinedString, size);
                                }
                                else
                                {
                                    childSum[joinedString] += size;
                                }

                        }
                        break;
                    default:
                        break;
                }

            
            }

            sumAllAscendantsInOrder("/", childSum, childrens);

            int total = 0;
            foreach (KeyValuePair<string, int> dirSum in childSum)
            {
               // Console.WriteLine("dirRow: "+ dirSum.Key+ " = "+ dirSum.Value);

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

            Dictionary<string, List<string>> childrens = new Dictionary<string, List<string>>();
            Dictionary<string, int> childSum = new Dictionary<string, int>();
            Stack<string> path = new Stack<string>();
            foreach (string line in lines)
            {

                string joinedString = String.Join("", path);

                switch (command(line))
                {
                    case COMMAND.BACK:


                        if (path.Count > 0)
                        {
                            path.Pop();

                        }

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


                            if (!childrens.ContainsKey(joinedString))
                            {
                                List<string> myStack = new List<string>();
                                myStack.Add(dirRow + joinedString);
                                childrens.Add(joinedString, myStack);
                            }
                            else
                            {
                                childrens[joinedString].Add(dirRow + joinedString);
                            }


                        }
                        else
                        {

                            string[] splitLineSize = line.Split(" ");
                            int size = Int32.Parse(splitLineSize[0]);
                            //sum size to current head in path

                            if (!childSum.ContainsKey(joinedString))
                            {

                                childSum.Add(joinedString, size);
                            }
                            else
                            {
                                childSum[joinedString] += size;
                            }

                        }
                        break;
                    default:
                        break;
                }


            }

            sumAllAscendantsInOrder("/", childSum, childrens);

            int smallestDirTodeleteSize = 0;
            int dirSize = 0;
            int unsedSpace = 70000000 - childSum["/"];
            int neededSpace = 30000000 - unsedSpace;
            Console.WriteLine(neededSpace);
            foreach (KeyValuePair<string, int> dirSum in childSum)
            {

                if(dirSum.Value>= neededSpace)
                {
                    int currentRemaingSpace = 30000000 - dirSum.Value;
                    if (currentRemaingSpace > smallestDirTodeleteSize)
                    {
                        smallestDirTodeleteSize = currentRemaingSpace;
                        dirSize = dirSum.Value;
                    }
                }
               

            }
            Console.WriteLine(dirSize);

            System.Console.ReadKey();
        }


        public COMMAND command(string line)
        {
            if (line.Contains("$"))
            {
                string[] dirLine = line.Split(" ");
                string commandString = dirLine[1];
                if (commandString == "ls")
                {
                    return COMMAND.LS;
                }
                else if (commandString == "cd")
                {
                    if (dirLine[2] == "..")
                    {
                        return COMMAND.BACK;
                    }
                    return COMMAND.CD;
                }

            }
         

            return COMMAND.ROW;
        }

        public int sumAllAscendantsInOrder(string key, Dictionary<string, int> childSum, Dictionary<string, List<string>> childrens)
        {


         
            int total = 0;
            if(childrens.ContainsKey(key))
            {

                foreach (var item in childrens[key])
                {

                    total += sumAllAscendantsInOrder(item, childSum, childrens);

                }

                if (!childSum.ContainsKey(key))
                {

                    childSum.Add(key, total);
                }
                else
                {
                    childSum[key] += total;
                }
              

            }


            return childSum[key];

        }




    }
}
