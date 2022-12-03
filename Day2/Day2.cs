using System.Linq;
using System.Threading.Tasks;

namespace adventofcode_2022.Day2
{
	class Day2
    {
		
		public void solve()
		{
   

            // Example #2
            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Jalil\Desktop\src\C#\adventofcode-2022\Day2\input.txt");

            /*
             * 1
             */
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
                        int score = myHand - enemyHand;

                        if (score == 0)
                        {
                            roundScore = 3;
                        }else if(Math.Abs(score)==1)
                        {
                            if (score > 0)
                            {
                                roundScore = 6;
                            }
                           
                        }

                        else if (Math.Abs(score) == 2) { 
                            if (score < 0)
                            {
                                roundScore = 6;
                            }        

                        }


                        totalScore += roundScore + myHand;

                    }

                }

            }
            Console.WriteLine(totalScore);

            /*
          * 2
          */
            var hand2 = new Dictionary<string, int>();
            hand2.Add("X", 0);
            hand2.Add("Y", 3);
            hand2.Add("Z", 6);



            hand2.Add("A", 1);
            hand2.Add("B", 2);
            hand2.Add("C", 3);
            int totalScore2 = 0;
            foreach (string line in lines)
            {
                int enemyHand;
                if (hand2.TryGetValue(line[0].ToString(), out enemyHand))
                {
                    int score;
                    if (hand2.TryGetValue(line[2].ToString(), out score))
                    {
                    
                        int deltaHand = enemyHand- score;

                        int myHand = 0;
                        if(deltaHand > 0)
                        {
                            myHand = enemyHand - 1;
                            if (myHand == 0)
                            {
                                myHand = 3;
                            }
                        }else if(deltaHand <= 0 && deltaHand>= -2)
                        {
                            myHand = enemyHand;
                        }
                        else if (deltaHand <= -3)
                        {
                            myHand = enemyHand+1;
                            if (myHand == 4)
                            {
                                myHand = 1;
                            }
                        }


                        totalScore2 += myHand + score;

                    }

                }

            }
            Console.WriteLine(totalScore2);
            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }

	}
}