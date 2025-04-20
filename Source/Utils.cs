using System;

public static class Utils
{
    public static int GetRandomNumberInRange(int min,int max)
    {
        Random rnd  = new Random();
        return rnd.Next(min,max);
    }

    public static int[] GetArrayWithRandomNumbers(int min,int max,int length)
    {
        int[] rndArray = new int[length];
        for(int i = 0; i< length; i++)
        {
            rndArray[i] = GetRandomNumberInRange(min,max);
        }
        return rndArray;
    }
}