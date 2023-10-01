using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class ArrayOperation
    {

        // 1 3 5 7
        // 0 2 6 8 9

        public static void merge1(int[] arr1, int[] arr2, int n, int m)
        {
            for (int i = 0; i < n+m; i++)
            {
                for (int j = 0; j < n+m; j++)
                {
                    if (i >= n)
                    {
                        if (j >= n)
                        {
                            if (arr2[i-n] < arr2[j-n])
                                Swap(arr2, arr2, i-n, j-n);
                        }
                        else
                        {
                            if (arr2[i-n] < arr1[j])
                                Swap(arr2, arr1, i-n, j);
                        }
                    }
                    else
                    {
                        if (j >= n)
                        {
                            if (arr1[i] < arr2[j-n])                            
                                Swap(arr1, arr2, i, j-n);
                            
                        }
                        else
                        {
                            if (arr1[i] < arr1[j])
                                Swap(arr1, arr1, i, j);
                        }
                    }
                }
            }            
        }

        public static void merge(int[] arr1, int[] arr2, int n, int m)
        {            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (arr1[i] > arr2[j])
                    {
                        Swap(arr1, arr2, i, j);
                    }
                }
            }

            QuickSort(arr2, 0, arr2.Length - 1);
        }

        private static void Swap(int[] arr1, int[] arr2, int i, int j)
        {
            arr1[i] = arr1[i] + arr2[j];
            arr2[j] = arr1[i] - arr2[j];
            arr1[i] = arr1[i] - arr2[j];
        }

        private static void Swap(int[] arr1, int i, int j)
        {
            if (i == j)
                return;

            arr1[i] = arr1[i] + arr1[j];
            arr1[j] = arr1[i] - arr1[j];
            arr1[i] = arr1[i] - arr1[j];
        }

        public static void QuickSort(int[] arr, int low, int high)
        {            
            if (low < high)
            {
                int pivot = GetPivot(arr, low, high);
                QuickSort(arr, low, pivot - 1);
                QuickSort(arr, pivot + 1, high);
            }
        }

        private static int GetPivot(int[] arr, int low, int high)
        {
            int k = low - 1;
            int i = low;

            while (i <= high)
            {
                if (i == high)
                {
                    k++;
                    Swap(arr, high, k);
                }

                if (arr[i] < arr[high])
                {
                    k++;
                    if (arr[k] > arr[i])
                    {
                        Swap(arr, k, i);
                    }
                }

                i++;

            }

            return k;
        }

        public static void ConvertToOnes(int[,] grid)
        {
            int[,] result = new int[grid.GetLength(0), grid.GetLength(1)];

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                bool modified = false;

                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    result[i,j] = grid[i,j];

                    if (grid[i, j] == 1)
                    {
                        ConvertRowAndColumnsToOnes(result, i, j);
                        modified = true;
                        break;
                    }
                }

                if (modified)
                    break;
            }

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    grid[i, j] = result[i, j];
                }
            }
            
        }

        public static void ConvertRowAndColumnsToOnes(int[,] grid, int row, int column)
        {
            int k = column+1;
            while (k < grid.GetLength(1))
            {
                grid[row, k] = 1;
                k++;
            }

            k = row + 1;
            while (k < grid.GetLength(0))
            {
                grid[k, column] = 1;
                k++;
            }
        }


