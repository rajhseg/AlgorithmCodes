using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class ArrayProgram
    {
        public static int[][] fourSum(int[] arr, int k)
        {
            List<List<int>> list = new List<List<int>>();   

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i+1; j < arr.Length; j++)
                {
                    for (int x = j+1; x < arr.Length; x++)
                    {
                        for (int y = x+1; y < arr.Length; y++)
                        {
                            if(arr[i] + arr[j] + arr[x] + arr[y] == k)
                            {
                                if (!list.Where(w => w.Contains(arr[i]) && w.Contains(arr[j]) && w.Contains(arr[x]) && w.Contains(arr[y])).Any())
                                {
                                    list.Add(new List<int> { arr[i], arr[j], arr[x], arr[y] });
                                }
                            }
                        }
                    }
                }
            }

            int[][] result = new int[list.Count][];
            int val = 0;

            foreach (var item in list)
            {
                int[] q = item.ToArray();
                Sorting.QuickSort(q, 0, item.Count - 1);
                result[val] = q;
                val++;
            }

            return result;
        }
    }
}
