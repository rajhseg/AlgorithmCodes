using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class BinarySearch
    {
        public static int GetIndex(int[] sortedArray, int searchValue)
        {
            return Get(sortedArray, searchValue, sortedArray.Length / 2, sortedArray.Length-1);
        }

        public static int Get(int[] arr, int value, int middleIndex, int binaryLastIndex)
        {            
            if(middleIndex == binaryLastIndex)
            {             
                if (arr[binaryLastIndex] == value)
                    return binaryLastIndex;
                else
                    return -1;
            }          
            else if(arr[middleIndex] < value)
            {
                return Get(arr, value,(int) Math.Ceiling((middleIndex + binaryLastIndex)/(double)2), binaryLastIndex);
            }
            else if(arr[middleIndex]> value){
                return Get(arr, value, middleIndex / 2, middleIndex);
            }
            else
            {
                if (arr[middleIndex] == value)
                {
                    return middleIndex;
                }
                else
                {
                    return -1;
                }
            }
        }
    }
}
