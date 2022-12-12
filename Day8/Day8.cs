using System.Linq;
using System.Threading.Tasks;

namespace adventofcode_2022.Day8
{


	class Day8 : SolverInterface
    {
		
	
        public void solvePart1()
        {

            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Jalil\Desktop\src\C#\adventofcode-2022\Day8\input.txt");


            int[][] jaggedArray = new int[lines.Length][];
            int index=0;
            int nbCol = lines[0].Length;
            int nbRows = lines.Length;
            foreach (string line in lines)
            {
                jaggedArray[index] = Array.ConvertAll(line.ToArray(), c => (int)Char.GetNumericValue(c)); 
                index++;
            }
           
            int edgeSum = (nbRows * 2) + ((nbCol-2) * 2) ;
            Console.WriteLine("solveReal:" + (solveHelper(jaggedArray) + edgeSum));


            System.Console.ReadKey();
        }

        public void solvePart2()
        {
            string text = System.IO.File.ReadAllText(@"C:\Users\Jalil\Desktop\src\C#\adventofcode-2022\Day8\input.txt");

            for (int i = 0; i < text.Length - 13; i++)
            {

        
            }
            System.Console.ReadKey();
        }




        public int solveHelper(int[][] jaggedArray)
        {

            int count = 0;
            for (int row = 1; row < jaggedArray.Length - 1; row++)
            {

                for (int col = 1; col < jaggedArray[row].Length-1; col++)
                {

                    bool visible = false;
                    bool visible2 = false;
                    bool visible3 = false;
                    bool visible4 = false;


                    for (int k = row-1; k >= 0; k--)
                    {
                        int up = jaggedArray[row][col] - jaggedArray[k][col];

                        if (up > 0)
                        {
                            visible = true;
                        }
                           else
                        {
                            visible = false;
                            break;
                        }

                    }
                    for (int k2 = row+1; k2 <= jaggedArray.Length - 1; k2++)
                    {
                        int down = jaggedArray[row][col] - jaggedArray[k2][col];

                        if (down > 0)
                        {
                            visible2 = true;
                        }
                        else
                        {
                            visible2 = false;
                            break;
                        }
                    }
                    for (int k3 = 0; k3 < col; k3++)
                    {
                        int left = jaggedArray[row][col] - jaggedArray[row][k3];

                        if (left > 0)
                        {
                            visible3 = true;
                        }
                        else
                        {
                            visible3 = false;
                            break;
                        }

                    }
                    for (int k4 = col+1; k4 <= jaggedArray[row].Length - 1; k4++)
                    {
                        int right = jaggedArray[row][col] - jaggedArray[row][k4];


                        if (right > 0)
                        {
                            visible4 = true;
                        }
                        else
                        {
                            visible4 = false;
                            break;
                        }
                    }

                    if (visible4 || visible || visible2 || visible3)
                    {
                        count++;
                    }
                }

            }
            return count;
        }




    }
}
