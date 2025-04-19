using Sort.Base;

public class BucketSort : Base
{
    public override void Sort(int[] elements)
    {
        int max = elements.Max();
        int bucketCount = 10;
        List<int>[] buckets = new List<int>[bucketCount];
        for (int i = 0; i < bucketCount; i++)
            buckets[i] = new List<int>();

        foreach (var item in elements)
        {
            int bucketIndex = item * bucketCount / (max + 1);
            buckets[bucketIndex].Add(item);
        }

        int index = 0;
        foreach (var bucket in buckets)
        {
            bucket.Sort();
            foreach (var item in bucket)
                elements[index++] = item;
        }
    }
}