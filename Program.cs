using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderSpaceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Part 1: add rows and columns to the List.
            List<List<int>> list = new List<List<int>>();
            var rand = new Random();
            for (int i = 0; i < 3; i++)
            {
                // Put some integers in the inner lists.
                List<int> sublist = new List<int>();
                
                for (int v = 0; v < 2; v++)
                {
                    sublist.Add(rand.Next(1, 5));
                }
                // Add the sublist to the top-level List.
                list.Add(sublist);
            }

            char x = findLongestSingleSlot(list);
            Console.WriteLine(x);
            Console.ReadLine();

        }


        public static char findLongestSingleSlot(List<List<int>> leaveTimes)
        {

            List<int> temp = new List<int>();
            for (int i = 0; i < leaveTimes.Count; i++)
            {
                if (!temp.Contains(leaveTimes[i][0]))
                {
                    temp.Add(leaveTimes[i][0]);
                }

            }
            int[,] employee = new int[temp.Count, 2];


            for (int i = 0; i < temp.Count; i++)
            {
                employee[i, 0] = temp[i];
                int tempTime = 0;
                for (int x = 0; x < leaveTimes.Count; x++)
                {
                    if (leaveTimes[x][0] == temp[i])
                    {
                        tempTime += leaveTimes[x][1];
                    }
                }
                employee[i, 1] = tempTime;
            }

            int maxTime = 0;
            int employeeID = -1;
            for (int y = 0; y < employee.GetLength(0); y++)
            {
                if (employee[y, 1] > maxTime)
                {
                    maxTime = employee[y, 1];
                    employeeID = employee[y, 0];
                }
            }

            return (char)('A' - 1 + employeeID);
        }
    }
}
