using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"..\..\test1.txt";//path to file with triangle

            string[] rows = File.ReadAllLines(path);
            int[][] ar = new int[rows.Length][];     //array with values
            int[][] maxvalues = new int[rows.Length][];     //array with max length way on the each layer
            for (int i = 0; i < rows.Length; i++)
            {
                string[] numbers = rows[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                ar[i] = new int[numbers.Length];
                maxvalues[i] = new int[numbers.Length];
                for (int j = 0; j < numbers.Length; j++)
                {
                    ar[i][j] = int.Parse(numbers[j]);
                }

            }
            //dynamic programming
            //from the top
            //first step - way is empty
            maxvalues[0][0] = 0;
            int max = 0;
            //
            for (int i = 1; i < rows.Length; i++)// for all rows
            {
                max = 0;//max value in the row
                for (int j = 0; j < ar[i].Length; j++) for all numbers in row
                {
                    for (int lastway = j - 1; lastway <= j + 1; lastway++)
                    {//we can come from this elements  
                        if (!(lastway < 0) && !(lastway > ar[i - 1].Length - 1))//chacking: out of range array
                        {
                            {
                                if (max < (ar[i][j] + maxvalues[i - 1][lastway]))
                                {
                                    max = ar[i][j] + maxvalues[i - 1][lastway];// finding the max value with previous max elem 
                                }
                            }
                        }
                    }
                    maxvalues[i][j] = max;
                }
            }
            Console.WriteLine(@"Max length of the way is {0}", max);
            Console.Read();
        }
    }
}
