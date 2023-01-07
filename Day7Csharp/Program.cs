namespace Day7Csharp;

class Program
{
    static void Main(string[] args)
    {        
        Part2();
    }
    static void Part1()
    {
        string input = System.IO.File.ReadAllText("data.txt");
        string[] inputArray = input.Split(',');
        List<int> inputList = inputArray.Select(int.Parse).ToList();
        inputList.Sort();
        int median = inputList[inputList.Count / 2];
        int totalDistance = 0;
        foreach (int number in inputList)
        {
            totalDistance += Math.Abs(number - median);
        }

        Console.WriteLine(totalDistance);
    }
    static void Part2()
    {
        string input = System.IO.File.ReadAllText("data.txt");
        string[] inputArray = input.Split(',');
        List<int> inputList = inputArray.Select(int.Parse).ToList();
        inputList.Sort();

        int? shortestDistance = null;
        for (int num1 = inputList[0]; num1 < inputList[inputList.Count()-1]; num1++)
        {
            int totalDistance = 0;
            foreach (int num2 in inputList)
            {
                totalDistance += ((Math.Abs(num1 - num2) * (Math.Abs(num1 - num2) + 1)))/2;
            }
            if (shortestDistance == null || totalDistance < shortestDistance)
            {
                shortestDistance = totalDistance;
            }
        }

        //print the total distance
        Console.WriteLine(shortestDistance);
    }
}
