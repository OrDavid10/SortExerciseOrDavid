using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortExercise
{
    public class Program
    {
      // Function to merge two subarrays
        static void Merge(int[] array, int left, int middle, int right)
        {
            // Create a temporary array for holding the merged subarrays
            int[] temp = new int[right - left + 1];

            // Initialize the indexes of the left, middle, and right subarrays
            int leftIndex = left;
            int middleIndex = middle + 1;
            int tempIndex = 0;

            // Merge the subarrays until one of them is empty
            while (leftIndex <= middle && middleIndex <= right)
            {
                if (array[leftIndex] <= array[middleIndex])
                {
                    temp[tempIndex] = array[leftIndex];
                    leftIndex++;
                }
                else
                {
                    temp[tempIndex] = array[middleIndex];
                    middleIndex++;
                }
                tempIndex++;
            }

            // Copy the remaining elements of the left subarray, if any
            while (leftIndex <= middle)
            {
                temp[tempIndex] = array[leftIndex];
                leftIndex++;
                tempIndex++;
            }

            // Copy the remaining elements of the right subarray, if any
            while (middleIndex <= right)
            {
                temp[tempIndex] = array[middleIndex];
                middleIndex++;
                tempIndex++;
            }

            // Copy the merged array back to the original array
            for (int i = 0; i < temp.Length; i++)
            {
                array[left + i] = temp[i];
            }
        }

        // Function to sort an array using the merge sort algorithm
        static void MergeSort(int[] array, int left, int right)
        {
            // Check if the array can be split further
            if (left < right)
            {
                // Calculate the middle index of the array
                int middle = (left + right) / 2;

                // Recursively sort the left and right subarrays
                MergeSort(array, left, middle);
                MergeSort(array, middle + 1, right);

                // Merge the sorted subarrays
                Merge(array, left, middle, right);
            }
        }
        //Function to print an array of integers
        public static void PrintArr(int[] array)
        {   
            foreach (int number in array)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }
        public static void Main(string[] args)
        {
            // Create an unsorted array of integers
            int[] array = { -7, 3, -4, 13, 99, 0, 1,-100 };

            // Display the unsorted array
            Console.WriteLine("The array before the sort:");
            PrintArr(array);

            // Sort the array using the merge sort algorithm
            MergeSort(array, 0, array.Length - 1);

            // Display the sorted array
            Console.WriteLine("The array after the sort:");
            PrintArr(array);
        }
    }
}
