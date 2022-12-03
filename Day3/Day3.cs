using System.Linq;
using System.Threading.Tasks;

namespace adventofcode_2022.Day3
{
	class Day3
	{
		
		public void solve()
		{
   

            // Example #2
            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Jalil\Desktop\src\C#\adventofcode-2022\Day3\input.txt");


            var hand = new Dictionary<string, int>();
            hand.Add("X",1);
            hand.Add("Y",2);
            hand.Add("Z",3);



            hand.Add("A", 1);
            hand.Add("B", 2);
            hand.Add("C", 3);
            int totalScore = 0;
            foreach (string line in lines)
            {
                int enemyHand;
                if (hand.TryGetValue(line[0].ToString(), out enemyHand))
                {
                    int myHand;
                    if (hand.TryGetValue(line[2].ToString(), out myHand))
                    {
                        int roundScore = 0;
                        if(enemyHand > myHand)
                        {
                            if(enemyHand == 3 && myHand == 1)
                            {
                                roundScore = 6+ myHand;
                            }
                            else
                            {
                                roundScore = 0+ myHand;

                            }
                        }
                        else if (enemyHand < myHand)
                        {

                            if (enemyHand == 1 && myHand == 3)
                            {
                                roundScore = 0+ myHand;
                            }
                            else
                            {
                                roundScore = 6+ myHand;

                            }
                           
                        }
                        else if(enemyHand == myHand)
                        {
                            roundScore = 3 + myHand;
                        }
                        totalScore += roundScore;

                    }

                }

            }
            Console.WriteLine(totalScore);


            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }

	}
}