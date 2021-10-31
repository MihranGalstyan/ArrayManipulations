using System;

namespace ArrayManipulations2D
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the HIGH of array: ");
            int high = int.Parse(Console.ReadLine());
            Console.Write("Enter the WIDTH of array: ");
            int width = int.Parse(Console.ReadLine());
            Console.Write("Enter the START of RANDOM numbers: ");
            int randomStart = int.Parse(Console.ReadLine());
            Console.Write("Enter the END of RANDOM numbers: ");
            int randomEnd = int.Parse(Console.ReadLine());
            Console.WriteLine();

            int[,] yourArray = NewArray(high, width, randomStart, randomEnd);
            int[] yourArraysDiagonal = ArrayDiagonal(yourArray);
            //int arrayMax = GetArrayMax(yourArray);
            //int arrayMin = GetArrayMin(yourArray);
            //int diagMax = GetDiagonalMax(yourArrayDiagonal);
            //int diagMin = GetDiagonalMin(yourArrayDiagonal);

            PrintArray("Here is your array!: ",yourArray);
            Console.WriteLine();
            PrintArraysMax("Your arrays Max is: ", yourArray);
            Console.WriteLine();
            PrintArraysMin("Your arrays Min is: ", yourArray);
            Console.WriteLine();
            PrintArray("Here is your arrays Diagonal!: ", yourArraysDiagonal);
            Console.WriteLine();
            PrintArraysMax("That is Diagonals Max!: ", yourArraysDiagonal);
            Console.WriteLine();
            PrintArraysMin("This is Diagonals Min!: ", yourArraysDiagonal);
            Console.WriteLine();
            Swap1DMaxMin(yourArraysDiagonal);
            PrintArray("Here is SWAPPED Diagonal!: ", yourArraysDiagonal);

        }
        /// <summary>
        /// Creates new 2D array
        /// </summary>
        /// <param name="high">High of array</param>
        /// <param name="width">Width of array</param>
        /// <param name="randomStart">Start random number</param>
        /// <param name="randomEnd">End random number</param>
        /// <returns>Returns 2D array filled by radom numbers</returns>
        public static int[,] NewArray(int high, int width, int randomStart, int randomEnd)
        {
            if (high > 0 && width > 0)
            {
                int[,] arr = new int[high, width];
                Random rnd = new Random();
                for (int i = 0; i < high; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                    arr[i, j] = rnd.Next(randomStart, randomEnd);
                    }
                }
                return arr;
            }
            return null;
            
        }

        /// <summary>
        /// Prints created array
        /// </summary>
        /// <param name="comment">Comment for array</param>
        /// <param name="array">Given array</param>
        public static void PrintArray(String comment, int[,] array)
        {
            if (array != null)
            {
                Console.WriteLine($"{comment} \n");
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        Console.Write($"{array[i, j]} ");
                    }
                    Console.WriteLine("\n");
                }
            }
        }

        /// <summary>
        /// Prints arrays maximum value
        /// </summary>
        /// <param name="comment">Comment for maximum value</param>
        /// <param name="array">Given array</param>
        public static void PrintArraysMax(String comment, int[,] array)
        {
            int index_i = 0;
            int index_j = 0;
            int max = array[0, 0];
            for (int i = 1; i < array.GetLength(0); i++)
            {
                for (int j = 1; j < array.GetLength(1); j++)
                {
                    if (array[i, j] > max) 
                    {
                    max = array[i, j];
                    index_i = i;
                    index_j = j;
                    }
                }
            }
            Console.WriteLine($"{comment} [{index_i},{index_j}] {max}\n");
        }

        /// <summary>
        /// Prints arrays minimum value
        /// </summary>
        /// <param name="comment">Comment for minimum value</param>
        /// <param name="array">Given array</param>
        public static void PrintArraysMin(String comment, int[,] array)
        {
            int index_i = 0;
            int index_j = 0;
            int min = array[0, 0];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] < min)
                    {
                        min = array[i, j];
                        index_i = i;
                        index_j = j;
                    }
                }
            }
            Console.WriteLine($"{comment} [{index_i},{index_j}] {min}\n");
        }

        /// <summary>
        /// Prints array (Overloading for 1D)
        /// </summary>
        /// <param name="comment">Comment for array</param>
        /// <param name="array1D">Given array</param>
        public static void PrintArray(String comment, int[] array1D)
        {
            if (array1D != null)
            {
                Console.WriteLine($"{comment}\n");
                for (int i = 0; i < array1D.Length; i++)
                {
                Console.Write($"{array1D[i]} ");
                }
            }
            else
            {
                Console.WriteLine("Error! There is no 1D array");
            }
        }

        /// <summary>
        /// Prints arrays maximum (Overload for 1D)
        /// </summary>
        /// <param name="comment">Comment for Diagonal maximum</param>
        /// <param name="array1D">Given Diagonal array</param>
        public static void PrintArraysMax(String comment, int[] array1D)
        {
            int index = 0;
            if (array1D != null)
            {
                int max = array1D[0];
                for (int i = 0; i < array1D.Length; i++)
                {
                    if (array1D[i] > max)
                    {
                        max = array1D[i];
                        index = i;
                    }
                }
                Console.WriteLine($"{comment} [{index}] {max}\n");
            }
            else
            {
                Console.WriteLine("Error! There is no 1D array! No maximum!");
            }
        }

        /// <summary>
        /// Prints arrays minimum (Overload for 1D)
        /// </summary>
        /// <param name="comment">Comment for Diagonal minimum</param>
        /// <param name="array1D">Given Diagonal array</param>
        public static void PrintArraysMin(String comment, int[] array1D)
        {
            int index = 0;
            if (array1D != null)
            {
                int min = array1D[0];
                for (int i = 0; i < array1D.Length; i++)
                {
                    if (array1D[i] < min)
                    {
                    min = array1D[i];
                        index = i;
                    }
                }
                Console.WriteLine($"{comment} [{index}] {min}\n");
            }
            else
            {
                Console.WriteLine("Error! There is no 1D array! No minimum!");
            }
        }

        /// <summary>
        /// Finds given arrays Diagonal, if it exists
        /// </summary>
        /// <param name="array">Given array</param>
        /// <returns>Returns Diagonal array</returns>
        public static int [] ArrayDiagonal (int [,] array)
        {
            if (array != null)
            {
                int[] arrayDiag = new int[array.GetLength(0)];
                if (array.GetLength(0) == array.GetLength(1))
                {
                    for (int i = 0; i < array.GetLength(0); i++)
                    {
                        arrayDiag[i] = array[i, i];
                    }
                    return arrayDiag;
                }
                return null;
            }
            return null;
        }

        /// <summary>
        /// Finds arrays maximum value
        /// </summary>
        /// <param name="array">Given array</param>
        /// <returns>Returns arrays maximum value</returns>
        public static int GetArraysMax(int[,] array)
        {
            int maxArray = array[0,0];
            for (int i = 1; i < array.GetLength(0); i++)
            {
                for(int j = 1; j < array.GetLength(1); j++)
                if (array[i,j] > maxArray)
                    maxArray = array[i,j];
            }
            return maxArray;
        }

        /// <summary>
        /// Finds arrays minimum value
        /// </summary>
        /// <param name="array">Given array</param>
        /// <returns>Returns arrays minimum value</returns>
        public static int GetArraysMin(int[,] array)
        {
            int minArray = array[0, 0];
            for (int i = 1; i < array.GetLength(0); i++)
            {
                for (int j = 1; j < array.GetLength(1); j++)
                    if (array[i, j] < minArray)
                        minArray = array[i, j];
            }
            return minArray;
        }

        /// <summary>
        /// Finds arrays maximum value (Overload for 1D)
        /// </summary>
        /// <param name="array1D">Given Diagonal</param>
        /// <returns>Returns Diagonals maximum value</returns>
        public static int GetArraysMax(int[] array1D)
        {
            if (array1D != null)
            {
                int maxDiag = array1D[0];
                for (int i = 1; i < array1D.Length; i++)
                {
                    if (array1D[i] > maxDiag)
                        maxDiag = array1D[i];
                }
                return maxDiag;
            }
            return 0;
        }

        /// <summary>
        /// Finds arrays minimum value (Overload for 1D)
        /// </summary>
        /// <param name="array1D">Given Diagonal</param>
        /// <returns>Returns Diagonals minimum value</returns>
        public static int GetArraysMin(int[] array1D)
        {
            if (array1D != null)
            {
                int minDiag = array1D[0];
                for (int i = 1; i < array1D.Length; i++)
                {
                if (array1D[i] < minDiag)
                    minDiag = array1D[i];
                }
                return minDiag;
            }
            return 0;
        }

        /// <summary>
        /// Finds 1D arrays maximum and minimum values and swappes
        /// </summary>
        /// <param name="array1D">Given 1D array</param>
        /// <returns>Returns 1D array with swapped minimum and maximum values</returns>
        public static int[] Swap1DMaxMin(int[] array1D)
        {
            if (array1D != null)
            {
                int max = array1D[0];
                int min = array1D[0];
                for (int i = 0; i < array1D.Length; i++)
                {
                    if (array1D[i] > max)
                        max = array1D[i];
                    else if (array1D[i] < min)
                        min = array1D[i];
                }
                for (int i = 0; i < array1D.Length; i++)
                {
                    if (array1D[i] == max)
                        array1D[i] = min;
                    else if (array1D[i] == min)
                        array1D[i] = max;
                }
                return array1D;

            }
            return null;
        }
    }
}
