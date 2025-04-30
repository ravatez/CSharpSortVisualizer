using System;
public static class Utils
{
    private static readonly Random rnd = new Random();  // Single instance

    public static int GetRandomNumberInRange(int min, int max)
    {
        return rnd.Next(min, max);
    }

    public static int[] GetArrayWithRandomNumbers(int min, int max, int length)
    {
        int[] rndArray = new int[length];
        for (int i = 0; i < length; i++)
        {
            rndArray[i] = GetRandomNumberInRange(min, max);
        }
        return rndArray;
    }
}