//        4 4
//0 0 0 0
//1 0 1 0
//0 1 1 0
//0 0 0 0

        //        3

        public static int numberOfEnclaves(int[,] grid)
        {

            var row = grid.GetLength(0); var column = grid.GetLength(1);
            int elements = 0;

            for (int i = 1; i < row - 1; i++)
            {
                for (int j = 1; j < column - 1; j++)
                {
                    if (grid[i,j] == 1)
                    {
                        if (!HaveColumnPath(grid, i, j, column))
                        {
                            if (!HaveRowPath(grid, i, j, row))
                            {
                                elements++;
                            }
                        }
                    }
                }
            }

            return elements;
        }

        private static bool HaveRowPath(int[,] grid, int i, int j, int rowLength)
        {
            bool path = true;

            for (int x = i + 1; x < rowLength; x++)
            {
                if (grid[x,j] == 0)
                {
                    path = false;
                    break;
                }
                else
                {
                    path = HaveColumnPath(grid, x, j, grid.GetLength(1));
                    if (path)
                        return path;
                }
            }

            if (!path)
            {
                path = true;
                for (int x = i - 1; x > -1; x--)
                {
                    if (grid[x,j] == 0)
                    {
                        path = false;
                        break;
                    }
                    else
                    {
                        path = HaveColumnPath(grid, x, j, grid.GetLength(1));
                        if (path)
                            return path;
                    }
                }
            }

            return path;
        }

        private static bool HaveColumnPath(int[,] grid, int i, int j, int columnLength)
        {
            bool path = true;

            for (int x = j + 1; x < columnLength; x++)
            {
                if (grid[i,x] == 0)
                {
                    path = false;
                    break;
                }
                else
                {
                    path = HaveRowPath(grid, i, x, grid.GetLength(0));
                    if (path)
                        return path;
                }
            }

            if (!path)
            {
                path = true;
                for (int x = j - 1; x > -1; x--)
                {
                    if (grid[i,x] == 0)
                    {
                        path = false;
                        break;
                    }
                    else
                    {
                        path = HaveRowPath(grid, i, x, grid.GetLength(0));

                        if (path)
                            return path;
                    }
                }
            }

            return path;
        }

        public static long GetNaturalNumber(long N)
        {
            String ans = "";
           
            while (N > 0)
            {
                ans = (N % 9).ToString() + ans;
                N = N / 9;
            }

            long a = long.Parse(ans);
            return a;
        }

        public static List<string> GetPermutations(string input)
        {
            List<string> list=new List<string>();

            if (string.IsNullOrEmpty(input))
                return null;

            if (input.Length == 1)
                return new List<string>(){ input };

            for (int i = 0; i < input.Length; i++)
            {
                string prev = input.Substring(0, i);
                string next = "";

                if (i + 1 < input.Length)
                {
                    next = input.Substring(i + 1);
                }

                var combinations = GetPermutations(prev + next);
                list.AddRange(combinations.Select(x => input[i] + x));            
            }    
            
            return list;
        }

        public static void convertToWave(int n, int[] a)
        {
            int i;
            for (i=1; i < n; i+=2)
            {
                var temp = a[i];
                a[i] = a[i - 1];
                a[i - 1] = temp;
            }

        }

        public static int minJumps(int[] arr)
        {
            int no = 0;
            int a = arr[0];
            int index = 0;            

            while (index < arr.Length-1)
            {
                a = arr[index];
                index += a;
                no++;
            }

            return no;
        }

        public static (int sumOfPositive, int prodOfNegative) Process(int[] arr)
        {
            int multiply = 1;
            int sum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0)
                {
                    multiply = multiply * arr[i];
                }
                else
                {
                    sum = sum + arr[i];
                }
            }

            return (sumOfPositive: sum, prodOfNegative: multiply) ;
        }

        // Function for finding maximum and value pair
        public static List<int> printClosest(int [] arr, int[] brr, int n, int m, int x)
        {
            // code here

            int[] result = new int[2];
            int nearValue = -1;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    int a = arr[i] + brr[j];
                    int rem = a > x ? a - x : x - a;
                    if (nearValue == -1)
                    {
                        result[0] = arr[i];
                        result[1] = brr[j];
                        nearValue = rem;
                    }
                    else
                    {
                        if (nearValue > rem && rem > 0)
                        {
                            nearValue = rem;
                            result[0] = arr[i];
                            result[1] = brr[j];
                        }
                    }
                }
            }

            List<int> list = new List<int>();
            list.Add(result[0]);
            list.Add(result[1]);
            return list;

        }
    }
}
