using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace AoC_day_4
{
    class number
    {
        public int value;
        public bool marked = false;
        public number()
        {
            marked = false;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] textFile = File.ReadAllLines("test.txt");
            List<string> data = new List<string>();

            int cardSize = textFile[2].Split(' ').Count();

            for(int line = 2; line <= textFile.Length-cardSize+2; line++)
            {
                List<List<string>> bingoCard = new List<List<string>>();


                for (int j = 0; j < cardSize; j++)
                {
                    List<string> cardLine = new List<string>();

                    string[] cardLineArray = textFile[line].Split(' ');
                    foreach (string value in cardLineArray)
                    {
                        cardLine.Add(value);
                    }
                    bingoCard.Add(cardLine);
                }
            }



            string[] numsToDraw = data[0].Split(',');
            int cardNum = 1;
            int index = 0;



            /*
            while (index < cardNum*(cardSize+1))
            {

            }
            for (int i = 0; i < cardSize; i++)
            {

            }
            */
        }
    }
}
