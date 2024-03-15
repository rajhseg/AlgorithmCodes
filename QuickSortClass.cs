namespace QuickSortingSample;

public class QuickSortClass
{
    public static int[] Sort(int[] arr) {
        return ActualSort(arr, 0, arr.Length-1);
    }

    public static int[] ActualSort(int[] arr, int low, int high)
    {
        if(low < high)
        {
            int pivot = Pivot(arr, low, high);
            ActualSort(arr, low, pivot-1);
            ActualSort(arr, pivot+1, high);
        }

        return arr;
    }

    public static int Pivot(int[] arr, int low, int high) {

        int pivot = arr[high];
        int start = low-1;

        for(int i = low; i<high; i++){
            if(arr[i]< pivot){
                start = start+1;
                Swap(ref arr, start, i);
            }
        }

        Swap(ref arr, start+1, high);

        return start+1;
    }

    public static void Swap(ref int[] arr, int i, int j){
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
}
