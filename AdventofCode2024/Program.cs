using System;
class AdventofCode
{
    static void Main()
    {
        Day1();
        Day2();

    }
    static void Day1()
    {
        //Part1
        string filePath = "Day1.txt";
        string[] lines = File.ReadAllLines(filePath);
        int[] left = new int[lines.Length];
        int[] right = new int[lines.Length];
        for (int i = 0; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            left[i] = int.Parse(parts[0]);
            right[i] = int.Parse(parts[1]);
        }
        Array.Sort(left);
        Array.Sort(right);
        int totalDistance = 0;
        for (int i = 0; i < left.Length; i++)
        {
            totalDistance += Math.Abs(left[i] - right[i]);
        }
        Console.WriteLine("Total Distance :" + totalDistance);
        //Part2
        long similarity = 0;
        for (int i = 0; i < left.Length; i++)
        {
            int count = 0;
            for (int j = 0; j < right.Length; j++)
            {
                if (left[i] == right[j])
                {
                    count++;
                }
            }
            similarity += left[i] * count;
        }

        Console.WriteLine("Similarity Score :" + similarity);
    }
    //Day2Part1Part2
    static void Day2()
    {
        string[] lines = File.ReadAllLines("Day2.txt");
        int safeCountPart1 = 0;
        int safeCountPart2 = 0;

        foreach (string line in lines)
        {
            string[] parts = line.Split(' ');
            int[] levels = new int[parts.Length];
            for (int i = 0; i < parts.Length; i++)
                levels[i] = int.Parse(parts[i]);

            if (IsSafe(levels))
                safeCountPart1++;

            if (IsSafe(levels))
                safeCountPart2++;
            else
            {
                bool becameSafe = false;
                for (int remove = 0; remove < levels.Length; remove++)
                {
                    int[] newLevels = new int[levels.Length - 1];
                    int index = 0;
                    for (int j = 0; j < levels.Length; j++)
                    {
                        if (j != remove)
                        {
                            newLevels[index] = levels[j];
                            index++;
                        }
                    }
                    if (IsSafe(newLevels))
                    {
                        becameSafe = true;
                        break;
                    }
                }
                if (becameSafe)
                    safeCountPart2++;
            }
        }

        Console.WriteLine("Part 1 - Safe reports: " + safeCountPart1);
        Console.WriteLine("Part 2 - Safe reports (with Problem Dampener): " + safeCountPart2);
    }

    static bool IsSafe(int[] levels)
    {
        bool increasing = levels[1] > levels[0];
        bool decreasing = levels[1] < levels[0];

        for (int i = 1; i < levels.Length; i++)
        {
            int diff = levels[i] - levels[i - 1];
            if (diff == 0)
                return false;
            if (Math.Abs(diff) > 3)
                return false;
            if (increasing && diff < 0)
                return false;
            if (decreasing && diff > 0)
                return false;
        }
        return true;
    }
}
    

