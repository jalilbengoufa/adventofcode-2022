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

            int operation = 0;
            for (int row = 1; row < jaggedArray.Length-1; row++)
            {

                for (int col = 1; col < jaggedArray[row].Length ; col++)
                {
                    if (jaggedArray[row][col - 1] - jaggedArray[row][col] < 0)
                    {
                        operation++;

                    }

                }

                for (int col2 = jaggedArray[row].Length - 1; col2 > 0; col2--)
                {
                  
                    if (jaggedArray[row][col2] - jaggedArray[row][col2 - 1] < 0)
                    {
                        operation++;
                    }

                }
            }


           
            int edgeSum = (nbRows * 2) + ((nbCol-2) * 2) ;
        /*    int vraiOperation = operation - ((nbRows - 2)*2);
            int vraiOperation2 = solve(jaggedArray) - ((nbCol - 2)*2);
            Console.WriteLine("vraiOperation:" + (vraiOperation));
            Console.WriteLine("vraiOperation:" + (vraiOperation2));
            Console.WriteLine("vraiOperation:" + (vraiOperation+vraiOperation2+ edgeSum- (nbRows-1)));*/
            Console.WriteLine("solveReal:" + (solveReal (jaggedArray) + edgeSum));
            Console.WriteLine("=========================");
            Console.WriteLine("nb rows: " + nbRows);
            Console.WriteLine("nb col: " + nbCol);
            Console.WriteLine("edgeSum: " + edgeSum);



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



        public int solve( int[][] jaggedArray)
        {

            int operation = 0;
            for (int col = 1; col < jaggedArray.Length ; col++)
            {

                for (int row = 1; row < jaggedArray[col].Length - 1; row++)
                {

                    if (jaggedArray[row-1][col] - jaggedArray[row][col] < 0)
                    {
                        operation++;

                    }

                }

                for (int row2 = jaggedArray[col].Length - 1; row2 >0 ; row2--)
                {

                    if (jaggedArray[row2][col] - jaggedArray[row2-1][col] < 0)
                    {
                        operation++;

                    }

                }

            }
            return operation;
        }

        public int solveReal(int[][] jaggedArray)
        {

            int count = 0;
            for (int row = 1; row < jaggedArray.Length - 1; row++)
            {

                for (int col = 1; col < jaggedArray[row].Length-1; col++)
                {
                  /*  Console.WriteLine("current: " + jaggedArray[row][col]);
                    Console.WriteLine("up: " + jaggedArray[row - 1][col]);
                    Console.WriteLine("down: " + jaggedArray[row + 1][col]);
                    Console.WriteLine("left: " + jaggedArray[row][col - 1]);
                    Console.WriteLine("right: " + jaggedArray[row][col + 1]);*/
                    bool visible = false;
                    bool visible2 = false;
                    bool visible3 = false;
                    bool visible4 = false;
                    Console.WriteLine("current: " + jaggedArray[row][col]);
                    Console.WriteLine("row: " + row);
                    Console.WriteLine( jaggedArray.Length - 1);
                    Console.WriteLine( jaggedArray[row].Length - 1);

                    for (int k = row-1; k >= 0; k--)
                    {
                        Console.WriteLine("up: " + jaggedArray[k][col]);
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
                    Console.WriteLine(visible);
                    for (int k2 = row+1; k2 <= jaggedArray.Length - 1; k2++)
                    {
                        Console.WriteLine("down: " + jaggedArray[k2][col]);
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
                    Console.WriteLine(visible2);
                    for (int k3 = 0; k3 < col; k3++)
                    {
                        Console.WriteLine("left: " + jaggedArray[row][k3]);
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
                    Console.WriteLine(visible3);
                    for (int k4 = col+1; k4 <= jaggedArray[row].Length - 1; k4++)
                    {
                        Console.WriteLine("right: " + jaggedArray[row][k4]);
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

                    Console.WriteLine(visible4);
                    if (visible4 || visible || visible2 || visible3)
                    {
                        Console.WriteLine("visible");
                        count++;
                    }
                    Console.WriteLine("=====");
                }

            }
            return count;
        }




    }
}
