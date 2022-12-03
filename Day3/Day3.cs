using System.Linq;
using System.Threading.Tasks;

namespace adventofcode_2022.Day3
{
	class Day3
	{
		
		public void solve()
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
                string secondhalf = line.Substring((line.Length / 2), line.Length/ 2);

                var firsthalfLetters = new HashSet<char>(firsthalf);
                foreach (char secondhalfLetter in secondhalf)
                {
                    if (firsthalfLetters.Contains(secondhalfLetter))
                    {

                        int priority;
                        if (itemsValue.TryGetValue(secondhalfLetter.ToString().ToLower(), out priority))
                        {
                            if (Char.IsUpper(secondhalfLetter)){
                                priority += 26;
                            }
                        }
                        sumPriority += priority;
                        break;
                    }
                }
    
             }
            Console.WriteLine(sumPriority);



            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }

	}
}