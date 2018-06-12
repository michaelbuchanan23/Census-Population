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
             * The 2010 Census puts populations of 26 largest US metro areas at 18897109, 12828837, 9461105, 6371773, 5965343, 5946800, 
             * 5582170, 5564635, 5268860, 4552402, 4335391, 4296250, 4224851, 4192887, 3439809, 3279833, 3095313, 2812896, 2783243, 2710489, 
             * 2543482, 2356285, 2226009, 2149127, 2142508, and 2134411.
             * Can you find a subset of these areas where a total of exactly 100,000,000 people live, assuming the census estimates are exactly right?
             */

            //initializing the integer array with the city populations
            int[] populations = new int[] { 18897109, 12828837, 9461105, 6371773, 5965343, 5946800, 5582170, 5564635, 5268860, 4552402, 4335391, 4296250, 4224851, 4192887, 3439809, 3279833, 3095313, 2812896, 2783243, 2710489, 2543482, 2356285, 2226009, 2149127, 2142508, 2134411 };

            //initializing variables for goal, random numbers and the randomArray which will be used to keep trying to find an array with 100,000,000 in it
            int goal = 0;
            Random rnd = new Random();
            int[] randomArray = new int[0];

            //initializing a variable to tally how many times the loop iterates before it gets the correct answer
            int iteration = 0;

            //while loop that will keep running until an array with 100,000,000 population is found
            while (goal != 100000000) {
                //randomizing the size of the array
                randomArray = new int[rnd.Next(0, 26)];

                //keep iterating the array until the randomArray is full of random, unique numbers from populuations array--
                //--then see if the total equals 100,000,000 once the array is full
                for (int idx = 0; idx < randomArray.Length; idx++) {
                    int randNo = rnd.Next(0, 26);

                    //while loop to make sure numbers are not duplicates when added to our randomArray from populations array
                    bool alreadyExists = true;
                    while (alreadyExists != false) {
                        alreadyExists = false;
                        randNo = rnd.Next(0, 26);
                        for (int idx3 = 0; idx3 < randomArray.Length; idx3++) {
                            if (populations[randNo].Equals(randomArray[idx3])) {
                                alreadyExists = true;
                            }
                        }
                    }
                    //add the unique populations number to the random array
                    randomArray[idx] = populations[randNo];

                    //the goal is set to the sum of the random array
                    goal = randomArray.Sum();
                }

                //once our randomArray is equal to 100,000,000 output the answer and how many iterations that it took
                if (randomArray.Sum() == 100000000) {
					Array.Sort(randomArray);
					Array.Reverse(randomArray);
                    for (int idx2 = 0; idx2 < randomArray.Length; idx2++) {
                        if (idx2 > 0 && idx2 % 6 == 0) {
                            Console.WriteLine("");
                        }
                        Console.Write($"  {randomArray[idx2]}  ");
                    }
                    Console.WriteLine("");
                    Console.WriteLine($"goal: {goal}");
                    Console.WriteLine($"array sum: {randomArray.Sum()}");
                    Console.WriteLine($"iterations: {iteration}");
                }
                //increment the iteration counter to see how many times it took to get our answer
                iteration++;
            }
        }
    }
}