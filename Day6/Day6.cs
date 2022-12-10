using System.Linq;
using System.Threading.Tasks;

namespace adventofcode_2022.Day6
{


	class Day6 : SolverInterface
    {
		
	
        public void solvePart1()
        {

            string text = System.IO.File.ReadAllText(@"C:\Users\Jalil\Desktop\src\C#\adventofcode-2022\Day6\input.txt");

     
            for (int i = 0; i < text.Length-3; i++)
            {
                string combination = text[i].ToString() + text[i+1].ToString() + text[i+2].ToString() + text[i+3].ToString();

                if (this.uniqueCharacters(combination))
                {
                    Console.WriteLine(i+4);
                    break;
                }
            }

            System.Console.ReadKey();
        }

        public void solvePart2()
        {
            string text = System.IO.File.ReadAllText(@"C:\Users\Jalil\Desktop\src\C#\adventofcode-2022\Day6\input.txt");

            for (int i = 0; i < text.Length - 13; i++)
            {

                string combination ="";

                for (int j = 0; j < 14; j++)
                {
                    combination += text[i+j].ToString();
                }

                if (this.uniqueCharacters(combination))
                {
                    Console.WriteLine(i + 14);
                    break;
                }
            }
            System.Console.ReadKey();
        }

        //https://www.geeksforgeeks.org/determine-string-unique-characters/
        public virtual bool uniqueCharacters(string str)
        {
            // Assuming string can have
            // characters a-z this has
            // 32 bits set to 0
            int checker = 0;

            for (int i = 0; i < str.Length; i++)
            {
                int bitAtIndex = str[i] - 'a';

                // if that bit is already set
                // in checker, return false
                if ((checker & (1 << bitAtIndex)) > 0)
                {
                    return false;
                }

                // otherwise update and continue by
                // setting that bit in the checker
                checker = checker | (1 << bitAtIndex);
            }

            // no duplicates encountered,
            // return true
            return true;
        }

    }
}
