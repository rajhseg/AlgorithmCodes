using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Sorting
    {
        public static int[] GetSort(int[] arr)
        {
            for (int i = 0; i < arr.Length-1; i++)
            {
                for (int j = i+1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        Swap(ref arr, i, j);
                    }
                }
            }

            return arr;
        }

        public static int[] MergeSort(int[] a)
        {
            return SplitArray(a);
        }

        private static int[] SplitArray(int[] a)
        {            
            if(a.Length == 1)
                return a;

            int mid = a.Length / 2;
            int[] left = new int[mid];
            int[] right = new int[a.Length-mid];

            for (int i = 0; i < mid; i++)
            {
                left[i] = a[i];
            }

            int k = 0;            
            for (int j = mid; j < a.Length; j++)
            {
                right[k] = a[j];
                k++;
            }

            if(left.Length <2 && right.Length < 2)
            {              
                return MergeArray(left, right);
            }

            var leftSubArray = SplitArray(left);
            var rightSubArray = SplitArray(right);

            return MergeArray(leftSubArray, rightSubArray);
        }        

        public static int[] MergeArray(int[] a, int[] b)
        {            
            int i = 0;
            int j = 0;
            int[] k = new int[a.Length+b.Length];
            int l = 0;

            while(i<a.Length && j < b.Length)
            {

                if (a[i] < b[j])
                {
                    k[l] = a[i];
                    l++;
                    i++;
                }
                else
                {
                    k[l] = b[j];
                    l++;
                    j++;                    
                }
            }

            if (i == a.Length)
            {
                while(j < b.Length)
                {
                    k[l] = b[j];
                    l++;
                    j++;
                }
            }

            if (j == b.Length)
            {
                while (i < a.Length)
                {
                    k[l] = a[i];
                    l++;
                    i++;
                }
            }

            return k;
        }

        public static void QuickSort(int[] arr, int low, int high)
        {
            //if (high <= 0 || low >= arr.Length || low > high || low ==high)
            //    return;

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
                    Swap(ref arr, high, k);
                }

                if (arr[i] < arr[high])
                {                   
                    k++;
                    if (arr[k]> arr[i])
                    {
                        Swap(ref arr, k, i);
                    }
                }                
               
                i++;
                
            }

            return k;
        }

        public static void Swap(ref int[] arr, int i, int j)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
