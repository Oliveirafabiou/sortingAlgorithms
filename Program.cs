using System.IO;
using System.Text.Json;
using System.Collections.Generic;

public class SelectionSortExample
{
    public static void SelectionSort(int[] array)
    {
        int n = array.Length;

        // Move the boundary of the unsorted subarray one by one
        for (int i = 0; i < n - 1; i++)
        {
            // Find the minimum element in the unsorted portion
            int minIndex = i;
            for (int j = i + 1; j < n; j++)
            {
                if (array[j] < array[minIndex])
                {
                    minIndex = j;
                }
            }

            // Swap the found minimum element with the first unsorted element
            if (minIndex != i)
            {
                int temp = array[minIndex];
                array[minIndex] = array[i];
                array[i] = temp;
            }
        }
    }

    public static void Main()
    {
        var json = File.ReadAllText("arrays.json");
        var data = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, int[]>>>(json);
        var array = data["1024"]["aleatorio_sem_repeticao"];

        SelectionSort(array);
        Console.WriteLine("Sorted array: " + string.Join(", ", data));
    }
}
