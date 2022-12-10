using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace advent_of_code_day_3
{
    internal class Program
    {
        static bool CountOnes(List<string> dataList, int i)
        {
            bool moreOnes;
            int ones = 0;
            int zeros = 0;

            for (int j = 0; j < dataList.Count; j++)
            {
                if (dataList[j][i] == '1')
                {
                    ones += 1;
                }
                else
                {
                    zeros += 1;
                }
            }
            if (ones > zeros)
            {
                moreOnes = true;
            }
            else if (ones < zeros)
            {
                moreOnes = false;
            }
            else
            {
                moreOnes = true;
            }
            
            return moreOnes;
        }

        static void Main(string[] args)
        {
            //make dataList

            List<string> dataList = new List<string>();
            string[] dataArray = File.ReadAllLines("input.txt");
            for (int j = 0; j < dataArray.Length; j++)
            {
                dataList.Add(dataArray[j]);
            }

            //iterate untill only one number left

            int i = 0;
            while (dataList.Count > 1)
            {
                bool moreOnes = CountOnes(dataList, i);

                    //remove half of list
                    for (int j = dataList.Count-1; j >= 0; j--)
                    {
                        if (moreOnes)
                        {
                            if (dataList[j][i] == '1')
                            {
                                dataList.RemoveAt(j);
                            }
                        }
                        else
                        {
                            if (dataList[j][i] == '0')
                            {
                                dataList.RemoveAt(j);
                            }
                        }
                    }
                    foreach (string data in dataList)
                    {
                        Console.WriteLine(data);
                    }
                    Console.WriteLine("\n");                
                i++;
            }
            Console.ReadKey();
        }
    }
}
