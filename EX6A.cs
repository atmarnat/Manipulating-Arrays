using System;

namespace ES6a
{
    public class Program
    {
        //counts number of elements in the array
        public static int GetLength(int[] arr)
        {
            int count = 0;
            foreach (int number in arr) count++;
            return count;
        }
        //sums up elements in the array 
        public static int GetSum(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < GetLength(arr); i++) sum += arr[i];
            return sum;
        }
        //lamda to return the sum / length, for average
        public static int GetMean(int[] arr) => GetSum(arr) / GetLength(arr);
        //reverses an array
        public static int[] ReverseArray(int[] arr)
        {
            int[] reversed = new int[GetLength(arr)];
            int index = 0;
            for (int i = GetLength(arr) - 1; i >= 0; i--)
            {
                reversed[index] = arr[i];
                index++;
            }
            return reversed;
        }
        //rotates an array to the left or right
        public static int[] RotateArray(string dir, int n, int[] arr)
        {
            int[] rotated = new int[GetLength(arr)];
            int index;

            //this handles if the rotation amount is larger than the size of the array
            //a rotation of size arr.Length = 1 full rotation, as if nothing happened.
            while (n > arr.Length)
            {
                n -= arr.Length;
            }

            //sets rotated[n] to arr[0], then iterates for the size of the arr, filling elements 1 at a time
            if (dir == "right")
            {
                index = 0 + n;
                for (int i = 0; i < GetLength(arr); i++)
                {
                    if (index == GetLength(arr))
                    {
                        index = 0;
                    }
                    rotated[index] = arr[i];
                    index++;
                }
            }

            //sets rotated[0] to arr[n], then iterates for the size of the arr, filling elements 1 at a time
            if (dir == "left")
            {
                index = 0;
                for (int i = n; index < GetLength(arr); i++)
                { 
                    if (i == GetLength(arr))
                    {
                        i = 0;
                    }
                    rotated[index] = arr[i];
                    index++;
                }
            }

            return rotated;
        }
        //bubble sort (not an efficient sorting algorithm, but effective)
        public static int[] Sort(int[] arr)
        {
            int temp = 0;

            for (int i = 0; i < GetLength(arr) - 1; i++)        //outer loop
            {
                for (int j = i + 1; j < GetLength(arr); j++)    //inner loop
                {
                    if (arr[i] > arr[j])
                    {
                        temp = arr[i];      //simple swapping of elements
                        arr[i] = arr[j];    //n * n times
                        arr[j] = temp;
                    }
                }
            }

            return arr;
        }
        //prints out an array
        public static void ShowArray(int[] arr)
        {
            foreach(int x in arr)
            {
                Console.Write(x + " ");
            }
            Console.WriteLine("");
        }
        static void Main(string[] args)
        {
            //prints to console to make it easy to see it in action.
            int[] A = new int[] { 0, 2, 4, 6, 8, 10 };
            int[] B = new int[] { 1, 3, 5, 7, 9 };
            int[] C = new int[] { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5, 9 };

            Console.WriteLine("Computing the mean");
            Console.WriteLine("\tAvg of A: " + GetMean(A));
            Console.WriteLine("\tAvg of B: " + GetMean(B));
            Console.WriteLine("\tAvg of C: "+ GetMean(C));

            Console.WriteLine("Reverse the array");
            Console.Write("\tReverse of A: "); ShowArray(ReverseArray(A)); 
            Console.Write("\tReverse of B: "); ShowArray(ReverseArray(B));
            Console.Write("\tReverse of C: "); ShowArray(ReverseArray(C));

            Console.WriteLine("Rotating the array");
            Console.Write("\tRotation of A: "); ShowArray(RotateArray("left", 2, A));
            Console.Write("\tRotation of B: "); ShowArray(RotateArray("right", 2, B));
            Console.Write("\tRotation of C: "); ShowArray(RotateArray("left", 4, C));

            Console.WriteLine("Sorting the array");
            Console.Write("\tAvg of C: "); ShowArray(Sort(C));
        }
    }
}
