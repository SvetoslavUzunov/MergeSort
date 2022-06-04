namespace MergeSort;

public class Program
{
    public static void Main()
    {
        var array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        Console.WriteLine(string.Join(" ", Splits(array)));
    }

    private static int[] Splits(int[] array)
    {
        if (array.Length == 1) return array;

        int middle = array.Length / 2;
        var leftPart = new int[middle];
        var rightPart = new int[array.Length - middle];

        for (int i = 0; i < middle; i++)
        {
            leftPart[i] = array[i];
        }

        for (int i = 0; i < array.Length - middle; i++)
        {
            rightPart[i] = array[(array.Length / 2) + i];
        }

        leftPart = Splits(leftPart);
        rightPart = Splits(rightPart);
        return Merge(leftPart, rightPart);
    }

    private static int[] Merge(int[] leftPart, int[] rightPart)
    {
        var leftIncrease = 0;
        var rightIncrease = 0;
        var mergeArray = new int[leftPart.Length + rightPart.Length];

        for (int i = 0; i < mergeArray.Length; i++)
        {
            if (rightIncrease == rightPart.Length || ((leftIncrease < leftPart.Length) && (leftPart[leftIncrease] <= rightPart[rightIncrease])))
            {
                mergeArray[i] = leftPart[leftIncrease];
                leftIncrease++;
            }
            else if (leftIncrease == leftPart.Length || ((rightIncrease < rightPart.Length) && (leftPart[leftIncrease] >= rightPart[rightIncrease])))
            {
                mergeArray[i] = rightPart[rightIncrease];
                rightIncrease++;
            }
        }
        return mergeArray;
    }
}