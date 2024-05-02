using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// https://www.hackerrank.com/challenges/torque-and-development/problem
namespace Leetcode
{
    public class TorqueAndDevelopment
    {

        /*
    * Complete the 'roadsAndLibraries' function below.
    *
    * The function is expected to return a LONG_INTEGER.
    * The function accepts following parameters:
    *  1. INTEGER n
    *  2. INTEGER c_lib
    *  3. INTEGER c_road
    *  4. 2D_INTEGER_ARRAY cities
    */

        public long roadsAndLibraries(int n, int c_lib, int c_road, List<List<int>> cities)
        {
            return 0;
        }

        public TorqueAndDevelopment()
        {
            TextWriter textWriter = new StreamWriter("torque-and-development.txt", false);
            TextReader textReader = new StreamReader("input00.txt");
            var q1 = textReader.ReadLine();
            int q = Convert.ToInt32(q1.Trim());

            for (int qItr = 0; qItr < q; qItr++)
            {
                string[] firstMultipleInput = textReader.ReadLine().TrimEnd().Split(' ');

                int n = Convert.ToInt32(firstMultipleInput[0]);

                int m = Convert.ToInt32(firstMultipleInput[1]);

                int c_lib = Convert.ToInt32(firstMultipleInput[2]);

                int c_road = Convert.ToInt32(firstMultipleInput[3]);

                List<List<int>> cities = new List<List<int>>();

                for (int i = 0; i < m; i++)
                {
                    cities.Add(textReader.ReadLine().TrimEnd().Split(' ').ToList().Select(citiesTemp => Convert.ToInt32(citiesTemp)).ToList());
                }

                long result = roadsAndLibraries(n, c_lib, c_road, cities);

                textWriter.WriteLine(result);
            }

            textWriter.Flush();
            textWriter.Close();
            textReader.Close();
        }
    }
}
