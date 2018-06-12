using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Census_Population
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Solve this puzzle
             * ​Can you solve this puzzle? While not a requirement, we give priority consideration to candidates supplying a solution.
             * The 2010 Census puts populations of 26 largest US metro areas at 18897109, 12828837, 9461105, 6371773, 5965343, 5946800, 5582170, 5564635, 5268860, 4552402, 4335391, 4296250, 4224851, 4192887, 3439809, 3279833, 3095313, 2812896, 2783243, 2710489, 2543482, 2356285, 2226009, 2149127, 2142508, and 2134411.
             * Can you find a subset of these areas where a total of exactly 100,000,000 people live, assuming the census estimates are exactly right?
             */


            int[] populations = new int[] { 18897109, 12828837, 9461105, 6371773, 5965343, 5946800, 5582170, 5564635, 5268860, 4552402, 4335391, 4296250, 4224851, 4192887, 3439809, 3279833, 3095313, 2812896, 2783243, 2710489, 2543482, 2356285, 2226009, 2149127, 2142508, 2134411 };

            foreach (int pop in populations) {
                Console.WriteLine($"City Population: {pop}");
                Console.WriteLine(populations.Length);
            }

            int sumPop = populations.Sum();
            Console.WriteLine($"Sum of the populations: {sumPop}");

            int goal = 0;
            while (goal != 100000000) {
                Random rnd = new Random();
                int[] randomArray = new int[rnd.Next(0, 26)];
                for (int idx = 0; idx < randomArray.Length; idx++) {
                    int randNo = rnd.Next(0, 26);
                    bool alreadyExists = false;
                    while (alreadyExists == false) {
                        for (int idx3 = 0; idx3 < randomArray.Length; idx3++) {
                            if (!populations[randNo].Equals(randomArray[idx3])) {
                                alreadyExists = true;
                            } else {
                                randNo = rnd.Next(0, 26);
                            }
                        }
                    }
                    randomArray[idx] = populations[randNo];
                    goal = randomArray.Sum();
                    }
                foreach (int h in randomArray) {
                    Console.WriteLine($"{h}, ");
                    //Console.WriteLine(goal);
                    Console.ReadLine();

                }
                if (randomArray.Sum() == 100000000) {
                    for (int idx2 = 0; idx2 < randomArray.Length; idx2++) {
                        Console.WriteLine($"{randomArray[idx2]}, ");
                    }
                }
            }

        }
    }
}