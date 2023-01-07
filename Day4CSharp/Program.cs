using System;
namespace Day4CSharp;
class Program
{
    static void Main(string[] args)
    {
        List<bingoCard> bingoCards = new List<bingoCard>();

        string[] lines = File.ReadAllLines("data.txt");
        List<int> instructions = Array.ConvertAll(lines[0].Split(","), c => int.Parse(c)).ToList();

        //split lines into cards
        List<string> cardLines = new List<string>();
        for (int i = 2; i < lines.Length; i++)
        {
            cardLines.Add(lines[i]);
            if ((i) % 6 == 0)
            {
                bingoCards.Add(new bingoCard(cardLines.ToArray()));
                cardLines.Clear();
                i++;
            }
        }

        
        foreach (int instruction in instructions)
        {
            for (int i = 0; i < bingoCards.Count; i++)
            {
                bingoCard card = bingoCards[i];
                card.MarkNumber(instruction);
                if (card.CheckWin())
                {
                    if (bingoCards.Count() == 1)
                    {
                        Console.WriteLine("Final score: " + card.GetScore(instruction));
                    }
                    //remove from list
                    bingoCards.Remove(card);
                    i--;
                }
            }
            
        }
    }
}
class bingoCard
{
    public List<List<int>> numbers = new List<List<int>>();
    public bingoCard(string[] input)
    {
        foreach (string rawLine in input)
        {
            string line;
            line = rawLine.Replace("  ", " ");
            if (line[0] == ' ')
                line = line.Substring(1);
            List<int> row = Array.ConvertAll(line.Split(" "), c => int.Parse(c)).ToList();
            numbers.Add(row);
        }
    }
    public bool CheckWin()
    {
        bool win = false;

        //check rows
        for (int i = 0; i < numbers.Count; i++)
        {
            if (numbers[i].All(x => x == -1))
            {
                win = true;
            }
        }

        //check columns
        for (int i = 0; i < numbers.Count; i++)
        {
            if (numbers.All(x => x[i] == -1))
            {
                win = true;
            }
        }
        return win;
    }
    public int GetScore(int number)
    {
        int score = 0;
        for (int i = 0; i < numbers.Count; i++)
        {
            for (int j = 0; j < numbers[i].Count; j++)
            {
                if (numbers[i][j] != -1)
                {
                    score += numbers[i][j];
                }
            }
        }
        return score * number;
    }
    public void MarkNumber(int number)
    {
        for (int i = 0; i < numbers.Count; i++)
        {
            for (int j = 0; j < numbers[i].Count; j++)
            {
                if (numbers[i][j] == number)
                {
                    numbers[i][j] = -1;
                }
            }
        }
    }
}

